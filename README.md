# OpenShift 初めてのPipeline ハンズオン

## 前提条件

本ハンズオンワークショップは、OpenShiftもしくはKubernetesに触れたことがある方を対象としています。

OpenShiftに触れたことが無い方は、まずはぜひ、我々のハンズオンワークショップ [Tech Dojo OpenShift - Self Study](https://ibm-developer.connpass.com) にて OpenShiftをご体感ください。基本的に、毎週水曜日午前に実施しております。

## 座学

[TODO:Pipelineとは?GitOpsとは?の資料をパワポで作成し、PDFで貼り付ける](test.pdf)


## ハンズオンワークショップの流れ

* [ハンズオン その1](./handson1.md) (30分)
  1. ワークショップの準備 (5分)
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
* [(未作成) ハンズオン その4](./handson4.md)
  1. OpenShift GitOpsインストール
  1. ArgoCDへのアプリ設定とデプロイ実行
  1. OpenShift Pipelines/GitOps連携