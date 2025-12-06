using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/UIEventSO")]
public class UIEventSO : ScriptableObject
{
    public Action<string,string> OnLevelPanelOpen;
}
