using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveData
{
    public int point;
    public float speed;
    public int gold;
    public string name;
    public List<string> friends = new();
}

public class SaveManager : MonoBehaviour
{
    public SaveData saveData;

    public void PrintData()
    {
        print($"point : {saveData.point}");
        print($"speed : {saveData.speed}");
        print($"gold : {saveData.gold}");
        print($"name : {saveData.name}");
        for (var i = 0; i < saveData.friends.Count; i++)
        {
            print($"friends[{i}] : {saveData.friends[i]}");
        }
    }

    public void Save()
    {
        // saveData 변수를 json 형식으로 변환한다
        var jsonData = JsonUtility.ToJson(saveData, true);
        // jsonData를 save.json에 저장한다
        File.WriteAllText(Path.Combine(Application.persistentDataPath, "save.json"), jsonData);
    }

    public void Load()
    {
        // save.json이 존재하지않는가?
        if (!File.Exists(Path.Combine(Application.persistentDataPath, "save.json")))
        {
            // saveData 변수를 새로 작성
            saveData = new SaveData();
            // Load 메서드 종료
            return;
        }
        // 파일이 존재하면 save를 불러온다
        var jsonData = File.ReadAllText(Path.Combine(Application.persistentDataPath, "save.json"));
        // saveData 변수에 덮어씌운다
        saveData = JsonUtility.FromJson<SaveData>(jsonData);
    }

    public void ViewSaveFile()
    {
        Process.Start("notepad.exe", Path.Combine(Application.persistentDataPath, "save.json"));
    }
}
