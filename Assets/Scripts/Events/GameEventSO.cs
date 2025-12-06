using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ScriptableObject",menuName = "ScriptableObject/GameEventSO")]
public class GameEventSO : ScriptableObject
{
    public event Action OnGameStart;
    public event Action OnGameOver;
    public event Action OnGamePaused;
    public event Action OnGameUnpause;
    public event Action OnMatched;
    public event Action OnMisMatch;

    public event Action OnRoundCompleted;
    public event Action OnLevelDataSynced;

    public Action<SaveData> OnSaveFileLoaded;
    /// <summary>
    /// <br>0-OnGameStart</br><br>1-OnGameOver</br><br>2-OnGamePaused</br><br>3-OnGameUnpause</br><br>4-OnMatched</br><br>5-OnMisMatch</br><br>6-OnRoundCompleted</br><br>7-OnLevelDataSynced</br>
    /// </summary>
    /// <param name="index"></param>
    public void RaiseEvent(int index)
    {
        switch (index)
        {
            case 0:
                OnGameStart?.Invoke();
                break;
            case 1:
                OnGameOver?.Invoke();
                break;
            case 2:
                OnGamePaused?.Invoke();
                break;
            case 3:
                OnGameUnpause?.Invoke();
                break;
            case 4:
                OnMatched?.Invoke();
                break;
            case 5:
                OnMisMatch?.Invoke();
                break;
            case 6:
                OnRoundCompleted?.Invoke();
                break;
            case 7:
                OnLevelDataSynced?.Invoke();
                break;
        }
    }

}
