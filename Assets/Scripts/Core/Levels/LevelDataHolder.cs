using System.Collections.Generic;
using UnityEngine;

public class LevelDataHolder : Singleton<LevelDataHolder>
{
    [SerializeField] GameEventSO gameEvents;

    public List<LevelData> LevelSODatas;

    private int currentLevel;
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        gameEvents.OnSaveFileLoaded += OnSaveDataUpdated;
    }
    private void OnDestroy()
    {
        gameEvents.OnSaveFileLoaded -= OnSaveDataUpdated;
    }
    private void OnSaveDataUpdated(SaveData data)
    {
        int currentLevelCount = data.currentLevel;
        SaveAndLoadDataManager.Instance.currentSelectedLevel = data.currentLevel;
        for (int i = 0; i < LevelSODatas.Count; i++)
        {
            if (i <= currentLevelCount)
            {
                if (i < currentLevelCount)
                {
                    LevelSODatas[i].LevelCompleted();
                }
                LevelSODatas[i].UnlockLevel();
            }
        }
        gameEvents.RaiseEvent(7);
    }
}
