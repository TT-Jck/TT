//Script created by: http://Danim.TV

using UnityEngine;
using System.Collections;

// This is a script used in the Youtube video "RayCasting Script to detect sides of 2D collision in Unity. C#"
// Youtube Link - http://www.youtube.com/watch?v=glMs6qZOOV8

// If you download this file directly from Pastebin, remember to rename the file to "ShowGizmo.cs" Sometimes the name gets lowercase and this will cause errors in Unity.

//Apply this script to a gameobject to see its gizmo in the debug view
//I am not the author of this script


public class ShowGizmo : MonoBehaviour {
    public enum GIZMOS { ShowOnSelectedGizmo = 0, AlwaysShowGizmo = 1 }
    public GIZMOS showGizmos = GIZMOS.AlwaysShowGizmo;
    public float size = 0.5f;
    public Color color = Color.white;
    public bool show;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = color;
        if (showGizmos == GIZMOS.ShowOnSelectedGizmo)
            Gizmos.DrawWireSphere(transform.position, size);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = color;
        if (showGizmos == GIZMOS.AlwaysShowGizmo)
            Gizmos.DrawWireSphere(transform.position, size);
    }
}