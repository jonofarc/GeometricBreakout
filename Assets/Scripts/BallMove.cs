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

    public GameObject killParticles;

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

        float moveAmount = ballSpeed * Time.deltaTime;
        float moveMomentumAmount = momentum * monetumModifier;

        Debug.Log("moveAmount = " + moveAmount + "moveMomentumAmount = " + moveMomentumAmount + " result =" + (moveAmount + moveMomentumAmount));
        //if momentum will overpower standar X axis movement capp it at 90%
        //probably a better way to implement capping momentum for bot negative and positive values can be implemented
        if (moveMomentumAmount >= moveAmount) {
            moveMomentumAmount = moveAmount * 0.9f;
        }
        if (moveMomentumAmount <= (moveAmount * -1))
        {
            moveMomentumAmount = moveAmount * -0.9f;
        }

        if (topMovement)
        {
            transform.position = new Vector3(
                       transform.position.x,
                       transform.position.y,
                       transform.position.z + moveAmount
                   );
        }
        if (bottomMovement)
        {
            transform.position = new Vector3(
                       transform.position.x,
                       transform.position.y,
                       transform.position.z - moveAmount
                   );
        }

        if (rightMovement)
        {
            transform.position = new Vector3(
                       transform.position.x + ( moveMomentumAmount),
                       transform.position.y,
                       transform.position.z
                   );
        }

        if (leftMovement)
        {
            transform.position = new Vector3(
                       transform.position.x + (moveMomentumAmount),
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
                momentum = Mathf.Abs(momentum);
            }

            if (collisionType[3])
            {
                rightMovement = false;
                leftMovement = true;
                momentum = Mathf.Abs(momentum);
                momentum *= -1; 
            }

            //killer collision
            if (collisionType[4])
            {
                Debug.Log("Killer collision occured");

                GameObject mainCamera;
                mainCamera = GameObject.FindGameObjectWithTag(GlobalVariables.mainCameraTag);
                mainCamera.SendMessage("updateBalls",-1);


                if (killParticles != null) {
                    GameObject block = Instantiate(killParticles, this.transform.position, this.transform.rotation) as GameObject;
                }
                

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
