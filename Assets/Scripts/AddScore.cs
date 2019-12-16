using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public GameObject backboard;
    public GameObject hoop;
    public bool bonus = false;
    public bool perfect = true;

    private void OnTriggerEnter(Collider collision)
    {
        GetComponent<Collider>().enabled = false;
        if(bonus == true)
        {
            if (perfect == true)
            {
                GameManager.playerScore += 5;
            }
            else
            {
                GameManager.playerScore += 4; 
            }
        }
        else
        {
            if (perfect == true)
            {
                GameManager.playerScore += 3;            
            }
            else
            {
                GameManager.playerScore += 2;                
            }            
        }     
    }    
}
