using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject ball;
    public GameObject target;
    public Slider slider;
    private float barMax = 10f;
    private float currentBar = 0;

    public float h = 25;
    public float gravity = -18;
    // Start is called before the first frame update
    private void Awake()
    {
       slider = GameObject.FindGameObjectWithTag("slider").GetComponent<Slider>();
    }
    void Start()
    {
        ball.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        throwBall();
    }

    void throwBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Physics.gravity = Vector3.up*gravity;
            ball.GetComponent<Rigidbody>().useGravity = true;
            if (ball.GetComponent<Rigidbody>().useGravity)
            {
                ball.GetComponent<Rigidbody>().velocity = CalculateVelocity();
            }
        }
    }

    Vector3 CalculateVelocity()
    {
        float displacementY = target.transform.position.y - ball.transform.position.y;
        Vector3 displacementXZ = new Vector3(target.transform.position.x - ball.transform.position.x,0,target.transform.position.z - ball.transform.position.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity));
        return velocityXZ+velocityY;
    }
}
