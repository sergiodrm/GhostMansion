using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Spider, 
    Bat, 
    Skull, 
    Ghost,
    Max
}

[System.Serializable]
public class ItemData
{
    public ItemType Type;
    public Sprite SpriteAsset;
    public Color SpriteColor = Color.white;
}

public class ItemManager : Singleton
{
    /**
     * Properties
     */
    [Range(0, 100)]
    public int InitialPoolSize = 20;
    
    public GameObject m_itemsParentGameObject;
    public GameObject ItemPrefab;
    public ItemData[] ItemPrefabAssets;

    private Dictionary<ItemType, List<Item>> Items;

    /**
     * Unity events
     */
    public override void Awake()
    {
        base.Awake();

        Items = new Dictionary<ItemType, List<Item>>();

        // Instantiate item pools
        for (int index = 0; index < ItemPrefabAssets.Length; ++index)
        {
            List<Item> items = CreateItemPool(ItemPrefabAssets[index]);
            Items.Add(ItemPrefabAssets[index].Type, items);
        }
    }

    /**
     * Public methods
     */
    public Item ActivateItem(ItemType type)
    {
        List<Item> items = Items[type];
        for (int index = 0; index < items.Count; ++index)
        {
            if (!items[index].IsActive())
            {
                items[index].Activate();
                return items[index];
            }
        }
        return null;
    }

    public Item ActivateRandomItem()
    {
        ItemType type = (ItemType)Random.Range(0, (int)ItemType.Max);
        return ActivateItem(type);
    }

    public void DeactiveItem(Item item)
    {
        item.Deactivate();
    }

    /**
     * Private methods
     */
    private List<Item> CreateItemPool(ItemData itemData)
    {
        List<Item> items = new List<Item>();
        for (int index = 0; index < InitialPoolSize; ++index)
        {
            GameObject newItem = Instantiate(ItemPrefab);
            Item item = newItem.GetComponent<Item>();
            item.Init(itemData);
            item.Deactivate();
            items.Add(item);
            if (m_itemsParentGameObject)
            {
                newItem.transform.parent = m_itemsParentGameObject.transform; 
            }
        }
        return items;
    }

}
