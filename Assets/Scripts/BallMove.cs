using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
    public float ballSpeed = 3.0f;
    [Tooltip("How fast the ball accelerate if 0 ball speed is always the same")]
    public float ballAcceleration = 0.0f;
    public float maxBallSpeed = 12.0f;
    public bool acccelerationByTime = false;
    public bool accelerationByCollision = false;
    //this can also be achived using only 2 flags for up/dow and left/right movement but a 4 flag aproach makes it clearer to understand
    public bool topMovement = false;
    public bool bottomMovement = false;
    public bool rightMovement = false;
    public bool leftMovement = false;

    public float momentum = 0f;
    public float maxMomentum = 5f;
    public float monetumModifier = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (acccelerationByTime) {
            ballSpeed += Time.deltaTime * (0.1f * ballAcceleration);
        }
        
        if (ballSpeed > maxBallSpeed) {
            ballSpeed = maxBallSpeed;
        }
        if (topMovement)
        {
            transform.position = new Vector3(
                       transform.position.x,
                       transform.position.y,
                       transform.position.z + ballSpeed * Time.deltaTime
                   );
        }
        if (bottomMovement)
        {
            transform.position = new Vector3(
                       transform.position.x,
                       transform.position.y,
                       transform.position.z - ballSpeed * Time.deltaTime
                   );
        }
        if (rightMovement)
        {
            transform.position = new Vector3(
                       transform.position.x + ballSpeed * Time.deltaTime+(momentum*monetumModifier),
                       transform.position.y,
                       transform.position.z
                   );
        }

        if (leftMovement)
        {
            transform.position = new Vector3(
                       transform.position.x - (ballSpeed * Time.deltaTime)+(momentum* monetumModifier),
                       transform.position.y,
                       transform.position.z
                   );
        }

    }

    void updateMovement(bool[] collisionType) {

        
        if (collisionType.Length >= 4) {

            if (accelerationByCollision)
            {
                ballSpeed += ballAcceleration;
            }


            if (collisionType[0]) {
                topMovement = true;
                bottomMovement = false;
            }

            if (collisionType[1])
            {
                topMovement = false;
                bottomMovement = true;
            }

            if (collisionType[2])
            {
                rightMovement = true;
                leftMovement = false;
            }

            if (collisionType[3])
            {
                rightMovement = false;
                leftMovement = true;
            }

            //killer collision
            if (collisionType[4])
            {
                Debug.Log("Killer collision occured");

                GameObject mainCamera;
                mainCamera = GameObject.FindGameObjectWithTag(GlobalVariables.mainCameraTag);
                mainCamera.SendMessage("updateBalls",-1);
                Destroy(this.gameObject);

            }

        }
    
    }


    void updateMomentum(float momentumUpdate) {

        momentum += momentumUpdate;
        if (momentum > maxMomentum) {
            momentum = maxMomentum;
        } else if (momentum < (maxMomentum * -1)) { 
            momentum = maxMomentum *-1;
        }

    
    }
}
