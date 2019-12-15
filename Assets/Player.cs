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

    public Camera secondCamera;
    public Camera firstCamera;

    public Slider slider;

    public float h = 25;
    public float gravity = -18;
    public float playerInput = 0;

    public bool thrown = false;

    Vector2 startPos, endPos;
    public Vector2 direction;
    float touchTimeStart, touchTimeFinish, timeInterval;
    [Range(0.0f, 1.0f)]
    public float throwForce = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.FindGameObjectWithTag("slider").GetComponent<Slider>();
        createBall();
        Physics.gravity = Vector3.up * gravity;
        firstCamera.enabled = true;
        secondCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = slider.value;
        throwBall();
        createBall();
       
    }
    void createBall()
    {
        if (ball == null)
        {
            ball = Instantiate(ballInstance, new Vector3(0.5f, 1, -5), Quaternion.identity);
            ball.transform.parent = gameObject.transform;
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
        float displacementY = scoreZone.transform.position.y - ball.transform.position.y + playerInput;
        Vector3 displacementXZ = new Vector3(scoreZone.transform.position.x - ball.transform.position.x,0, scoreZone.transform.position.z - ball.transform.position.z);

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
                direction = startPos - endPos;
                throwForce = direction.magnitude / 1000;
                slider.value = throwForce;
                playerInput = throwForce;

                if (ball.GetComponent<Rigidbody>().useGravity)
                {
                    ball.GetComponent<Rigidbody>().velocity = CalculateVelocity();
                }
                thrown = true;
            }
            StartCoroutine(cameraControl());
        }
        //Debug.Log(direction.magnitude / 1000);
    }

    IEnumerator cameraControl()
    {
       
        if (thrown == true)
        {
            yield return new WaitForSeconds(1.65f);
            secondCamera.enabled = true;
            firstCamera.enabled = false;
        }
        else
        {
            firstCamera.enabled = true;
            secondCamera.enabled = false;
        }
        yield break;
    }
     
}
