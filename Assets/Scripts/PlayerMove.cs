using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Touch touch;
    public float touchSpeedModifier = 1;
    public float keyboardSpeedModifier = 3;
    public bool xAxisActive = true;
    public bool zAxisActive = true;
    private int xAxis = 0;
    private int zAxis = 0;
    [Tooltip("Player Top movement Limit")]
    public float topLimit = 19f;
    [Tooltip("Player Bottom movement Limit")]
    public float bottomLimit = 0.5f;
    [Tooltip("Player Left movement Limit")]
    public float leftLimit = 1.0f;
    [Tooltip("Player Right movement Limit")]
    public float rightLimit = 9.0f;

    //momentum calculation variables
    public float[] momentumArray  = new float[30];
    public float momentum = 0f;
    private int momentumIndex = 0;



    // Start is called before the first frame update
    void Start()
    {
        //disble movement on Z axis if it is not a debug build
        if (!Debug.isDebugBuild)
        {
            zAxis = 0;
        }
        if (zAxisActive) {
            zAxis = 1;
        }
        if (xAxisActive)
        {
            xAxis = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {

            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved) {

                transform.position = new Vector3(
                        transform.position.x + touch.deltaPosition.x * touchSpeedModifier * Time.deltaTime*xAxis,
                        transform.position.y,
                        transform.position.z + touch.deltaPosition.y * touchSpeedModifier * Time.deltaTime* zAxis
                    );

            }

        }
           
        //handle keybpoard input for debug purposes
        if (Input.GetKey("a"))
        {
            transform.position = new Vector3(
                       transform.position.x - keyboardSpeedModifier * Time.deltaTime * xAxis,
                       transform.position.y,
                       transform.position.z 
                   );
        }

        if (Input.GetKey("d"))
        {
            transform.position = new Vector3(
                       transform.position.x + keyboardSpeedModifier * Time.deltaTime * xAxis,
                       transform.position.y,
                       transform.position.z
                   );
        }
        if (Input.GetKey("w"))
        {
            transform.position = new Vector3(
                       transform.position.x,
                       transform.position.y,
                       transform.position.z + keyboardSpeedModifier * Time.deltaTime * zAxis
                   
                   );
        }
        if (Input.GetKey("s"))
        {
            transform.position = new Vector3(
                       transform.position.x,
                       transform.position.y,
                       transform.position.z - keyboardSpeedModifier * Time.deltaTime * zAxis
                   );
        }

        //check if player is still inbounds probably can be done using the unity engine but this seems easier on the performance side
        if (transform.position.x > rightLimit) {

            transform.position = new Vector3(
                       rightLimit,
                       transform.position.y,
                       transform.position.z
                   );

        }
        if (transform.position.x < leftLimit)
        {

            transform.position = new Vector3(
                       leftLimit,
                       transform.position.y,
                       transform.position.z
                   );

        }

        if (transform.position.z > topLimit)
        {

            transform.position = new Vector3(
                       transform.position.x,
                       transform.position.y,
                       topLimit
                   );

        }

        if (transform.position.z < bottomLimit)
        {

            transform.position = new Vector3(
                       transform.position.x,
                       transform.position.y,
                       bottomLimit
                   );

        }


    }

    private void FixedUpdate()
    {

        if ( momentumIndex >= 30) {
            momentumIndex = 0;
        }

        momentumArray[momentumIndex] = transform.position.x;
        momentumIndex++;

        float momentumSum = 0;
        for (int i = 0; i < momentumArray.Length; i ++) {

            momentumSum += momentumArray[i];

        }

        momentum = (momentumSum / momentumArray.Length) - transform.position.x;


    }
}
