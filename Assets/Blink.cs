using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public bool blinking = false;
    public GameObject scoreZone;
    // Start is called before the first frame update
    void Start()
    {
        chooseBlinking();
    }



    public void chooseBlinking()
    {
        if(Random.value > .5)
        {
          gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
          blinking = true;
          
          
        }
        else
        {
          gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
          blinking = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "ball")
        {
            Debug.Log("colputo");
            if (blinking == true)
            {
                scoreZone.GetComponent<AddScore>().bonus = true;
            }
        
        }
    }
}
