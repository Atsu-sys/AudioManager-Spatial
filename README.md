# Audio Manager (ver1.2)

kankikuchi様のAudioManagerをUPM化させていただきました。

## インストール

### Unity Package Manager (UPM)

1. Package Manager を開く (`Window > Package Manager`)
2. `+` ボタンをクリック
3. `Add package from git URL...` を選択
4. 以下のURLを入力:
   ```
   https://github.com/Atsu-sys/AudioManager-Spatial.git
   ```

## Fork元リポジトリ

https://github.com/kankikuchi/AudioManager.git

## ドキュメント

[誰でも簡単に使える最強のAudio(BGM, SE)Manager【Unity】](http://kan-kikuchi.hatenablog.com/entry/AudioManager_2019)

## 空間オーディオ視覚インジケーター

音が鳴った位置に視覚的なインジケーター（アイコンやエフェクトなど）を表示する機能を追加しました。

### 設定

1. `Assets/Resources/AudioManagerSetting` を選択します。
2. Inspectorの **Spatial Indicator Prefab** に、表示したいプレハブ（例: スピーカーアイコンの画像など）を設定します。
   * **注意**: 設定するプレハブには、一定時間後に自身を削除するスクリプト（`Destroy(gameObject, time)`など）をアタッチしてください。

### 使い方

`SEManager.Instance.Play` メソッドの引数に `Vector3 position` を渡すことで、その位置にインジケーターを表示して音を再生します。

```csharp
// 現在のオブジェクトの位置でSEを再生し、インジケーターを表示
SEManager.Instance.Play("SE_Name", transform.position);
```
