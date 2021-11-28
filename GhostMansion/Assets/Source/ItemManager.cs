using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Spider,
    Ghost,
    Monster,
    Skull
}

[System.Serializable]
public class ItemSpecification
{
    public ItemType Type;
    public Sprite Image;
}

public class ItemManager : Singleton
{
    // An array to store the different types of items with their properties.
    public ItemSpecification[] ItemData;

    private List<Item> Items;

    public Sprite GetSpriteFromType(ItemType type)
    {
        for (int index = 0; index < ItemData.Length; ++index)
        {
            if (ItemData[index].Type == type)
            {
                return ItemData[index].Image;
            }
        }
        return null;
    }
}
