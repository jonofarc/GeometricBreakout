using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextModify : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateText(string text) {
        GetComponent<TextMeshProUGUI>().text = text;
    }

}
