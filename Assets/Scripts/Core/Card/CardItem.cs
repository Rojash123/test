using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardItem : MonoBehaviour
{
    public static CardItem previousPickedCard { get; private set; }
    private CardItem itemToCheckWith;

    [Header("References")]
    [SerializeField] Image iconHolder;
    [SerializeField] private Button thisButton;
    [field: SerializeField] public int index { get; private set; }
    [field: SerializeField] public bool isFlipped { get; private set; }

    private float flipRotationFinalY = 180;

    private void Start()
    {
        thisButton.onClick.AddListener(OnButtonClick);
    }
    private void OnDestroy()
    {
        thisButton.onClick.RemoveAllListeners();
    }
    void OnButtonClick()
    {
        thisButton.interactable = false;
        Flip(true);
    }
    public void MakeButtonInteractable()
    {
        thisButton.interactable = true;
    }
    public void Flip(bool canCheck)
    {
        isFlipped = !isFlipped;
        flipRotationFinalY = flipRotationFinalY == 0 ? 180 : 0;
        LeanTween.rotate(gameObject, new Vector3(0, flipRotationFinalY, 0), 0.10f).setOnComplete(() =>
        {
            if (canCheck) HandleCardMatch();
        });
    }
    void HandleCardMatch()
    {
        if (previousPickedCard == null)
        {
            previousPickedCard = this;
            return;
        }
        if (previousPickedCard.isFlipped && isFlipped)
        {
            CheckForMatch();
        }
    }
    void CheckForMatch()
    {
        itemToCheckWith = previousPickedCard;
        previousPickedCard = null;
        if (itemToCheckWith.index == index)
        {
            MyDebug.Log("Matched");
        }
        else
        {
            StartCoroutine(IflipBothCardBackToNormal());
        }
    }
    IEnumerator IflipBothCardBackToNormal()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        itemToCheckWith.Flip(false);
        Flip(false);
        yield return new WaitForSecondsRealtime(0.1f);
        itemToCheckWith.MakeButtonInteractable();
        MakeButtonInteractable();
    }
}
