using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public Item[] Items;

    public Item CurrentItem;

    private float timer;

    private void Awake()
    {
        Instance = this;

        //Items = Utils.GetAllInstances<Item>(); //doesn't fill the list with anything for some reason idk
        //Items = Items.OrderBy(p => p.Id).ToArray();

        foreach(Item item in Items)
        {
            Debug.Log(item.Name);
        }
    }

    private void Start()
    {
        string currentItemName = PlayerPrefs.GetString("lastCraft", "lightitem");
        CurrentItem = GetItem(currentItemName);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            IncrementItem(CurrentItem);
            timer -= 1f;
        }
    }

    private Item GetItem(string itemName)
    {
        foreach(Item item in Items)
        {
            if(item.name.ToLower() == itemName.ToLower())
            {
                return item;
            }
            Debug.LogError("Unable to get item of string" + itemName);
        }
        return null;
    }

    public void SetCurrentItem(Item item)
    {
        CurrentItem = item;
    }

    public static void IncrementItem(Item item)
    {
        item.Quantity += item.PerSecond;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("lastCraft", CurrentItem.Name.ToLower());
    }
}
