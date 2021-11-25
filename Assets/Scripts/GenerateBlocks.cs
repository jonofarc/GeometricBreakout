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
        int[,] lvlArray = new int[14, 14];
        switch (levelToGenerate)
        {
            case 1:
                lvlArray = new int[14, 14] {
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                    };
                generateLvl(lvlArray);
                break;

            case 2:
                lvlArray = new int[14, 14] {
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 0} ,
                        {0, 1, 2, 3, 3, 3, 3, 3, 3, 3, 3, 2, 1, 0} ,
                        {0, 1, 2, 4, 4, 4, 5, 4, 4, 4, 3, 2, 1, 0} ,
                        {0, 1, 2, 3, 3, 3, 3, 3, 3, 3, 3, 2, 1, 0} ,
                        {0, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                    };
                generateLvl(lvlArray);
                break;

            case 3:
                lvlArray = new int[14, 14] {
                        {0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0} ,
                        {0, 0, 4, 3, 3, 3, 3, 3, 3, 3, 4, 4, 0, 0} ,
                        {0, 0, 4, 3, 2, 2, 2, 2, 2, 2, 3, 4, 0, 0} ,
                        {0, 4, 3, 2, 1, 1, 1, 1, 1, 1, 2, 3, 4, 0} ,
                        {0, 4, 3, 2, 1, 0, 0, 0, 0, 1, 2, 3, 4, 0} ,
                        {0, 4, 3, 2, 1, 0, 0, 0, 0, 1, 2, 3, 4, 0} ,
                        {4, 3, 2, 1, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4} ,
                        {4, 3, 2, 1, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4} ,
                        {4, 3, 2, 1, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4} ,
                        {4, 3, 2, 1, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4} ,
                        {4, 3, 2, 1, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4} ,
                        {4, 3, 2, 1, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4} ,
                        {4, 3, 2, 1, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4} ,
                        {-1,-1,-1,-1,-1, 0, 0, 0, 0,-1,-1,-1,-1,-1} , //this line is for indestructible blocks not yet implementes
                    };
                generateLvl(lvlArray);
                break;

            default:
                Debug.Log("No specified Level Defined Genarating Level 1");
                lvlArray = new int[14, 14] {
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
                    };
                GlobalVariables.setCurrentLevel(1);
                generateLvl(lvlArray);
                break;
        }

    }

    private void generateLvl(int[,] lvl1Array)
    {
        GlobalVariables.blocksInPlay = 0;
        for (int i = 0; i < 14; i++) {
            for (int j = 0; j < 14; j++){
                int value = lvl1Array[i, j];
                if (value != 0) {
                    Vector3 possition = new Vector3(j, 1.0f, 19-i);
                    GameObject block = Instantiate(baseBlock, possition, baseBlock.transform.rotation) as GameObject;
                    block.transform.SetParent(this.transform);
                    

                    //only consider blocks with possitive value as blocksInPlay
                    if (value > 0)
                    {
                        GlobalVariables.blocksInPlay++;
                    }
                    else {
                        //consider any block with negative hp indestructible
                        block.SendMessage("setIndestructible", true);
                    }
                    block.SendMessage("setHp", value);
                    
                }
               
            }
            
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
