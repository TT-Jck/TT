using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuseChoosePanel : MonoBehaviour
{
    public GameObject vrCamPosition;
    public GameObject []go = new GameObject[3];


    public void Awake()
    {
        //找到江宁织造button
        transform.Find("btn_jiangning").GetComponent<Button>().onClick.AddListener(
        () =>{
        EventCenter.Broadcast(EventDefine.OnMuseChoose, true);
        Show(false);
        vrCamPosition.transform.localPosition = go[0].transform.position;
        });
        EventCenter.AddListener<bool>(EventDefine.OnMuseChoose, Show);
        //找到云锦button
        transform.Find("btn_yunjin").GetComponent<Button>().onClick.AddListener(
        () => {
            EventCenter.Broadcast(EventDefine.OnMuseChoose, true);
            Show(false);
            vrCamPosition.transform.localPosition = go[1].transform.position;
        });
        EventCenter.AddListener<bool>(EventDefine.OnMuseChoose, Show);
        //找到红楼button
        transform.Find("btn_honglou").GetComponent<Button>().onClick.AddListener(
        () => {
            EventCenter.Broadcast(EventDefine.OnMuseChoose, true);
            Show(false);
            vrCamPosition.transform.localPosition = go[2].transform.position;
        });
        EventCenter.AddListener<bool>(EventDefine.OnMuseChoose, Show);
        //找到园林button
        transform.Find("btn_yuanlin").GetComponent<Button>().onClick.AddListener(
        () => {
            EventCenter.Broadcast(EventDefine.OnMuseChoose, true);
            Show(false);
            vrCamPosition.transform.localPosition = go[3].transform.position;
        });
        EventCenter.AddListener<bool>(EventDefine.OnMuseChoose, Show);
    }


    private void OnDestroy()
    {
        EventCenter.RemoveListener<bool>(EventDefine.OnMuseChoose, Show);
    }
    private void Show(bool value)
    {
        gameObject.SetActive(value);
    }
}
