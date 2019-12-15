using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public GameObject backboard;
    public GameObject hoop;
    public bool bonus = false;
    public bool perfect = true;

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Collider>().enabled = false;
        if(bonus == true)
        {
            if (perfect == true)
            {
                GameManager.PlayerScore += 5;
            }
            else
            {
                GameManager.PlayerScore += 4; 
            }
        }
        else
        {
            if (perfect == true)
            {
                GameManager.PlayerScore += 3;            
            }
            else
            {
                GameManager.PlayerScore += 2;                
            }            
        }

        if (collision.gameObject != null)
        {
            Object.Destroy(collision.gameObject, 3f);  
        }        
    }    
}
