using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Item pool flag
    public bool Active = false;

    // Item type
    public ItemType Type { get; private set; }

    /**
     * Unity events
     */
    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }

    /**
     * Public methods
     */
    public virtual void Init(ItemData itemData)
    {
        Type = itemData.Type;
        Active = false;

        SpriteRenderer spriteComponent = GetComponent<SpriteRenderer>();
        if (spriteComponent)
        {
            spriteComponent.sprite = itemData.SpriteAsset;
            spriteComponent.color = itemData.SpriteColor;
        }
        else
        {
            Debug.LogError("Error to initialize item.");
        }
    }

    public virtual void OnCombine()
    {

    }
}
