using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;

public class SaveAndLoadDataManager:Singleton<SaveAndLoadDataManager>
{
    [SerializeField] GameEventSO gameEvents;

    private const string fileName="match.data";
    private string filePath;

    public SaveData currentData;

    public override void Awake()
    {
        filePath=Path.Combine(Application.dataPath,fileName);
        base.Awake();
    }
    private void Start()
    {
        LoadData();
    }


    void LoadData()
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
        currentData= new(PlayerPrefs.GetString("name"), 1, 0);
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
