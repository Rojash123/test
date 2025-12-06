using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnner : MonoBehaviour
{
    [SerializeField] GameEventSO gameEvents;
    [SerializeField] UIEventSO uiEvents;

    [SerializeField] LevelItems levelItemPrefab;
    [SerializeField] Transform levelHolder;

    private void Awake()
    {
        gameEvents.OnLevelDataSynced += SpawnLevelPrefabs;
    }
    private void OnDestroy()
    {
        gameEvents.OnLevelDataSynced += SpawnLevelPrefabs;
    }
    private void SpawnLevelPrefabs()
    {
        for (int i = 0; i < LevelDataHolder.Instance.LevelSODatas.Count; i++)
        {
            LevelItems levelItem = Instantiate(levelItemPrefab,levelHolder.position, Quaternion.identity);
            levelItem.transform.SetParent(levelHolder);
            levelItem.SetData(LevelDataHolder.Instance.LevelSODatas[i],this);
            levelItem.gameObject.SetActive(true);
        }

    }
    public void OpenLevelStartUI(string levelString, string dimensionString)
    {
        uiEvents.OnLevelPanelOpen?.Invoke(levelString, dimensionString);
    }
}
