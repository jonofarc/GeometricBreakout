using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public int lives = 0;
    public GameObject ball;
    public GameObject ballsUi;
    public GameObject blocksUi;
    

    // Start is called before the first frame update
    void Start()
    {
        //set 0 balls in play to force a spawn
        GlobalVariables.ballsInPlay = 0;
        updateBalls(0);
        updateBlocks(0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Debug.isDebugBuild) {

            if (Input.GetKey(KeyCode.Alpha1)){
                updateTimeScale(1.0f);
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                updateTimeScale(2.0f);
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                updateTimeScale(3.0f);
            }

        }

    }

    private void updateTimeScale(float scale)
    {
        Time.timeScale = scale;
    }

    void updateBalls(int amount)
    {
        GlobalVariables.ballsInPlay += amount;
        ballsUi.SendMessage("updateText", "Balls: " + lives);
        if (GlobalVariables.ballsInPlay <= 0) {
            if (lives <= 0) {
                StartCoroutine(gameOver());
            }
            else {
                //respawn a new ball and lower lives count
                if (amount == 0){
                    StartCoroutine(spawnNewBall(0));
                }
                else {
                    StartCoroutine(spawnNewBall(3));
                }
                
               
                lives--;
                GlobalVariables.ballsInPlay += 1;

            }
           
            
        }
        
    }

    private IEnumerator spawnNewBall(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Vector3 possition = new Vector3(5.0f, 1.0f, 0.6f);
        GameObject newBall = Instantiate(ball, possition, ball.transform.rotation) as GameObject;
    }

    void updateBlocks(int amount)
    {
        GlobalVariables.blocksInPlay += amount;
        blocksUi.SendMessage("updateText", "Blocks: " + GlobalVariables.blocksInPlay);
        if (GlobalVariables.blocksInPlay <= 0)
        {
            StartCoroutine(victory());
        }
    }

    IEnumerator victory()
    {
        Debug.Log("Game Won!!!!!!!! : " + Time.time);
        //yield on a new YieldInstruction that waits for 3 seconds.
        yield return new WaitForSeconds(3);

        
        GlobalVariables.setCurrentLevel(GlobalVariables.currentLevel + 1);
        //if the last level is finished loop back to first level
        if (GlobalVariables.currentLevel > GlobalVariables.lastLevel) {

            GlobalVariables.setCurrentLevel(GlobalVariables.currentLevel + 1);
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    IEnumerator gameOver()
    {
        Debug.Log("Game Over!!!!!!!! : " + Time.time);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }


    //Debug section

}
