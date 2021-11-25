using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject ContinueButton;

    // Use this for initialization
    void Start () {
		//Debug.Log (_language); 
		//language section //we make sure that the language is a valid one and that its on the latest language used


		// show continue button only if current level is more than the second one
		if (PlayerPrefs.GetInt ("CurrentLevel") > 1) {
			ContinueButton.SetActive (true);
		} else {
			ContinueButton.SetActive (false);
		}


		// setting default fps
		Application.targetFrameRate = GlobalVariables.TargetFPS;




	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Continue(){
		int levelToLoad = PlayerPrefs.GetInt("CurrentLevel");
		GlobalVariables.setCurrentLevel(levelToLoad);
		SceneManager.LoadScene("FiniteLevel", LoadSceneMode.Single);
	}
	public void LoadLevel(int levelToLoad){
		GlobalVariables.setCurrentLevel(levelToLoad);
		SceneManager.LoadScene("FiniteLevel", LoadSceneMode.Single);
	}
	public void Exit(){
		
		Application.Quit();
	}

}
