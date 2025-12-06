
using System;
using UnityEngine;

[Serializable]
public struct SaveData
{
    public string userName;
    public int currentLevel;
    public int score;
    public SaveData(string userName, int currentLevel, int score)
    {
        this.userName = userName;
        this.currentLevel = currentLevel;
        this.score = score;
    }
}
