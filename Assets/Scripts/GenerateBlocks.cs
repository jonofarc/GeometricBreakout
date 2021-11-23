using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour
{
    public int levelToGenerate = 0;
    public GameObject baseBlock;
    // Start is called before the first frame update
    void Start()
    {
        levelToGenerate = GlobalVariables.currentLevel;
        if (levelToGenerate > 0) {
            switch (levelToGenerate) {
                case 1:
                    int[,] lvl1Array = new int[14, 10] {
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
                    generateLvl(lvl1Array);
                    break;
                default:

                    int[,] lvl2Array = new int[14, 10] {
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

                    generateLvl(lvl2Array);
                    break;
            }
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
