using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameEventSO gameEvents;
    [SerializeField] UIEventSO uiEvents;
    [SerializeField] List<LevelData> LevelSODatas;
    [SerializeField] LevelItems levelItemPrefab;
    [SerializeField] Transform levelHolder;

    private void Awake()
    {
        gameEvents.OnSaveFileLoaded += OnSaveDataLoaded;
    }
    private void OnDestroy()
    {
        gameEvents.OnSaveFileLoaded += OnSaveDataLoaded;
    }
    private void OnSaveDataLoaded(SaveData data)
    {
        int currentLevelCount = data.currentLevel;
        for (int i = 0; i < LevelSODatas.Count; i++)
        {
            LevelItems levelItem = Instantiate(levelItemPrefab,levelHolder.position, Quaternion.identity);
            levelItem.transform.SetParent(levelHolder);
            if (i <= currentLevelCount)
            {
                if(i< currentLevelCount)
                {
                    LevelSODatas[i].LevelCompleted();
                }
                LevelSODatas[i].UnlockLevel();
            }
            levelItem.SetData(LevelSODatas[i],this);
            levelItem.gameObject.SetActive(true);
        }

    }

    public void OpenLevelStartUI(string levelString, string dimensionString)
    {
        uiEvents.OnLevelPanelOpen?.Invoke(levelString, dimensionString);
    }

}
