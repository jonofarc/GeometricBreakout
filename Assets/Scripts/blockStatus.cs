using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockStatus : MonoBehaviour
{
    public int hp = 1;
    public bool indestructible = false;
    public Material[] blockHpMaterials = new Material[5];
    public float hitTimeCoolDown = 0.2f;
    float lastHit = 0;

    // Start is called before the first frame update
    void Start()
    {
        lastHit = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setHp(int newHp) {
        hp = newHp;
        updateMaterial();
    }

    void setIndestructible (bool status)
    {
        indestructible = status;
    }

    void updateHp()
    {
        float hitTime = Time.time;
        if (hitTime > (lastHit + hitTimeCoolDown)) {
            lastHit = hitTime;
            if (!indestructible) {
                hp -= GlobalVariables.ballDamage;
            }
            
            if (hp <= 0 && !indestructible)
            {
                GameObject mainCamera;
                mainCamera = GameObject.FindGameObjectWithTag(GlobalVariables.mainCameraTag);
                //update the amount of blocks ingame
                mainCamera.SendMessage("updateBlocks", -1);
                Destroy(this.gameObject);
            }
            else
            {
                updateMaterial();
            }
        }
        

    }

    private void updateMaterial()
    {
        
        switch (hp)
        {
            case -1:
                GetComponent<Renderer>().material = blockHpMaterials[0];
                break;
            case 1:
                GetComponent<Renderer>().material = blockHpMaterials[1];
                break;
            case 2:
                GetComponent<Renderer>().material = blockHpMaterials[2];
                break;
            case 3:
                GetComponent<Renderer>().material = blockHpMaterials[3];
                break;
            case 4:
                GetComponent<Renderer>().material = blockHpMaterials[4];
                break;
            case 5:
                GetComponent<Renderer>().material = blockHpMaterials[5];
                break;
           
            default:
                GetComponent<Renderer>().material = blockHpMaterials[0];
                break;
        }
    }
}
