using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/IconSO")]
public class IconSO : ScriptableObject
{
    [SerializeField] private List<Sprite> icon;

    public Sprite GetSprite(int index)
    {
        return icon[index];

    }
}

