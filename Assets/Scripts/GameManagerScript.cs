using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private int  blocksInPlay =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }

    void updateBalls(int amount)
    {
        GlobalVariables.ballsInPlay += amount;
        if (GlobalVariables.ballsInPlay <= 0) {
            StartCoroutine(gameOver());
        }
    }

    void updateBlocks(int amount)
    {
        GlobalVariables.blocksInPlay += amount;
        blocksInPlay = GlobalVariables.blocksInPlay;
        if (GlobalVariables.blocksInPlay <= 0)
        {
            StartCoroutine(victory());
        }
    }

    IEnumerator victory()
    {
        Debug.Log("Game Won!!!!!!!! : " + Time.time);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    IEnumerator gameOver()
    {
        Debug.Log("Game Over!!!!!!!! : " + Time.time);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }


}
