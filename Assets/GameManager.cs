using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public Text countText;
    public static int PlayerScore = 0;
    private void Start()
    {
        
        PlayerScore = 0;
    }
    private void Update()
    {
        ScoreUpdate();
    }

    public void ScoreUpdate()
    {
        countText.text = "SCORE: " + PlayerScore.ToString();
    }
}