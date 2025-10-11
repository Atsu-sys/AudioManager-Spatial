namespace KanKikuchi.AudioManager {

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 定数クラスを生成するクラス
/// </summary>
public static class ConstantsClassCreator {

  //=================================================================================
  //クラス作成
  //=================================================================================

  /// <summary>
  /// 定数クラスを作成する
  /// </summary>
  public static void Create(string className, string summary, Dictionary<string, string> constValueDict, string exportPath, string nameSpace) {
    //定数の文字列を作成
    var constStringBuilder = new StringBuilder();
    var constList = constValueDict.OrderBy(pair => pair.Key).ToList();
    for (int i = 0; i < constList.Count; i++) {
      var pair = constList[i];
      constStringBuilder.AppendLine("\tpublic const string " + pair.Key + " = \"" + pair.Value + "\";");
    }

    //クラス全体を作成
    var classString = "namespace " + nameSpace + @"{

/// <summary>
/// " + summary + @"
/// </summary>
public static class " + className + @"{

" + constStringBuilder.ToString() + @"
}

}";

    //ファイルに出力
    var fileName = className + ".cs";
    var filePath = Path.Combine(exportPath, fileName);

    //ディレクトリが存在しない場合は作成
    var directoryPath = Path.GetDirectoryName(filePath);
    if (!Directory.Exists(directoryPath)) {
      Directory.CreateDirectory(directoryPath);
    }

    File.WriteAllText(filePath, classString, Encoding.UTF8);

    AssetDatabase.Refresh();

    Debug.Log(fileName + "を作成しました");
  }

}

}

