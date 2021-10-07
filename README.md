# OpenShift 初めてのPipeline/GitOps ハンズオン

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
* [ハンズオン その2](./handson2.md)
  1. トリガーの設定と動作確認 (15分)
  1. テストタスクの作成及びパイプライン実行 (5分)
  1. テストソースの修正及びパイプライン自動実行 (10分)
* [ハンズオン その3 (時間に余裕のある人向け)](./handson3.md)
  1. OpenShift GitOpsインストール (2分)
  1. ArgoCDへのアプリ設定とデプロイ実行 (10分)