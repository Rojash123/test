using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerLobby : MonoBehaviour
{
    [SerializeField] UIEventSO uiEvents;

    [Header("LevelPanel")]
    [SerializeField] TextMeshProUGUI levelDetails;
    [SerializeField] TextMeshProUGUI levelTitle;
    [SerializeField] GameObject levelUI;
    [SerializeField] Button startLevelButton;

    [Header("Sound")]
    [SerializeField] Toggle soundToggle;

    private void Awake()
    {
        uiEvents.OnLevelPanelOpen += HandlePanelOpen;
        soundToggle.onValueChanged.AddListener(HandleToggleChange);
        startLevelButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("GameScene");
        });
    }
    private void Start()
    {
        HandleSoundState();
    }
    private void OnDestroy()
    {
        uiEvents.OnLevelPanelOpen -= HandlePanelOpen;
        soundToggle.onValueChanged.RemoveAllListeners();
        startLevelButton.onClick.RemoveAllListeners();
    }
    private void HandlePanelOpen(string arg1, string arg2)
    {
        levelTitle.text = arg1;
        levelDetails.text = arg2;
        levelUI.SetActive(true);
    }
    void HandleSoundState()
    {
        if (!PlayerPrefs.HasKey("sound"))
        {
            soundToggle.isOn = true;
            return;
        }
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            soundToggle.isOn = false;
        }
        else
        {
            soundToggle.isOn = true;
        }
    }

    void HandleToggleChange(bool value)
    {
        SoundManager.Instance.HandeToggleChange(value);
    }
}
