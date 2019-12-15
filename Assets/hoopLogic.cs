using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoopLogic : MonoBehaviour
{
    public GameObject scoreZone;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            scoreZone.GetComponent<AddScore>().perfect = false;
            //if (collision.gameObject != null)
            //{
              //  Object.Destroy(collision.gameObject, 3f);
            //&}
        }
    }
}
