using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private GameObject ball;
    public GameObject backboard;
    public GameObject ballInstance;
    public GameObject scoreZone;
    public GameObject hoop;

    

    public Slider slider;

    public float h = 25;
    public float gravity = -18;
    public float playerInput = 0;

    public static bool thrown = false;

    Vector2 startPos, endPos;
    public Vector3 direction;
    float touchTimeStart, touchTimeFinish, timeInterval;
    [Range(0.0f, 1.0f)]
    public float throwForce = 0.0f;
    private void Awake()
    {
        backboard = GameObject.FindGameObjectWithTag("backBoard");
        scoreZone = GameObject.FindGameObjectWithTag("scoreZone");
        hoop = GameObject.FindGameObjectWithTag("hoop");
        slider = GameObject.FindGameObjectWithTag("slider").GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        createBall();
        Physics.gravity = Vector3.up * gravity;
        
    }
    // Update is called once per frame
    void Update()
    {
        throwBall();
        createBall();     
    }
    void createBall()
    {
        if (ball == null)
        {
            ball = Instantiate(ballInstance, new Vector3(gameObject.transform.position.x+0.5f, gameObject.transform.position.y+0.05f, gameObject.transform.position.z+ 0.5f), Quaternion.identity,gameObject.transform);
            ball.GetComponent<Rigidbody>().useGravity = false;
            thrown = false;
            scoreZone.GetComponent<MeshCollider>().enabled = true; 
            backboard.GetComponent<Blink>().chooseBlinking();
            scoreZone.GetComponent<AddScore>().perfect = true;
            scoreZone.GetComponent<AddScore>().bonus = false;
        }
    }
    Vector3 CalculateVelocity()
    { 
        float displacementY = scoreZone.transform.position.y - ball.transform.position.y;
        Vector3 displacementXZ = new Vector3(scoreZone.transform.position.x - ball.transform.position.x,0, (scoreZone.transform.position.z - ball.transform.position.z) /* playerInput*/);
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity));
        return velocityXZ+velocityY;
    }

    void throwBall()
    {
        if (!thrown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchTimeStart = Time.time;
                startPos = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                ball.GetComponent<Rigidbody>().useGravity = true;
                touchTimeFinish = Time.time;
                timeInterval = touchTimeFinish - touchTimeStart;
                endPos = Input.mousePosition;
                direction = (endPos - startPos)/timeInterval;
                Vector3 swipeZ = new Vector3(0,0,direction.y);
                slider.value = swipeZ.magnitude / 3000f;
               
                if (ball.GetComponent<Rigidbody>().useGravity)
                {
                    ball.transform.parent = null;
                    ball.GetComponent<Rigidbody>().AddForce(CalculateVelocity().normalized * (swipeZ.magnitude/3f));
                    Debug.Log(slider.value);
                }
                thrown = true;
            }
        }
        else{
            Destroy(ball,4f);
        }
    }
}
