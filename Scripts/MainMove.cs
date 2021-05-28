using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;



public class MainMove : VRTK_InteractTouch
{
    public GameObject vrCamPosition;
    public GameObject[] go = new GameObject[4];


    public void Awake()
    {
        //找到江宁织造button
        transform.Find("btn_jiangning").GetComponent<Button>().onClick.AddListener(
        () =>
        {
            //传送
            vrCamPosition.transform.localPosition = go[0].transform.position;
        });



    }
}
