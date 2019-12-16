using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;   

public class GameManager : MonoBehaviour
{
    public GameObject pos1, pos2, pos3,target;
    GameObject[] positions = new GameObject[3];
    public Player player;
    public GameObject playerInstance;
    public Text scoreText,timerText;
    public static int playerScore = 0;
    float resetTimer = 1.65f;
    public static float timeLimit = 60f;
    public  Camera secondCamera;
    public  Camera firstCamera;
    private void Start()
    {
        positions[0] = pos1;
        positions[1] = pos2;
        positions[2] = pos3;
        timeLimit = 60f;
        playerScore = 0;
        firstCamera.enabled = true;
        secondCamera.enabled = false;
        OnLevelWasLoaded(1);
    }
    private void Update()
    {
        
        uiUpdate();
        countDown();
        if (Player.thrown == true)
        {
            StartCoroutine(cameraControl());

        }
        else
        {
            StopAllCoroutines();
            firstCamera.enabled = true;
            secondCamera.enabled = false;
        }
    }

    public void uiUpdate()
    {
        scoreText.text = "SCORE: " + playerScore.ToString();
        timerText.text = timeLimit.ToString("0.0");

    }

    void countDown(){
        if(timeLimit>0)
            timeLimit -= Time.deltaTime;
        else
            SceneManager.LoadScene(2);
    }

    private void OnLevelWasLoaded(int level)
    {
        int i = Random.Range(0, positions.Length);
        Vector3 chosenPos = positions[i].transform.position;
        player = Instantiate(player,chosenPos,Quaternion.identity);
        player.transform.LookAt(new Vector3(target.transform.position.x, player.transform.position.y, target.transform.position.z));
        firstCamera.transform.parent = player.transform;
        firstCamera.transform.localPosition = new Vector3(0, 2f, -3f);
        firstCamera.transform.localRotation = new Quaternion(0, 0, 0,0);
      
    }

    void choosePos()
    {
        int i = Random.Range(0, positions.Length);
        Vector3 chosenPos = positions[i].transform.position;
        player.transform.position = chosenPos;
        player.transform.LookAt(new Vector3(target.transform.position.x, player.transform.position.y, target.transform.position.z));
        Debug.Log(i);
    }

    public IEnumerator cameraControl()
    {
        if (Player.thrown == true)
        {
            yield return new WaitForSeconds(1.65f);
            secondCamera.enabled = true;
            firstCamera.enabled = false;
            choosePos();
        }
        yield break;
    }
}