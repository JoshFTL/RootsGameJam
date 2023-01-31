using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newItem", menuName = "Scriptable Objects/Items")]
public class Item : ScriptableObject
{
    public string Name;
    public string Id;
    public bool CanCreate;
    public Sprite Icon;
    public bool IsLocked;
    public int Quantity;
    public int PerSecond;
    public int PerClick;
}