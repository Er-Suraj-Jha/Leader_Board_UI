using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Getter : MonoBehaviour
{
   public  int score=0;
    void Start()
    {
       // TextMeshProUGUI score_text=gameObject.GetComponent<TextMeshProUGUI>();
       // int.TryParse(score_text.text, out score);
    }

    public void Set_Score(int Score)
    { 
        score=Score;

    }

    public int Get_Score()
    {
        return score;
    }

}
