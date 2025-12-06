using UnityEngine;

public struct CardData
{
    public Vector2 size { get; private set;}
    public Vector2 Pos { get; private set;}
    public Sprite icon{ get; private set; }
    public int itemValue{ get; private set; }
    public float delay { get; private set; }
    public CardData(Vector2 size, Vector2 pos, Sprite icon, int itemValue,float delay)
    {
        this.size = size;
        Pos = pos;
        this.icon = icon;
        this.itemValue = itemValue;
        this.delay = delay;
    }
}
