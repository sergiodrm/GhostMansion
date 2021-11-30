using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

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

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public bool IsActive()
    {
        return gameObject.activeInHierarchy;
    }
    
    public virtual void OnCombine()
    {

    }
}
