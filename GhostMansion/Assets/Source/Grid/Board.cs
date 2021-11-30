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

public class Board : MonoBehaviour
{
    private GridContainer<Item> m_grid;
    private Transform m_transformComponent;

    private Vector2 m_cellSize;

    [Header("Grid settings")]
    [Min(1)]
    public int m_width = 1;
    [Min(1)]
    public int m_height = 1;
    public ItemManager m_itemManager;
    public Sprite m_itemSprite;

    private void Start()
    {
        // Get transform
        m_transformComponent = GetComponent<Transform>();

        // Create grid
        m_grid = new GridContainer<Item>(m_width, m_height);

        // Calculate cell size in world space
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Rect spriteRect = spriteRenderer.sprite.rect;
        float spritePixelsPerUnit = spriteRenderer.sprite.pixelsPerUnit;
        float spriteWorldWidth = spriteRect.width / spritePixelsPerUnit;
        float spriteWorldHeight = spriteRect.height / spritePixelsPerUnit;
        m_cellSize = new Vector2(spriteWorldWidth / (float)m_width, spriteWorldHeight / (float)m_height);

        // Fill the board
        for (int row = 0; row < m_height; ++row)
        {
            for (int col = 0; col < m_width; ++col)
            {
                Item item = m_itemManager.ActivateRandomItem();
                GameObject itemObject = item.gameObject;
                itemObject.transform.localPosition = ProjectCoordToWorld(row, col);
                m_grid.Set(row, col, item);
            }
        }
    }

    private Vector3 ProjectCoordToWorld(int row, int col)
    {
        Vector3 worldOffset = m_cellSize * 0.5f;
        worldOffset -= new Vector3(m_cellSize.x * m_width * 0.5f, m_cellSize.y * m_height * 0.5f);
        Vector3 worldPosition = new Vector3((float)col * m_cellSize.x, (float)row * m_cellSize.y);
        worldPosition += worldOffset;
        return worldPosition;
    }

}
