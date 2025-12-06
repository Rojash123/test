using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ScriptableObject",menuName = "ScriptableObject/GameEventSO")]
public class GameEventSO : ScriptableObject
{
    public event Action OnGameStart;
    public event Action OnGameOver;
    public event Action OnRoundCompleted;
    public event Action OnGamePaused;
    public event Action OnGameUnpause;
    public event Action OnMatched;
    public event Action OnMisMatch;

    public Action<SaveData> OnSaveFileLoaded;
    /// <summary>
    /// <br>0-OnGameStart</br><br>1-OnGameOver</br><br>2-OnGamePaused</br><br>3-OnGameUnpause</br>
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
                OnGameStart?.Invoke();
                break;
            case 5:
                OnGameStart?.Invoke();
                break;
            case 6:
                OnGameStart?.Invoke();
                break;
            case 7:
                OnGameStart?.Invoke();
                break;
        }
    }

}
