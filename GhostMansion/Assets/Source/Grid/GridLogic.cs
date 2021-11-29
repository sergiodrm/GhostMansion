using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int m_width { get; private set; }
    public int m_height { get; private set; }
    public List<int> m_data { get; private set; }

    public Grid(int width, int height)
    {
        m_width = width;
        m_height = height;
        m_data = new List<int>(width * height);
    }

    public int Get(int index)
    {
        return m_data[index];
    }

    public int Get(int row, int column)
    {
        int index = CoordToIndex(row, column);
        return Get(index);
    }

    public void Set(int index, int value)
    {
        m_data[index] = value;
    }

    public void Set(int row, int column, int value)
    {
        int index = CoordToIndex(row, column);
        Set(index, value);
    }

    public int CoordToIndex(int row, int column)
    {
        return row * m_width + column;
    }
}

public class GridLogic : MonoBehaviour
{
    private Grid m_grid;

    [Min(1)]
    public int m_width;
    [Min(1)]
    public int m_height;


    private void Start()
    {
        // Create grid
        m_grid = new Grid(m_width, m_height);
        // TODO: Fill it 
    }
}
