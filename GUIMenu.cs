﻿using UnityEngine;
using System.Collections;

public class GUIMenu : MonoBehaviour {
public Texture2D btnTexture;
	public GUISkin customSkin1;

	void Start(){}
	
	
	void Update() {}
	void OnGUI() {
		GUI.skin = customSkin1;
		//GUI.Box(new Rect(0,0,Screen.width,Screen.height), "Pocket Gravity");
/*		if(GUI.Button (new Rect(0,0,0.1f*Screen.width,0.1f*Screen.height), "Back")){
			GetComponent<GUIMenu>().enabled=false;
			GetComponent <GUI2MENU>().enabled = false;
			GetComponent <Exit>().enabled = true;
			GetComponent<GUIMenu1>().enabled=true;
		}*/
		if (GUI.Button (new Rect (0f*Screen.width,0.94f*Screen.height,0.15f*Screen.width,0.06f*Screen.height), btnTexture)) 
		{
			GetComponent<GUIMenu>().enabled=false;
			GetComponent <GUI2MENU>().enabled = true;
		}
		/*if (GUI.Button (new Rect (0.85f*Screen.width,0.94f*Screen.height,0.15f*Screen.width,0.06f*Screen.height), btnTexture)) 
		{
			GetComponent <GUIMenu>().enabled = false; 
			GetComponent <GUI2MENU>().enabled = true;
		}*/

	}
}