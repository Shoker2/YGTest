using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public static class DataHolder
{
    public static Question[] questions;
    public static ResultData[] results;
    public static int[] ResultsTable;
} 

public class DH : MonoBehaviour {
    public Question[] questions;
    public ResultData[] results;

    public static void SaveProgress()
    {
        YandexGame.savesData.now_question = QuestController._nowQuestionID;

        for (int i = 0; i < DataHolder.questions.Length; i++)
        {
            YandexGame.savesData.questions_res_data[i] = DataHolder.questions[i].res;
        }
        YandexGame.SaveProgress();
    }

    private void Awake()
    {
        int[] a = new int[results[results.Length - 1].RightBorderValue + 1];
        int lastI = 0;
        int i = 0;
        for (; i < results.Length; i++)
            for (; lastI <= results[i].RightBorderValue; lastI++)
                a[lastI] = i;
        DataHolder.ResultsTable = a;

        DataHolder.results = results;

        Debug.Log("Question ID - " + YandexGame.savesData.now_question);
        QuestController._nowQuestionID = YandexGame.savesData.now_question;

        DataHolder.questions = questions;

        for (i = 0; i < DataHolder.questions.Length; i++)
            DataHolder.questions[i].res = YandexGame.savesData.questions_res_data[i];

        if (YandexGame.savesData.isFirstSession)
        {
            QuestController._nowQuestionID = 0;
            SaveProgress();
        }
    }
}
