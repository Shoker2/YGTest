using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultViewer : MonoBehaviour
{
    public TextMeshProUGUI Title;
    public Image img;

    private void Awake()
    {
        int res = 0;
        foreach (Question i in DataHolder.questions)
            res += i.res;

        Debug.Log(res);

        int ResultIndex = DataHolder.ResultsTable[res];

        Title.text = Title.text.Replace("{name}", DataHolder.results[ResultIndex].Title);
        img.sprite = DataHolder.results[ResultIndex].Image;

        QuestController._nowQuestionID = 0;
        DH.SaveProgress();
    }
}
