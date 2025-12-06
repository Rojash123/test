using TMPro;
using UnityEngine;

public class LevelItems : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] GameObject lockedStatus;
    [SerializeField] GameObject playStatus;
    [SerializeField] GameObject lockedDark;
    [SerializeField] GameObject[] stars;
    [SerializeField] TextMeshProUGUI titleText;

    private string dimension;
    private LevelSpawnner levelManager;
    private int levelNumber;

    public void SetData(LevelData data,LevelSpawnner manager)
    {
        levelNumber = data.levelNumber;
        levelManager = manager;
        titleText.text = $"LEVEL {data.levelNumber}";
        playStatus.SetActive(data.isUnlocked);
        lockedStatus.SetActive(!data.isUnlocked);
        lockedDark.SetActive(!data.isUnlocked);
        foreach (var item in stars)
        {
            item.SetActive(data.iSCompleted);
        }
        dimension = $"{data.totalRows}x{data.totalColumns}";
    }
    public void OpenUIPanel()
    {
        SaveAndLoadDataManager.Instance.currentSelectedLevel = levelNumber - 1;
        levelManager.OpenLevelStartUI(titleText.text, dimension);
    }

}
