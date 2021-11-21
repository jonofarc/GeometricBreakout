using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
    public float ballSpeed = 1.0f;
    //this can also be achived using only 2 flags for up/dow and left/right movement but a 4 flag aproach makes it clearer to understand
    public bool topMovement = false;
    public bool bottomMovement = false;
    public bool rightMovement = false;
    public bool leftMovement = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

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
                       transform.position.x + ballSpeed * Time.deltaTime,
                       transform.position.y,
                       transform.position.z
                   );
        }

        if (leftMovement)
        {
            transform.position = new Vector3(
                       transform.position.x - ballSpeed * Time.deltaTime,
                       transform.position.y,
                       transform.position.z
                   );
        }

    }

    void updateMovement(bool[] collisionType) {

        
        if (collisionType.Length >= 4) {
            
            

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
                mainCamera = GameObject.FindGameObjectWithTag(GlobalVariables.MainCameraTag);
                mainCamera.SendMessage("updateBalls",-1);
                Destroy(this.gameObject);

            }

        }
    
    }
}
