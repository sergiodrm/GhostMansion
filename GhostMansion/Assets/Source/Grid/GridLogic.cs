using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int m_width;
    private int m_height;
    private int m_size;
    private int[] m_data;

    public Grid(int width, int height)
    {
        m_width = width;
        m_height = height;
        m_size = width * height;
        m_data = new int[m_size];
    }

    public int Size()
    {
        return m_size;
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
