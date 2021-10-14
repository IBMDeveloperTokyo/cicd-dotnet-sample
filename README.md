# OpenShift 初めてのPipeline ハンズオン

## 前提条件

本ハンズオンワークショップは、OpenShiftもしくはKubernetesに触れたことがある方を対象としています。

OpenShiftに触れたことが無い方は、まずはぜひ、我々のハンズオンワークショップ [Tech Dojo OpenShift - Self Study](https://ibm-developer.connpass.com) にて OpenShiftをご体感ください。基本的に、毎週水曜日午前に実施しております。

## ワークショップの準備

下記ページの内容に沿って、ハンズオンワークショップの準備を実施ください。

[ハンズオンワークショップ - 準備](https://github.com/IBMDeveloperTokyo/openshift-s2i-lab/blob/main/PREPARE.md)

IBM CloudライトアカウントおよびGitHubアカウントの作成、OpenShiftクラスタの表示ができれば準備は完了です。

## ハンズオンワークショップの流れ

* [ハンズオン その1](./handson1.md) (25分)
  1. ソースコードのFork (2分)
  1. Red Hat OpenShift Pipelines Operatorのインストール (3分)
  1. アプリケーションのDeploy (20分)
* [ハンズオン その2](./handson2.md) (30分)
  1. トリガーの設定と動作確認 (10分)
  1. テストタスクの作成及びパイプライン実行 (10分)
  1. テストソースの修正及びパイプライン自動実行 (10分)
* [ハンズオン その3 (オプション)](./handson3.md) (35分)
  1. Tekton Hubの紹介とメール送信タスクの導入 (10分)
  1. シークレットの作成 (5分)
  1. GMail送信設定と動作確認 (10分)
  1. パイプラインへの組み込みと動作確認 (10分)
* [(未完) ハンズオン その4](./handson4.md)
  1. OpenShift GitOpsインストール
  1. ArgoCDへのアプリ設定とデプロイ実行
  1. OpenShift Pipelines/GitOps連携
