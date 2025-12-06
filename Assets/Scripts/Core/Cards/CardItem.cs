using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CardItem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Image iconHolder;
    [SerializeField] private Button thisButton;
    [SerializeField] private RectTransform rectTransform;

    [field: SerializeField] public int itemValue { get; private set; }
    [field: SerializeField] public bool isFlipped { get; private set; }
    public static CardItem previousPickedCard { get; private set; }
    
    private CardItem itemToCheckWith;
    private float flipRotationFinalY = 180;
    private Vector2 finalPos;

    private void Start()
    {
        thisButton.onClick.AddListener(OnButtonClick);
        rectTransform= GetComponent<RectTransform>();
    }
    private void OnDestroy()
    {
        thisButton.onClick.RemoveAllListeners();
    }
    public void SetData(CardData data)
    {
        rectTransform.sizeDelta = data.size;
        iconHolder.sprite= data.icon;
        itemValue = data.itemValue;
        rectTransform.anchoredPosition = data.pos;
        finalPos = data.pos;
        rectTransform.anchoredPosition += new Vector2(0,Screen.height*2);
        Flip(false);
        LeanTween.moveLocal(gameObject, finalPos, 0.7f).setEaseOutBack().setDelay(data.delay).setOnComplete(() =>
        {
            Flip(false);
            thisButton.interactable = true;
        });
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
            MoveToBottom();
            itemToCheckWith.MoveToBottom();
            SaveAndLoadDataManager.Instance.gameEvents.RaiseEvent(4);
        }
        else
        {
            SaveAndLoadDataManager.Instance.gameEvents.RaiseEvent(5);
            StartCoroutine(I_FlipCardBackToNormalState());
        }
    }
    public void MoveToBottom()
    {
        transform.SetAsLastSibling();
        LeanTween.moveLocal(gameObject, finalPos-new Vector2(0, Screen.height), 0.7f).setEaseOutBack().setDelay(0.25f).setOnComplete(() =>
        {
            thisButton.interactable = true;
        });
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

}
