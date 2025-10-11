# Audio Manager (ver1.2)

Unityで誰でも簡単にSEやBGMを管理できるシステムです。

再生や停止はもちろん、一時停止やフェード、遅延や自動再生、さらにオーディオファイルの自動設定から、Resourcesへのパスの管理まで行うので、初心者の方でも安心して使えます！

## インストール

### Unity Package Manager (UPM)

1. Package Manager を開く (`Window > Package Manager`)
2. `+` ボタンをクリック
3. `Add package from git URL...` を選択
4. 以下のURLを入力:
   ```
   https://github.com/Atsu-sys/AudioManager.git
   ```

## 使い方

### 基本的な使い方

```csharp
using KanKikuchi.AudioManager;

// BGM再生
BGMManager.Instance.Play(BGMPath.BATTLE27);

// フェードアウト
BGMManager.Instance.FadeOut(duration: 2f);

// SE再生
SEManager.Instance.Play(SEPath.SYSTEM20, volumeRate: 0.8f);

// ボリューム変更
BGMManager.Instance.ChangeBaseVolume(0.5f);
```

### オーディオファイルの配置

BGMとSEは以下のフォルダに配置してください:

- BGM: `Assets/Resources/BGM/`
- SE: `Assets/Resources/SE/`

配置すると、自動的に `BGMPath.cs` と `SEPath.cs` が生成されます。

### 設定のカスタマイズ

`Assets/Resources/AudioManagerSetting.asset` を選択して、Inspector で各種設定を調整できます：

- 同時再生可能数
- 基準ボリューム
- キャッシュ設定
- オーディオファイルの自動設定

## ドキュメント

詳しい使い方は以下の記事をご覧ください:

[誰でも簡単に使える最強のAudio(BGM, SE)Manager【Unity】](http://kan-kikuchi.hatenablog.com/entry/AudioManager_2019)

## ライセンス

MIT License

## クレジット

- **BGM & SE**: 魔王魂 - https://maoudamashii.jokersounds.com/
- **Author**: KanKikuchi - http://kan-kikuchi.hatenablog.com/
