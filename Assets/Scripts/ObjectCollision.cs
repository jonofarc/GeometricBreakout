using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
   
    //tipe of collision object
    public bool topCollision = false;
    public bool bottomCollision = false;
    public bool rightCollision = false;
    public bool leftCollision = false;

    [Tooltip("Consider this collision as a round ending collision")]
    public bool killerCollision = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter(Collider collision)
    {
        
        //bool[] collisionType = [topCollision, bottomCollision, rightCollision, leftCollision];
        bool[] collisionType = new bool[5];
        collisionType[0] = topCollision;
        collisionType[1] = bottomCollision;
        collisionType[2] = rightCollision;
        collisionType[3] = leftCollision;
        collisionType[4] = killerCollision;
        collision.gameObject.SendMessage("updateMovement", collisionType);
        
        if (this.transform.parent.gameObject.tag == GlobalVariables.blockTag) {
            this.transform.parent.gameObject.SendMessage("updateHp");
        }
        
       
    }

}
