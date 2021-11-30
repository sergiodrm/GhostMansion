using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridContainer<T>
{
    private int m_width;
    private int m_height;
    private int m_size;
    private T[] m_data;

    public GridContainer(int width, int height)
    {
        m_width = width;
        m_height = height;
        m_size = width * height;
        m_data = new T[m_size];
    }

    public int Size()   { return m_size; }
    public int Width()  { return m_width; }
    public int Height() { return m_height; }

    public T Get(int index)
    {
        return m_data[index];
    }

    public T Get(int row, int column)
    {
        int index = CoordToIndex(row, column);
        return Get(index);
    }

    public void Set(int index, T value)
    {
        m_data[index] = value;
    }

    public void Set(int row, int column, T value)
    {
        int index = CoordToIndex(row, column);
        Set(index, value);
    }

    public bool IsValid(int index)
    {
        return index < Size();
    }

    public bool IsValid(int row, int column)
    {
        return CoordToIndex(row, column) < Size();
    }

    public int CoordToIndex(int row, int column)
    {
        return row * m_width + column;
    }

    public Vector2Int IndexToCoord(int index)
    {
        return new Vector2Int(index / m_width, index % m_width);
    }
}

public class ItemGrid : MonoBehaviour
{
    private GridContainer<Item> m_grid;
    private Transform m_transformComponent;

    private float m_spriteWorldWidth;
    private float m_spriteWorldHeight;

    [Header("Grid settings")]
    [Min(1)]
    public int m_width = 1;
    [Min(1)]
    public int m_height = 1;
    public ItemManager m_itemManager;
    public Sprite m_itemSprite;

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Rect spriteRect = spriteRenderer.sprite.rect;
        float spritePixelsPerUnit = spriteRenderer.sprite.pixelsPerUnit;

        m_spriteWorldWidth = spriteRect.width / spritePixelsPerUnit;
        m_spriteWorldHeight = spriteRect.height / spritePixelsPerUnit;
        Vector2 rectSize = new Vector2(m_spriteWorldWidth / (float)m_width, m_spriteWorldHeight / (float)m_height);

        float spriteWidth = m_itemSprite.rect.width / m_itemSprite.pixelsPerUnit;
        float spriteHeight = m_itemSprite.rect.height / m_itemSprite.pixelsPerUnit;

        // Get transform
        m_transformComponent = GetComponent<Transform>();

        // Create grid
        m_grid = new GridContainer<Item>(m_width, m_height);
        
        Vector3 worldOffset = m_transformComponent.position;
        worldOffset -= new Vector3(m_spriteWorldWidth * 0.5f, m_spriteWorldHeight * 0.5f, 0.0f);
        worldOffset += new Vector3(rectSize.x, rectSize.y, 0.0f);
        for (int row = 0; row < m_height; ++row)
        {
            for (int col = 0; col < m_width; ++col)
            {
                Item item = m_itemManager.ActivateRandomItem();
                GameObject itemObject = item.gameObject;
                Vector3 position = new Vector3((float)col * rectSize.x, (float)row * rectSize.y);
                position += worldOffset;
                itemObject.transform.localPosition = position;
                m_grid.Set(row, col, item);
            }
        }
        Debug.Log("World offset: " + worldOffset);
        Debug.Log("Item size in grid: " + rectSize);
    }


}
