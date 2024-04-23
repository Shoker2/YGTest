using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class MainADScene : MonoBehaviour
{
    public float TimeWaitAD = 1.0f;
    public float TimeWaitOpenScene = 0.5f;
    void Start()
    {
        StartCoroutine(WaitOpenAD());
    }

    public void AfterCloseAD()
    {
        StartCoroutine(WaitOpenScene());
    }

    IEnumerator WaitOpenAD()
    {
        yield return new WaitForSeconds(TimeWaitAD);
        YandexGame.FullscreenShow();
    }

    IEnumerator WaitOpenScene()
    {
        yield return new WaitForSeconds(TimeWaitOpenScene);
        ADSceneLoader.LoadExpectedScene();
    }
}
