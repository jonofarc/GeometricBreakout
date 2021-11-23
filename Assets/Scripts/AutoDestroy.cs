using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    public float killTimer = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(selfKill());
    }

    IEnumerator selfKill()
    {
        yield return new WaitForSeconds(killTimer);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
