﻿using UnityEngine; 
using System.Collections;
using System;

public class GUI2MENU : MonoBehaviour {
	public Texture2D btnTexture;
	public GameObject GPs;
	public GPS gps;
	public GameObject Sphere;
	public GUISkin customSkin1;
	SphereRotate sphereRot;
	//string inputString1="  ";
	string inputString="",inputString1="",inputString2="";
	float x,y,z;
	void Start(){
		gps = GPs.GetComponent<GPS>();
		//sphereRot = new SphereRotate(Sphere);
		inputString = gps.dlat.ToString ();
		inputString1 = gps.dlon.ToString();
		inputString2 = gps.alt.ToString();
	}

	
	void Update() {}
	

	void OnGUI() {
		GUI.skin = customSkin1;
	/*	GUI.Box(new Rect(0,0,Screen.width,Screen.height), "Pocket Gravity");
		if(GUI.Button (new Rect(0,0,0.1f*Screen.width,0.1f*Screen.height), "Back")){
			GetComponent<GUI2MENU>().enabled=false;
			GetComponent<GUI2_2MENU>().enabled=false;
			GetComponent<GUIMenu1>().enabled=true;
		}
*/
		if (GUI.Button (new Rect (0f*Screen.width,0.69f*Screen.height,0.15f*Screen.width,0.06f*Screen.height), btnTexture)) 
		{
			GetComponent <GUI2MENU>().enabled = false; 
			GetComponent <GUIMenu>().enabled = true; 
		}

		GUI.Box(new Rect(0,0.75f*Screen.height,Screen.width,0.25f*Screen.height),"Options");
		GUI.Box (new Rect (0.05f, 0.79f * Screen.height,0.5f*Screen.width,0.06f*Screen.height),""+Math.Round(gps.gAcc, 6)+" m/s"+"\u00B2");
		GUI.Box (new Rect (0.5f * Screen.width,0.79f * Screen.height,0.5f*Screen.width,0.06f*Screen.height),""+Math.Round(gps.gAn, 6)+" mGal");
		inputString=GUI.TextField (new Rect (0, 0.86f * Screen.height, 0.3f * Screen.width, 0.06f * Screen.height),inputString);
		Single.TryParse (inputString, out x);
		inputString1=GUI.TextField (new Rect (0.35f * Screen.width,0.86f * Screen.height,0.3f*Screen.width,0.06f*Screen.height),inputString1);
		Single.TryParse (inputString, out y);
		inputString2=GUI.TextField (new Rect (0.70f*Screen.width,0.86f*Screen.height,0.3f*Screen.width,0.06f*Screen.height),inputString2);
		Single.TryParse (inputString, out z);
		if (GUI.Button (new Rect (0.065f * Screen.width, 0.93f * Screen.height, 0.43f * Screen.width, 0.06f * Screen.height), "Submit")) {
			//sphereRot.startRotate();
			gps.Search = false;
			gps.lat=Convert.ToSingle(inputString);
			if(gps.lat >= 90 || gps.lat <= -90)gps.lat=0;
			gps.lon=Convert.ToSingle(inputString1);
			if(gps.lon >= 180 || gps.lon <= -180)gps.lon=0;
			gps.alt=Convert.ToSingle(inputString2);
			gps.updateData();
			gps.Update();
		}
		if (GUI.Button (new Rect (0.5f * Screen.width, 0.93f * Screen.height, 0.45f * Screen.width, 0.06f * Screen.height), "My Location")) {
			gps.Search = true;
			gps.updateData();
			gps.Update();
		}
		/*if (GUI.Button (new Rect (0.85f*Screen.width,0.69f*Screen.height,0.15f*Screen.width,0.06f*Screen.height), btnTexture)) 
		{
			GetComponent <GUIMenu>().enabled = true; 
			GetComponent <GUI2MENU>().enabled = false;
		}

			GUI.Box(new Rect(0,0.8f*Screen.height,Screen.width,0.2f*Screen.height),"Options");
		GUI.Box (new Rect (0, 0.83f * Screen.height,0.3f*Screen.width,0.06f*Screen.height), "g");
		GUI.Box (new Rect (0.35f * Screen.width,0.83f * Screen.height,0.3f*Screen.width,0.06f*Screen.height),"gAn");
		GUI.Box (new Rect(0.70f*Screen.width,0.83f*Screen.height,0.3f*Screen.width,0.06f*Screen.height),"Show");
		inputString=GUI.TextField (new Rect (0, 0.92f * Screen.height, 0.3f * Screen.width, 0.06f * Screen.height),inputString);
		Single.TryParse (inputString, out x);
		inputString1=GUI.TextField (new Rect (0.35f * Screen.width,0.92f * Screen.height,0.3f*Screen.width,0.06f*Screen.height),inputString1);
		Single.TryParse (inputString, out y);
		inputString2=GUI.TextField (new Rect (0.70f*Screen.width,0.92f*Screen.height,0.3f*Screen.width,0.06f*Screen.height),inputString2);
		Single.TryParse (inputString, out z); 
		*/
	}
}