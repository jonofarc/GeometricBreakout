using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour
{
    private int levelToGenerate = 0;
    public GameObject baseBlock;
    // Start is called before the first frame update
    void Start()
    {
        levelToGenerate = GlobalVariables.currentLevel;
        int[,] lvlArray = new int[14, 10];
        switch (levelToGenerate)
        {
            case 1:
                lvlArray = new int[14, 10] {
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 2, 2, 2, 2, 2, 2, 2, 2, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                    };
                generateLvl(lvlArray);
                break;

            case 2:
                lvlArray = new int[14, 10] {
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 2, 2, 2, 2, 2, 2, 2, 2, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                    };
                generateLvl(lvlArray);
                break;

            default:
                Debug.Log("No specified Level Defined Genarating Level 1");
                lvlArray = new int[14, 10] {
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 1, 2, 2, 2, 2, 2, 2, 1, 0} ,
                        {0, 1, 2, 3, 3, 3, 3, 2, 1, 0} ,
                        {0, 1, 2, 3, 4, 4, 3, 2, 1, 0} ,
                        {0, 1, 2, 3, 3, 3, 3, 2, 1, 0} ,
                        {0, 1, 2, 2, 2, 2, 2, 2, 1, 0} ,
                        {0, 1, 2, 2, 2, 2, 2, 2, 1, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                    };
                GlobalVariables.setCurrentLevel(1);
                generateLvl(lvlArray);
                break;
        }

    }

    private void generateLvl(int[,] lvl1Array)
    {
       
        for (int i = 0; i < 14; i++) {
            for (int j = 0; j < 10; j++){
                int value = lvl1Array[i, j];
                if (value > 0) {
                    Vector3 possition = new Vector3(j, 1.0f, 19-i);
                    GameObject block = Instantiate(baseBlock, possition, baseBlock.transform.rotation) as GameObject;
                    block.transform.SetParent(this.transform);
                    GlobalVariables.blocksInPlay++;
                    block.SendMessage("setHp", lvl1Array[i, j]);
                    
                }
               
            }
            
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
