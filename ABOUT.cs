﻿using UnityEngine;
using System.Collections;
using System;

public class ABOUT : MonoBehaviour {
	public GUISkin customSkin1;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		GUI.skin = customSkin1;
		GUI.Box (new Rect(0,0,Screen.width,Screen.height),"ABOUT");
		/*if (GUI.Button (new Rect (0,0,0.1f*Screen.width,0.1f*Screen.height), "Back")) {
			GetComponent<ABOUT>().enabled=false; 		
			GetComponent <Exit>().enabled = true;
			GetComponent<GUIMenu1>().enabled=true;
		}*/
	}
}