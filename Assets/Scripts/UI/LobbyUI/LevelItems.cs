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
    private LevelManager levelManager;

    public void SetData(LevelData data,LevelManager manager)
    {
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
        levelManager.OpenLevelStartUI(titleText.text, dimension);
    }

}
