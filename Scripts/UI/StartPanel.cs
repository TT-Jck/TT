using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    private string m_CharacterName= "malcolm";
    //private GameObject vrController;
    private void Awake()
    {
        //vrController = GetComponent<GameObject>();
        transform.Find("bbt_CharacterChose").GetComponent<Button>().onClick.AddListener(
            () =>
            {
                EventCenter.Broadcast(EventDefine.IsShowCharacterChoosePanel,true);
                Show(false);
            });
        transform.Find("bbt_Start").GetComponent<Button>().onClick.AddListener(
            () =>
            {
                Show(false);   //隐藏场景
                EventCenter.Broadcast(EventDefine.SartLoadScene);
                PlayerPrefs.SetString("CharacterName", m_CharacterName);
            }
            );
        EventCenter.AddListener<bool>(EventDefine.IsShowCharacterChoosePanel, Show);
        EventCenter.AddListener<string>(EventDefine.OnCharacterChoose,ChooseCharacter);
    }
    private void OnDestroy()
    {

        EventCenter.RemoveListener<bool>(EventDefine.IsShowCharacterChoosePanel, Show);
        EventCenter.RemoveListener<string>(EventDefine.OnCharacterChoose, ChooseCharacter);
    }

    private void Show(bool value)
    {
        gameObject.SetActive(value);
    }

    private void ChooseCharacter(string characterName)
    {
        m_CharacterName = characterName;
    }
}
