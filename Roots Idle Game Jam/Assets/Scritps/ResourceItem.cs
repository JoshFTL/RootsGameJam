using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceItem : MonoBehaviour
{
    public Button CreateResourceButton;
    public SpriteRenderer IconRender;
    public TextMeshProUGUI QuantityText;
    [HideInInspector] public Item Item;

    private void OnEnable()
    {
        StartCoroutine(SetQuantity());
    }

    IEnumerator SetQuantity()
    {
        yield return new WaitForEndOfFrame();
        QuantityText.text = Item.Quantity.ToString();
    }
}
