using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScaleAnimation : MonoBehaviour
{
    [SerializeField] GameObject childPanel;
    [SerializeField] Button closeButton;

    private void OnEnable()
    {
        childPanel.transform.localScale=Vector2.zero;
        if (closeButton != null) closeButton.interactable = false;
        LeanTween.scale(childPanel, Vector2.one,0.5f).setEaseOutBack().setOnComplete(() =>
        {
            if(closeButton!=null)closeButton.interactable = true;
        });
    }
    private void OnDisable()
    {
        LeanTween.cancel(childPanel);
    }
}
