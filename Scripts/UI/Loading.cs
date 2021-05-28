using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour   //加载博物馆场景
{
    private Text txt_Progress;
    public string SceneName;

    private AsyncOperation ao;
    private bool isLoad = false;
    private void Awake()
    {
        txt_Progress = GetComponent<Text>();
        EventCenter.AddListener(EventDefine.SartLoadScene,StartLoad);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventDefine.SartLoadScene, StartLoad); //事件监听 移除
    }
    private void StartLoad()
    {
        gameObject.SetActive(true);
        StartCoroutine("Load");  //开启协程
    }
    IEnumerator Load()   //协程
    {
        int displayProgress = -1;
        int toProgress = 100;

        while (displayProgress<toProgress)
        {
            ++displayProgress;
            ShowProgress(displayProgress);

            if (isLoad == false)
            {
                ao = SceneManager.LoadSceneAsync(SceneName);   //异步加载  传入场景名字
                ao.allowSceneActivation = false;   //(一开始不加载，百分百加载)
                isLoad = true;
            }
            yield return new WaitForEndOfFrame();
        }
        if (displayProgress == 100)
        {
            ao.allowSceneActivation = true;
            StopCoroutine("Load");
        }
    }

    private void ShowProgress(int progress)
    {
        txt_Progress.text = progress.ToString()+"%";
    }
}
