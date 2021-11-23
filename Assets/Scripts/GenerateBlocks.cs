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
        if (levelToGenerate > 0) {
            switch (levelToGenerate) {
                case 1:
                    generateLvl1();
                    break;
                default:
                    generateLvl1();
                    break;
            }
        }
        
    }

    private void generateLvl1()
    {
        int[,] lvl1Array = new int[14, 10] {
            {5, 5, 5, 5, 5, 5, 5, 5, 5, 5} ,
            {4, 4, 4, 4, 4, 4, 4, 4, 4, 4} ,
            {3, 3, 3, 3, 3, 3, 3, 3, 3, 3} ,
            {2, 2, 2, 2, 2, 2, 2, 2, 2, 2} ,
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1} ,
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
            {0, 5, 5, 5, 5, 5, 5, 5, 5, 0} ,
            {0, 4, 4, 4, 4, 4, 4, 4, 4, 0} ,
            {0, 3, 3, 3, 3, 3, 3, 3, 3, 0} ,
            {0, 2, 2, 2, 2, 2, 2, 2, 2, 0} ,
            {0, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
            {2, 2, 2, 2, 2, 2, 2, 2, 2, 2} ,
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1} ,
        };

        

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
