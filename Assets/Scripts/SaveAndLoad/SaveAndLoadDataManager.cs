using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveAndLoadDataManager:Singleton<SaveAndLoadDataManager>
{
    public GameEventSO gameEvents;

    private const string fileName="match.data";
    private string filePath;

    public SaveData currentData;
    public int currentSelectedLevel;

    public override void Awake()
    {
        filePath=Path.Combine(Application.persistentDataPath,fileName);
        base.Awake();
        DontDestroyOnLoad(this);
        gameEvents.OnRoundCompleted += GameEvents_OnRoundCompleted;
        PlayGameOn60FPS();
    }
    void PlayGameOn60FPS()
    {
        Application.targetFrameRate = 60;
    }

    private void OnDestroy()
    {
        gameEvents.OnRoundCompleted -= GameEvents_OnRoundCompleted;
    }
    private void GameEvents_OnRoundCompleted()
    {
        currentSelectedLevel++;
        if (currentSelectedLevel < currentData.currentLevel) return;
        currentData.currentLevel++;
        SaveData();
    }
    public void LoadData()
    {
        if (!File.Exists(filePath))
        {
            CreateNewFile();
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream loadFile = File.Open(filePath, FileMode.Open);
        currentData = (SaveData)bf.Deserialize(loadFile);
        loadFile.Close();
        gameEvents.OnSaveFileLoaded?.Invoke(currentData);
    }
    void CreateNewFile()
    {
        currentData= new(PlayerPrefs.GetString("name"), 0, 0);
        SaveData();
    }
    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream saveFile = File.Create(filePath);
        bf.Serialize(saveFile, currentData);
        saveFile.Close();
        gameEvents.OnSaveFileLoaded?.Invoke(currentData);
    }
}
