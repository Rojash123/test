using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] GameEventSO gameEvents;
    [SerializeField] CardItem cardPrefab;
    [SerializeField] RectTransform cardSpawnHolder;
    [SerializeField] GridLayoutGroup gridLayout;
    [SerializeField] IconSO icons;

    private List<CardItem> cardsList=new List<CardItem>();
    private List<Vector2> cardPositions=new List<Vector2>();
    private Vector2 cardSize;

    private void Awake()
    {
        gameEvents.OnGameStart += GridLayoutSizeAdjustment;
    }
    private void OnDestroy()
    {
        gameEvents.OnGameStart -= GridLayoutSizeAdjustment;
    }
    private void Start()
    {
        GridLayoutSizeAdjustment();
    }
    private void GridLayoutSizeAdjustment()
    {
        int rowCount = LevelDataHolder.Instance.LevelSODatas[SaveAndLoadDataManager.Instance.currentSelectedLevel].totalRows;
        int columnCount = LevelDataHolder.Instance.LevelSODatas[SaveAndLoadDataManager.Instance.currentSelectedLevel].totalColumns;

        float actualWidth = cardSpawnHolder.GetComponent<RectTransform>().rect.size.x;
        float actualHeight = cardSpawnHolder.GetComponent<RectTransform>().rect.size.y;

        actualWidth = actualWidth - gridLayout.padding.left - gridLayout.padding.right;
        actualHeight = actualHeight - gridLayout.padding.top - gridLayout.padding.bottom;

        float width = (actualWidth - (columnCount - 1) * gridLayout.spacing.x) / columnCount;
        float height = (actualHeight - (rowCount - 1) * gridLayout.spacing.y) / rowCount;
        cardSize = new Vector2(width, height);

        for (int i = 0; i < rowCount * columnCount; i++)
        {
            cardPositions.Add(GetCenteredCellPosition(i,columnCount,rowCount));
        }
        SpawnCards(rowCount*columnCount);
    }
    private Vector2 GetCenteredCellPosition(int index, int columns, int rows)
    {
        int col = index % columns;
        int row = index / columns;

        float gridWidth =
            columns * cardSize.x + (columns - 1) * gridLayout.spacing.x;

        float gridHeight =
            rows * cardSize.y + (rows - 1) * gridLayout.spacing.y;

        float startX = -gridWidth * 0.5f + cardSize.x * 0.5f;
        float startY = gridHeight * 0.5f - cardSize.y * 0.5f;

        float x = startX + col * (cardSize.x + gridLayout.spacing.x);
        float y = startY - row * (cardSize.y + gridLayout.spacing.y);

        return new Vector2(x, y);
    }
    private void SpawnCards(int totalItemsCount)
    {
        cardsList.Clear();
        float delay = 0.5f;
        for (int i = 0; i < totalItemsCount; i++)
        {
            CardItem item = Instantiate(cardPrefab, cardSpawnHolder);
            CardData data = new CardData(cardSize, cardPositions[i],icons.GetSprite(0), 0, delay);
            item.SetData(data);
            cardsList.Add(item);
            delay += 0.1f;
        }
    }

}
