using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public Item[] Items;

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
}
