using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static T[] GetAllInstances<T>() where T : ScriptableObject
    {
        //TODO: Fix?
        return Resources.LoadAll<T>("Scriptable Objects/Items");
    }
}
