using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCreator : MonoBehaviour
{
    [SerializeField] private GameObject resourcePrefab;
    [SerializeField] private Transform resourceContainer;
    [SerializeField] private Sprite lockIcon;

    private void Start()
    {
        StartCoroutine(CreateInventory());
    }

    IEnumerator CreateInventory()
    {
        yield return new WaitForEndOfFrame();

        foreach (Item item in ItemManager.Instance.Items)
        {
            GameObject instance = Instantiate(resourcePrefab, resourceContainer);
            instance.name = item.name;
            ResourceItem inventoryItem = instance.GetComponent<ResourceItem>();
            inventoryItem.Item = item;

            inventoryItem.CreateResourceButton.gameObject.SetActive(item.CanCreate);
            if (item.CanCreate)
            {
                SetButtonOnClickFunction(inventoryItem.CreateResourceButton, item);
            }

            if (item.IsLocked)
            {
                inventoryItem.IconRender.sprite = lockIcon;
            }
            else
            {
                inventoryItem.IconRender.sprite = item.Icon;
            }
        }
    }

    private void SetButtonOnClickFunction(Button button, Item item)
    {
        button.onClick.AddListener(delegate { SetCreateResource(item); });
    }

    private void SetCreateResource(Item item)
    {
        ItemManager.Instance.SetCurrentItem(item);
    }
}
