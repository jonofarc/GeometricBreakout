using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevelAfterTime : MonoBehaviour {

	public float myTime=5f;
	public string LevelToLoad="";

	// Use this for initialization
	void Start () {
		Invoke ("LoadLevel", myTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void LoadLevel (){
		if (LevelToLoad == "") {
			
			SceneManager.LoadScene ((SceneManager.GetActiveScene ().buildIndex) + 1);
				
		} else {
			SceneManager.LoadScene (LevelToLoad);
		}

	}
}
