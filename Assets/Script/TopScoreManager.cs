using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class TopScoreManager : MonoBehaviour
{
    public TextMeshProUGUI top1ScoresText;
    private int HS, numHS;
    public List<int> arrHS;
    void Start()
    {
        // numHS = 5;
        // arrHS[0] = PlayerPrefs.GetInt("HighScore0");
        // arrHS[1] = PlayerPrefs.GetInt("HighScore1");
        // arrHS[2] = PlayerPrefs.GetInt("HighScore2");
        // arrHS[3] = PlayerPrefs.GetInt("HighScore3");
        // arrHS[4] = PlayerPrefs.GetInt("HighScore4");
        // HS = arrHS[numHS - 4];
        HS = PlayerPrefs.GetInt("HighScore");
        top1ScoresText.text = "" + HS.ToString("n0");
                                // + arrHS[1].ToString("n0")
                                // + arrHS[2].ToString("n0")
                                // + arrHS[3].ToString("n0")
                                // + arrHS[4].ToString("n0");
}
    void Update() 
    {

    }
}
