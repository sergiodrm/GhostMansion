using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private SpriteRenderer SpriteComponent;

    public void Awake()
    {
        SpriteComponent = GetComponent<SpriteRenderer>();
    }
}
