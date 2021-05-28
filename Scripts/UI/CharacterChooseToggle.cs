using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChooseToggle : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(OnValueChanged);
    }

    private void Start()
    {
        OnValueChanged(GetComponent<Toggle>().isOn);
    }

    private void OnValueChanged(bool value)
    {
        transform.GetChild(0).gameObject.SetActive(value);
        if (value)
        {
            EventCenter.Broadcast(EventDefine.OnCharacterChoose, gameObject.name);
        }
    }
}
