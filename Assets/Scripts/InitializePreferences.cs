using UnityEngine;
using System.Collections;

public class InitializePreferences : MonoBehaviour {

	public int fpsTarget = 60;
	public int startLevel = 1;
	// Use this for initialization
	void Start () {


		PlayerPrefs.SetInt("TargetFPS", fpsTarget);
		int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
		if (currentLevel <= 0 || currentLevel > GlobalVariables.lastLevel){
			Debug.Log("First Time Use or currentLevel out of bounds");
			initializePreferences();
		}
		else{
			GlobalVariables.setCurrentLevel(currentLevel);
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
		GlobalVariables.setCurrentLevel(startLevel);
		
	}
}
