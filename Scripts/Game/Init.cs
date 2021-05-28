using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    private void Awake()
    {
        GameObject go = Resources.Load<GameObject>(PlayerPrefs.GetString("CharacterName"));
        Instantiate(go);
    }


}
