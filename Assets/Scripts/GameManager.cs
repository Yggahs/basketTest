using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;   

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public Text timerText;
    public static int playerScore = 0;
    float resetTimer = 5f;
    public static float timeLimit = 60f;
    private void Start()
    {
        timeLimit = 60f;
        playerScore = 0;
    }
    private void Update()
    {
        
        uiUpdate();
        countDown();
    }

    public void uiUpdate()
    {
        scoreText.text = "SCORE: " + playerScore.ToString();
        timerText.text = timeLimit.ToString("0.0");

    }

    void resetScene(){
        if(player.thrown == false){
            resetTimer -= Time.deltaTime;
            if(resetTimer <= 0){
                SceneManager.LoadScene(1);
            }
        }
    }

    void countDown(){
        if(timeLimit>0)
            timeLimit -= Time.deltaTime;
        else
            SceneManager.LoadScene(2);
    }
}