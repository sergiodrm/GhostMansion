using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Item pool flag
    public bool Active = false;

    // Item type
    public ItemType Type { get; private set; }


    public virtual void Init(ItemData itemData)
    {
        Type = itemData.Type;

        SpriteRenderer spriteComponent = GetComponent<SpriteRenderer>();
        if (spriteComponent)
        {
            spriteComponent.sprite = itemData.SpriteAsset;
        }
        else
        {
            Debug.LogError("Error to initialize item.");
        }
    }
}
