using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class ADSceneLoader : MonoBehaviour
{
    public static ADSceneLoader instance = null;
    private int _waitLoadScene = 0;
    private int _lostBeforAD;

    [Serialize] public int DelayAD = 0;
    [Serialize] public int ADSceneID;

    private void Awake()
    {
        if (instance == null ) instance = this;
        else Destroy( gameObject );

        DontDestroyOnLoad( gameObject );
        Initialize();
    }

    private void Initialize()
    {
        _lostBeforAD = DelayAD;
    }

    public static void LoadSceneWithoutAd(int SceneID)
    {
        SceneManager.LoadScene(SceneID);
    }
    public static void LoadExpectedScene()
    {
        LoadSceneWithoutAd(instance._waitLoadScene);
    }

    public static void LoadScene(int SceneID)
    {
        if (instance == null) {
            LoadSceneWithoutAd(SceneID);
            return;
        }

        instance._waitLoadScene = SceneID;

        if (instance._lostBeforAD < instance.DelayAD)
            instance._lostBeforAD++;

        Debug.Log(YandexGame.timerShowAd);
        Debug.Log(instance._lostBeforAD);

        if (YandexGame.timerShowAd >= YandexGame.Instance.infoYG.fullscreenAdInterval && instance._lostBeforAD >= instance.DelayAD)
        {
            instance._lostBeforAD = 0;
            LoadSceneWithoutAd(instance.ADSceneID);
        }
        else LoadSceneWithoutAd(SceneID);
    }
}
