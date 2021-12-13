# (作成中) OpenShift 初めてのGitOps ハンズオン その1

**TODO: イメージのデプロイの箇所で権限不足でエラーとなっている。調査中。**

OpenShift GitOpsについて、ごく簡単にご説明します。

## 1. Red Hat OpenShift Pipelinesのインストール

ここからは、OpenShiftにOpenShift GitOpsをインストールします。

### 1.1 Operatorの検索

OpenShiftのWebコンソールへ戻り、[OperatorHub]ボタンをクリックします。

インストール可能なOperatorがタイル表示されています。

[Filter by keyword..]に「OpenShift GitOps」と入力し、Red Hat OpenShift GitOpsを選択します。

![](./images/4/001.png)

### 1.2 Operatorのインストール

Red Hat OpenShift Pipelines 画面にて[インストール]をクリックします。

![](./images/4/002.png)

続けて Operatorのインストール 画面にて、すべてデフォルトのままで、[インストール]をクリックします。

![](./images/4/003.png)

インストール完了のダイアログが表示されたあと、左上のメニューにて、[管理者]から[Developer]に切り替えます。

画面左側の項目に「環境」というメニューが追加されていれば成功です。

![](./images/4/005.png)

もししばらく待っても追加されない場合は画面のリロードを試してください。

以上でインストール作業は完了です。

## 2. GitOps(ArgoCD)　ログイン

インストールしたGitOps(ArgoCD)を表示してみます。

### 2.1 ArgoCDログイン情報の取得

左上のメニューが[管理者]になっている方は、[管理者]から[Developer]に切り替えます。

左下の[シークレット]をクリックし、中央上の[プロジェクト]を openshift-gitops に変更します。

(s) openshift-gitops-operator という項目リンクをクリックします。

![](./images/4/006.png)

最下部にGitOps(ArgoCD)のadminユーザのパスワードが表示されています。

右下のコピーボタンをクリックし、admin.password値をクリップボードにコピーします。

![](./images/4/007.png)

### 2.2 ArgoCDの起動

画面右上の四角いアイコンをクリックし、[Cluster ArgoCD]をクリックします。

![](./images/4/008.png)

ArgoCDの画面が表示されます。ユーザ名にadmin、パスワードは先ほどクリップボードコピーした値を貼り付けます。
[SIGN IN]をクリックします。

![](./images/4/009.png)

ArgoCDの画面を表示することができました。

![](./images/4/010.png)

ログイン作業は以上です。

(以降作成中)

## 3. 開発環境用アプリケーションのデプロイ

### 3.1 開発環境の作成

管理者に切り替え、プロジェクトを作成します。
名前には`dojo`を入力してください。

***画像差し込み***

Developerに切り替えて、デプロイをします。

[このリポジトリ](https://github.com/tty-kwn/pipeline-dotnet-sample)を自身のリポジトリにForkします。

***画像差し込み***

Forkができたら、featureブランチ`feature_dojo`を作成します。

***画像差し込み***

OpenShiftの画面に戻り、Developerに切り替えます。

ここからはS2Iの手順と同じ
> 注意:パイプラインにチェックを入れる

***画像差し込み***

デプロイが始まったら、[パイプライン]→`pipeline-dotnet-sample-git`のリンクをクリックします。

***画像差し込み***

YAMLタブをクリックし、表示されているYAMLを全てコピーしたらパンくずリストの`パイプライン`をクリックします。

***画像差し込み***

パイプラインの作成をクリックします。

***画像差し込み***

パイプラインビルダーが表示されたら、YAMLビューを選択します。

***画像差し込み***

表示されているYAMLを全て削除して、先ほどコピーしたYAMLをペーストします。
**このパイプラインは、本番環境用に使用します。**

***画像差し込み***

パラメータを開発用から本番用に書き換えます。
まずは不要な部分を削除します。

***画像差し込み***

その後、本番環境用のパラメータに変更します。

```yaml
・
・
・
metadata:
  labels:
    app.kubernetes.io/instance: pipeline-dotnet-sample # 末尾の'-git'を削除
    app.kubernetes.io/name: pipeline-dotnet-sample # 末尾の'-git'を削除
    pipeline.openshift.io/runtime: dotnet
    pipeline.openshift.io/runtime-version: 5.0-ubi8
    pipeline.openshift.io/type: kubernetes
  name: pipeline-dotnet-sample # 末尾の'-git'を削除
  namespace: dojo
spec:
  params:
    - default: pipeline-dotnet-sample # 末尾の'-git'を削除
      name: APP_NAME
      type: string
    - default: 'https://github.com/shu-adachi/pipeline-dotnet-sample.git' # ご自身のGitHubアカウントのリポジトリであればOKです
      name: GIT_REPO
      type: string
    - default: main # 'feature_dojo'→'main'に変更
      name: GIT_REVISION
      type: string
    - default: >-
        image-registry.openshift-image-registry.svc:5000/dojo/pipeline-dotnet-sample-git
      name: IMAGE_NAME
      type: string
    - default: SampleApp
      name: PATH_CONTEXT
      type: string
    - default: 5.0-ubi8
      name: VERSION
      type: string
・
・
・
```

### 3.2 本番環境の作成

管理者に切り替え、[ストレージ]の中から[永続ボリューム要求]を選択し、[永続ボリューム要求の作成]をクリックします。

|パラメータ名|設定値|
|:--|:--|
|永続ボリューム要求の名前|dojo|
|サイズ|1〜20|

[作成]をクリックします。

Developerに切り替えて、3.1で作成したパイプラインのYAMLをコピー
パンクズリストのパイプラインをクリックし、[パイプライン作成]をクリック

YAMLビューに切り替えてコピーしたYAMLをペースト

パラメータを編集して[作成]

アクションから、トリガーの追加を選択します。

|パラメータ名|設定値|
|:--|:--|
|Git プロバイダータイプ|github-push|
|workspace|永続ボリューム要求→dojo|

トリガーテンプレートのURLをコピーし、自身のGitHubリポジトリに戻ります。

Setting→Webhooks→Add webhook

|パラメータ名|設定値|
|:--|:--|
|Payload URL|コピーしたトリガーのURL|
|Content Type|application/json|

[Add webhook]をクリック

画面を更新して、緑のチェックマークになっていることを確認してください。

トリガーの動作確認をします。

mainブランチの/SampleApp/Pages/Index.cshtmlに移動し、cshtmlファイルを編集します。

```html
@page
@model IndexModel
@{
    ViewData["Title"] = "Sample page";
}

<div class="text-center">
    <h1 class="display-4">Welcome</h1>
    <p>This application is sample for Tech Dojo - OpenShift Pipeline/GitOps</p>
    <p>トリガー動作確認</p>
</div>
```

Commit Changesをクリックします。

OpenShiftのパイプライン画面にて、`pipeline-dotnet-sample`が実行されていることを確認します。

このパイプラインでは、デプロイまではせず、イメージレジストリへのPUSHまでを行うので、アプリケーションは更新されていないことを確認します。

## 4. 本番環境用アプリケーションのデプロイ

### 4.1 ArgoCDでのアプリセットアップ

ArgoCDの画面に戻り、左上の[＋NEW APP]をクリックします。

＊＊画像差し込み

下記の通り、[GENERAL]の各項目に値を設定します。

[Application Name]：「pipeline-dotnet-sample」

[Project]：「default」

[SYNC POLICY]：「Manual」

＊＊画像差し込み

続いて、[SOURCE]の各項目に値を設定します。

[Repository URL]：「X.XでForkしたリポジトリのURL」

[Revision]：「HEAD」

[Path]：「gitops」

＊＊画像差し込み

続いて、[DESTINATION]の各項目に値を設定します。

[Cluster URL]：「https://kubernetes.default.svc」

[Namespace]：「HEAD」

＊＊画像差し込み

最後に、[DIRECTORY]の[DIRECTORY RECURSE]にチェックを入れ、[CREATE]をクリックします。

＊＊画像差し込み

pipeline-dotnet-sample というアプリケーションが作成されていれば、ArgoCDでのアプリセットアップは完了です。

＊＊画像差し込み

### 4.2 GitHubとArgoCDの同期設定

作成したアプリケーションの[Status]を確認すると、[SYNC STATUS]が「OutOfSync」となっています。

つまり、今はGitリポジトリと同期されていない（＝差分がある）状態なので、同期します。

まず、アプリケーションの左下にある[SYNC]をクリックします。

＊＊画像差し込み

同期メニューが表示されるので、左上の[SYNCHRONIZE]をクリックすると、同期が始まります。

＊＊画像差し込み

[Status]の[SYNC STATUS]が「Synced」となれば、同期はできています。

[Status]の[HEALTH STATUS]が「Healty」となれば、その同期処理は正常に行われ、アプリケーションがデプロイされています。

＊＊画像差し込み

デプロイ結果の確認のため、OpenShiftのWebコンソールへ戻ります。

左上のメニューが[管理者]になっている方は、[管理者]から[Developer]に切り替えます。

メニューから[トポロジー]をクリックし、中央上の[プロジェクト]を dojo に変更します。

pipeline-dotnet-sample というデプロイメントが存在していれば成功です。

＊＊画像差し込み

今回は手動で同期を行いましたが、CD（継続的デプロイ）を行えるようにArgoCDの設定を変更します。

ArgoCDの画面に戻り、アプリケーション pipeline-dotnet-sample をクリックします。

アプリケーションの詳細が表示されるので、再度アプリケーション pipeline-dotnet-sample をクリックします。

＊＊画像差し込み

右上の[EDIT]をクリックします。

＊＊画像差し込み

[SUMMARY]タブの下部にある[ENABLE AUTO-SYNC]をクリックします。

＊＊画像差し込み

確認メッセージが表示されるので、[OK]をクリックします。

以上で、CDのための準備ができました。

## 5. CDの動作確認

GitHubのindex.cshtmlを更新します。

パイプラインの実行が完了したことを確認したら、マニフェストを更新します。

管理者に切り替え、[ビルド]→[イメージストリームタグ]→pipeline-dotnet-sampleのリンクをクリックします。

YAMLタブをクリックし、dockerImageReferenceに記載されているパラメータをコピーします。

```yaml
・
・
・
status:
  dockerImageRepository: >-
    image-registry.openshift-image-registry.svc:5000/dojo/pipeline-dotnet-sample-git
  tags:
    - tag: latest
      items:
        - created: '2021-12-13T04:06:19Z'
          dockerImageReference: >-
            image-registry.openshift-image-registry.svc:5000/dojo/pipeline-dotnet-sample-git@sha256:b772388d10663da969444edafde6a980ef7eee2e97bd50423a45eb110a2261d9
          image: >-
            sha256:b772388d10663da969444edafde6a980ef7eee2e97bd50423a45eb110a2261d9
          generation: 1
・
・
・
```

GitHubリポジトリに移動し、mainリポジトリの/gitops/dotnet-sample-deployment.yamlを編集します。

```yaml
---
kind: Deployment
apiVersion: apps/v1
metadata:
  name: pipeline-dotnet-sample
  namespace: dojo
spec:
  replicas: 1
  selector:
    matchLabels:
      app: pipeline-dotnet-sample
  template:
    metadata:
      labels:
        app: pipeline-dotnet-sample
        deploymentconfig: pipeline-dotnet-sample
    spec:
      containers:
        - name: pipeline-dotnet-sample
          image: # ここにペースト
          ports:
            - containerPort: 8080
              protocol: TCP
          resources: {}
          terminationMessagePath: /dev/termination-log
          terminationMessagePolicy: File
          imagePullPolicy: Always
      restartPolicy: Always
      terminationGracePeriodSeconds: 30
      dnsPolicy: ClusterFirst
      securityContext: {}
      schedulerName: default-scheduler
      imagePullSecrets: []
  strategy:
    type: RollingUpdate
    rollingUpdate:
      maxSurge: 25%
      maxUnavailable: 25%
  revisionHistoryLimit: 10
  progressDeadlineSeconds: 600
  paused: false
```

パイプラインが実行されますが、気にせず放置しArgoCDの同期を待ちます。

ArgoCDの同期が完了したらアプリケーションを確認します。

アプリケーションが更新されていることが確認できました。
以上で、CDの確認は完了です。
