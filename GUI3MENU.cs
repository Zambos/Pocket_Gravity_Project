﻿using UnityEngine;
using System.Collections;
using System;

public class GUI3MENU : MonoBehaviour {
	public GUISkin customSkin1;
	string a="",b="",c="";
	float e,f,g;
	// Use this for initialization
	void Start (){}
	
	// Update is called once per frame
	void Update () {}

	void OnGUI(){
		GUI.skin = customSkin1;
		GUI.Box(new Rect(0,0,Screen.width,Screen.height),"Work menu");
	//gravity
		/*
		GUI.Box(new Rect(0.25f*Screen.width,0.07f*Screen.height,0.5f*Screen.width,0.05f*Screen.height),"Gravity");
	//ebal sam go za kakvo e
		GUI.Box (new Rect (0.5f * Screen.width, 0.135f * Screen.height, 0.25f * Screen.width, 0.05f * Screen.height), " ");
	//x
		a=GUI.TextField(new Rect(0.16f*Screen.width,0.2f*Screen.height,0.15f*Screen.width,0.05f*Screen.height),a);
		Single.TryParse (a, out e);
	//y
		b=GUI.TextField(new Rect(0.42f*Screen.width,0.2f*Screen.height,0.15f*Screen.width,0.05f*Screen.height),b);
		Single.TryParse (b, out f);
	//z
		c=GUI.TextField(new Rect(0.67f*Screen.width,0.2f*Screen.height,0.15f*Screen.width,0.05f*Screen.height),c);
		Single.TryParse (c, out g);*/
	/*	if (GUI.Button (new Rect (0,0,0.1f*Screen.width,0.1f*Screen.height), "Back")) {
			GetComponent <GUI3MENU>().enabled = false;
			GetComponent <Exit>().enabled = true;
			GetComponent<GUIMenu1>().enabled=true; 		
		}*/

	}
}
