using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using YG;

public class QuestController : MonoBehaviour
{
    public string TitleText;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI QuestionTitle;
    public TextMeshProUGUI BtnText1;
    public TextMeshProUGUI BtnText2;
    public TextMeshProUGUI BtnText3;
    public TextMeshProUGUI BtnText4;
    public GameObject panel;

    public static int _nowQuestionID = 0;

    private void Start()
    {
        SetUpQuestion(DataHolder.questions[_nowQuestionID]);
    }

    public void SetUpQuestion(Question quest)
    {
        string temp = TitleText;
        temp = temp.Replace("{now}", (_nowQuestionID + 1).ToString());
        temp = temp.Replace("{total}", DataHolder.questions.Length.ToString());

        Title.text = temp;
        QuestionTitle.text = quest.Title;
        BtnText1.text = quest.Answer1;
        BtnText2.text = quest.Answer2;
        BtnText3.text = quest.Answer3;
        BtnText4.text = quest.Answer4;
    }

    public static void OpenResultScene()
    {
        SceneManager.LoadScene(1);
    }

    public void NextQuestion(int res)
    {
        DataHolder.questions[_nowQuestionID].res = res;
        _nowQuestionID++;

        // Debug.Log(YandexGame.timerShowAd);
        if (DataHolder.questions.Length <= _nowQuestionID)
        {
            _nowQuestionID = DataHolder.questions.Length - 1;
            /*panel.SetActive(false);
            if (YandexGame.timerShowAd >= YandexGame.Instance.infoYG.fullscreenAdInterval)
            {
                YandexGame.FullscreenShow();
            }
            else OpenResultScene();*/

            OpenResultScene();
        }
        else
        {
            SetUpQuestion(DataHolder.questions[_nowQuestionID]);
        }

        DH.SaveProgress();
    }

    public void PrewQuestion()
    {
        _nowQuestionID--;
        if (_nowQuestionID < 0) _nowQuestionID = 0;
        SetUpQuestion(DataHolder.questions[_nowQuestionID]);

        DH.SaveProgress();
    }
}
[Serializable]
public class Question
{
    public string Title;
    public string Answer1;
    public string Answer2;
    public string Answer3;
    public string Answer4;

    [NonSerialized] public int res = 0;
}

[Serializable]
public class ResultData
{
    public string Title;
    public int RightBorderValue;
    public Sprite Image;
}