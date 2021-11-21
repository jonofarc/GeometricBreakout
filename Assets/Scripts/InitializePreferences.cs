using UnityEngine;
using System.Collections;

public class InitializePreferences : MonoBehaviour {

	public int fpsTarget = 60;
	public int startLevel = 1;
	// Use this for initialization
	void Start () {


		PlayerPrefs.SetInt("TargetFPS", fpsTarget);
		if (PlayerPrefs.GetInt("CurrentLevel")<=0){
			Debug.Log ("First Time Use");
			initializePreferences (); 
		}

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void DeletePreferences(){
		Debug.Log ("Deleting PlayerPrefs");
		PlayerPrefs.DeleteAll();

	}
	public void initializePreferences(){
		
		PlayerPrefs.SetInt ("CurrentLevel", startLevel);
		Debug.Log (PlayerPrefs.GetInt("CurrentLevel"));
	}
}
