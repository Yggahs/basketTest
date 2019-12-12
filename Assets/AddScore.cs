using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    private GameObject ball;
    private Collider hoop;
    private void Awake()
    {
        hoop = GetComponent<Collider>();
        ball = GameObject.FindGameObjectWithTag("ball");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            GameManager.PlayerScore += 3;
            Object.Destroy(ball, 3f);
        }
    }
}
