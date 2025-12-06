using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CardItem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Image iconHolder;
    [SerializeField] private Button thisButton;

    [field: SerializeField] public int itemValue { get; private set; }
    [field: SerializeField] public bool isFlipped { get; private set; }
    public static CardItem previousPickedCard { get; private set; }
    
    private CardItem itemToCheckWith;
    private float flipRotationFinalY = 180;
    private RectTransform rectTransform;

    private void Start()
    {
        thisButton.onClick.AddListener(OnButtonClick);
        rectTransform= GetComponent<RectTransform>();
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

    #region FlipAndMatchLogic
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
        if (itemToCheckWith.itemValue == itemValue)
        {
            MyDebug.Log("Matched");
        }
        else
        {
            StartCoroutine(I_FlipCardBackToNormalState());
        }
    }
    IEnumerator I_FlipCardBackToNormalState()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        itemToCheckWith.Flip(false);
        Flip(false);
        yield return new WaitForSecondsRealtime(0.1f);
        itemToCheckWith.MakeButtonInteractable();
        MakeButtonInteractable();
    }
    #endregion

    public void InitialiseData(CardData data)
    {
        rectTransform.sizeDelta = data.size;
        iconHolder.sprite= data.icon;
        itemValue = data.itemValue;
        LeanTween.move(gameObject, data.Pos, 0.5f).setEaseOutBack().setDelay(data.delay).setOnComplete(()=> 
        {
            thisButton.interactable = false;
        });
    }

}
