using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopLogic : MonoBehaviour
{
    public GameObject scoreZone;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            scoreZone.GetComponent<AddScore>().perfect = false;
        }
    }
}
