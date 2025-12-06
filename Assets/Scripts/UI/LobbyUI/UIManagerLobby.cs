using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerLobby : MonoBehaviour
{
    [SerializeField] UIEventSO uiEvents;

    [Header("LevelPanel")]
    [SerializeField] TextMeshProUGUI levelDetails;
    [SerializeField] TextMeshProUGUI levelTitle;
    [SerializeField] GameObject levelUI;


    [Header("Sound")]
    [SerializeField] Toggle soundToggle;

    private void Awake()
    {
        uiEvents.OnLevelPanelOpen += HandlePanelOpen;
        soundToggle.onValueChanged.AddListener(SoundManager.Instance.HandeToggleChange);
    }
    private void Start()
    {
        HandleSoundState();
    }
    private void OnDestroy()
    {
        uiEvents.OnLevelPanelOpen -= HandlePanelOpen;
        soundToggle.onValueChanged.RemoveAllListeners();
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
}
