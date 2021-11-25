﻿using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour {


	public static string mainCameraTag = "MainCamera";
	public static string blockTag = "Block";
	public static string playerTag = "Player";
	public static int currentLevel = 1;
	public static int lastLevel = 3;
	public static int ballsInPlay = 0;
	public static int blocksInPlay = 0;
	public static int TargetFPS = 60;

	// ball damage is handled as a negative value as it is making damage and reducing block hp
	public static int ballDamage = 1;


	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public static void setCurrentLevel(int level){
		currentLevel = level;
		PlayerPrefs.SetInt("CurrentLevel", level);
		Debug.Log("Setting level to: "+ level);
	}
}
