# Unity Package Manager インストールエラー (EPERM) の解決方法

## エラー内容
```
Failed to rename [C:\Users\atsu\Documents\GitHub\MRider\Library\PackageCache\.tmp-28852-XVoYe6ARHZ9S\move] 
to [C:\Users\atsu\Documents\GitHub\MRider\Library\PackageCache\com.kankikuchi.audiomanager@d6f18a3a17c3] 
while cloning https://github.com/Atsu-sys/AudioManager-Spatial.git, error code [EPERM].
```

## 解決手順

### 1. Unityエディタを完全に終了
- すべてのUnityエディタインスタンスを終了してください
- タスクマネージャーで `Unity.exe` や `Unity Hub.exe` が実行されていないか確認してください

### 2. PackageCacheディレクトリをクリア
以下のディレクトリを削除または名前を変更してください：
```
C:\Users\atsu\Documents\GitHub\MRider\Library\PackageCache\com.kankikuchi.audiomanager@*
```

**注意**: 削除できない場合は、管理者権限で実行するか、ファイルが使用中でないことを確認してください。

### 3. 一時ディレクトリをクリア
以下のような一時ディレクトリが残っている場合は削除してください：
```
C:\Users\atsu\Documents\GitHub\MRider\Library\PackageCache\.tmp-*
```

### 4. Unityエディタを再起動
- Unity Hubからプロジェクトを開き直してください
- Package Managerで再度インストールを試みてください

### 5. それでも解決しない場合

#### 5-1. ウイルス対策ソフトを一時的に無効化
- Windows Defenderやその他のウイルス対策ソフトがファイルアクセスをブロックしている可能性があります
- 一時的に無効化して再試行してください

#### 5-2. プロジェクトフォルダの権限を確認
- プロジェクトフォルダ（`C:\Users\atsu\Documents\GitHub\MRider`）のプロパティを開く
- 「セキュリティ」タブで、現在のユーザーが「フルコントロール」の権限を持っていることを確認

#### 5-3. Libraryフォルダ全体を削除（最終手段）
- Unityエディタを完全に終了
- `C:\Users\atsu\Documents\GitHub\MRider\Library` フォルダを削除
- Unityエディタを再起動（自動的に再生成されます）

## 代替インストール方法

### 方法1: ローカルパスからインストール
1. このリポジトリをローカルにクローン
2. UnityのPackage Managerで `Add package from disk...` を選択
3. クローンしたリポジトリの `package.json` を選択

### 方法2: manifest.jsonに直接追加
`Packages/manifest.json` に以下を追加：
```json
{
  "dependencies": {
    "com.kankikuchi.audiomanager": "https://github.com/Atsu-sys/AudioManager-Spatial.git"
  }
}
```

## パッケージ構造の確認
このパッケージはUPMパッケージとして正しく構成されています：
- ✅ `package.json` がルートに存在
- ✅ `Runtime/` と `Editor/` フォルダが正しく配置
- ✅ Assembly Definition Filesが適切に設定

問題はUnity側のキャッシュまたは権限の問題である可能性が高いです。

