using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This is a script used in the Youtube video "RayCasting Script to detect sides of 2D collision in Unity. C#"
// Youtube Link - http://www.youtube.com/watch?v=glMs6qZOOV8

// If you download this file directly from Pastebin, remember to rename the file to "ExtensionMethods.cs" Sometimes the name gets lowercase and this will cause errors in Unity.

internal static class ExtensionMethods
{
    // ------------------------------------------
    // Unity Extensions
    // ------------------------------------------

    //get list of children
    public static List<GameObject> GetChildren(this GameObject go)
    {

        List<GameObject> children = new List<GameObject>();

        foreach (Transform tran in go.transform)
        {

            children.Add(tran.gameObject);

        }

        return children;

    }

}