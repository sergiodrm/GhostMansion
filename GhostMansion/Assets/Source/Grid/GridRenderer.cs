using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridLogic))]
public class GridRenderer : MonoBehaviour
{
    private GridLogic m_gridLogic;

    private void Start()
    {
        m_gridLogic = GetComponent<GridLogic>();


    }
}
