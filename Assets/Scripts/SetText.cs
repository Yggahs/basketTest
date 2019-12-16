using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;   

public class SetText : MonoBehaviour
{
    public Text scoreText;
    public Text rewardsText;
    // Start is called before the first frame update
    void Start()
    {
        int reward = (int)((GameManager.playerScore / 10) * 2);
        scoreText.text = "Final score: " + GameManager.playerScore.ToString();
        rewardsText.text = "Rewards: " + reward.ToString(); 
    }

    public void restartGame(){
        Application.LoadLevel(1);
    }
    public void closeGame(){
        Application.Quit();
    }
}
