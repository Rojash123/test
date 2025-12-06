using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/LevelSO")]

[Serializable]
public class LevelData : ScriptableObject
{
    [field: SerializeField] public int levelNumber { get; private set; }
    [field: SerializeField] public int totalRows { get; private set; }
    [field: SerializeField] public int totalColumns { get; private set; }
    [field: SerializeField] public bool iSCompleted { get; private set; }
    [field: SerializeField] public bool isUnlocked { get; private set; }

    public void UnlockLevel()
    {
        isUnlocked = true;
    }
    public void LevelCompleted()
    {
        iSCompleted = true;
    }
    public void ResetData()
    {
        isUnlocked = false;
        iSCompleted = false;
    }
}
