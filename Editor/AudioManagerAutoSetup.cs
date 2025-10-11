namespace KanKikuchi.AudioManager {

using UnityEngine;
using UnityEditor;
using System.IO;

/// <summary>
/// AudioManagerの初回セットアップを自動で行うスクリプト
/// </summary>
[InitializeOnLoad]
public class AudioManagerAutoSetup {
  
  private const string SETUP_KEY = "AudioManager_AutoSetup_Done";
  private const string SESSION_KEY = "AudioManager_SetupDialog_Shown";
  private const string RESOURCES_PATH = "Assets/Resources";
  private const string BGM_PATH = "Assets/Resources/BGM";
  private const string SE_PATH = "Assets/Resources/SE";
  private const string SETTING_PATH = "Assets/Resources/AudioManagerSetting.asset";
  
  static AudioManagerAutoSetup() {
    // 初回のみ実行（既にセットアップ済みの場合はスキップ）
    if (EditorPrefs.GetBool(SETUP_KEY, false)) {
      return;
    }
    
    // このセッションで既に表示済みならスキップ
    if (SessionState.GetBool(SESSION_KEY, false)) {
      return;
    }
    
    // エディタの更新が完了してから実行（delayCallで次のフレームに遅延）
    EditorApplication.delayCall += ShowSetupDialog;
  }
  
  private static void ShowSetupDialog() {
    // 既にセットアップ済みかチェック
    if (EditorPrefs.GetBool(SETUP_KEY, false)) {
      return;
    }
    
    // このセッションで既に表示済みならスキップ
    if (SessionState.GetBool(SESSION_KEY, false)) {
      return;
    }
    
    // セッションフラグを設定（このセッション中に二度表示しない）
    SessionState.SetBool(SESSION_KEY, true);
    
    // 確認ダイアログを表示
    bool setup = EditorUtility.DisplayDialog(
      "Audio Manager - 初回セットアップ",
      "Audio Managerを使用するための初期フォルダとアセットを自動作成しますか？\n\n" +
      "作成されるもの：\n" +
      "- Assets/Resources/\n" +
      "- Assets/Resources/BGM/\n" +
      "- Assets/Resources/SE/\n" +
      "- Assets/Resources/AudioManagerSetting.asset",
      "セットアップする",
      "後で手動で作成"
    );
    
    if (setup) {
      PerformSetup();
    }
    
    // セットアップ完了フラグを保存（ダイアログを表示したら二度と表示しない）
    EditorPrefs.SetBool(SETUP_KEY, true);
  }
  
  private static void PerformSetup() {
    // Resourcesフォルダを作成
    if (!AssetDatabase.IsValidFolder(RESOURCES_PATH)) {
      AssetDatabase.CreateFolder("Assets", "Resources");
      Debug.Log("作成しました: " + RESOURCES_PATH);
    }
    
    // BGMフォルダを作成
    if (!AssetDatabase.IsValidFolder(BGM_PATH)) {
      AssetDatabase.CreateFolder(RESOURCES_PATH, "BGM");
      Debug.Log("作成しました: " + BGM_PATH);
    }
    
    // SEフォルダを作成
    if (!AssetDatabase.IsValidFolder(SE_PATH)) {
      AssetDatabase.CreateFolder(RESOURCES_PATH, "SE");
      Debug.Log("作成しました: " + SE_PATH);
    }
    
    // AudioManagerSettingアセットを作成
    if (!File.Exists(SETTING_PATH)) {
      var setting = ScriptableObject.CreateInstance<AudioManagerSetting>();
      AssetDatabase.CreateAsset(setting, SETTING_PATH);
      Debug.Log("作成しました: " + SETTING_PATH);
    }
    
    // アセットデータベースを更新
    AssetDatabase.SaveAssets();
    AssetDatabase.Refresh();
    
    // 完了メッセージ
    EditorUtility.DisplayDialog(
      "セットアップ完了",
      "Audio Managerのセットアップが完了しました！\n\n" +
      "BGMファイルは Assets/Resources/BGM/ に、\n" +
      "SEファイルは Assets/Resources/SE/ に配置してください。",
      "OK"
    );
    
    // Resourcesフォルダを選択状態にする
    var resourcesFolder = AssetDatabase.LoadAssetAtPath<Object>(RESOURCES_PATH);
    Selection.activeObject = resourcesFolder;
    EditorGUIUtility.PingObject(resourcesFolder);
  }
  
  /// <summary>
  /// セットアップ状態をリセット（テスト用）
  /// </summary>
  [MenuItem("Tools/KanKikuchi.AudioManager/Reset Auto Setup")]
  private static void ResetSetup() {
    EditorPrefs.DeleteKey(SETUP_KEY);
    Debug.Log("Audio Managerの自動セットアップ状態をリセットしました。");
  }
}

}

