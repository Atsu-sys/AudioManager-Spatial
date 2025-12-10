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

### インストールエラーが発生した場合

**EPERMエラー（権限エラー）が発生した場合：**

1. **Unityエディタを完全に終了**（すべてのインスタンス）
2. **PackageCacheをクリア**:
   - `プロジェクトフォルダ/Library/PackageCache/com.kankikuchi.audiomanager@*` を削除
   - `プロジェクトフォルダ/Library/PackageCache/.tmp-*` を削除（一時ディレクトリ）
3. **Unityエディタを再起動**して再度インストールを試みる

詳細は [TROUBLESHOOTING.md](TROUBLESHOOTING.md) を参照してください。

**代替インストール方法：**

- **ローカルパスから**: リポジトリをクローンし、`Add package from disk...` で `package.json` を選択
- **manifest.jsonに直接追加**:
  ```json
  {
    "dependencies": {
      "com.kankikuchi.audiomanager": "https://github.com/Atsu-sys/AudioManager-Spatial.git"
    }
  }
  ```

## Fork元リポジトリ

https://github.com/kankikuchi/AudioManager.git

## ドキュメント

## Meta XR 空間オーディオ (Spatial Audio)

Meta XR Audio SDKを使用した3D空間オーディオ再生に対応しました。

### 前提条件

* プロジェクトに **Meta XR Audio SDK** がインストールされていること。
* `Runtime/KanKikuchi.AudioManager.asmdef` に Meta XR Audio SDK のAssembly Definitionへの参照（例: `Meta.XR.Audio` や `Oculus.Spatializer`）が追加されていること。

### 設定

1. **SE用プレハブの作成**:
   * 新しいGameObjectを作成し、`AudioSource` と `MetaXRAudioSource` コンポーネントをアタッチします。
   * **重要**: `MetaXRAudioSource` コンポーネントの `Enabled` はデフォルトで **オフ** にしてください（スクリプトから制御されます）。
   * 必要に応じて `Enable Reflections` などを有効にします。
   * これをプレハブ化します（例: `SpatialSEPlayer`）。

2. **AudioManagerの設定**:
   * `Assets/Resources/AudioManagerSetting` を選択します。
   * Inspectorの **SE Prefab** フィールドに、作成したプレハブを割り当てます。

### 使い方

`SEManager.Instance.Play` メソッドの引数に `Vector3 position` を渡すことで、その位置から空間オーディオとして再生されます。

```csharp
// 指定した位置(transform.position)から3D音響として再生
// MetaXRAudioSourceが有効になり、spatialBlendが1.0になります
SEManager.Instance.Play("SE_Name", transform.position);

// 通常の2D再生（位置指定なし）
// MetaXRAudioSourceが無効になり、spatialBlendが0.0になります
SEManager.Instance.Play("SE_Name");
```
