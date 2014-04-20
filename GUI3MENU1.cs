using UnityEngine;
using System.Collections;
using System;

public class GUI3MENU1 : MonoBehaviour {
	public GUISkin customSkin1;
	string a="",b="",c="";
	float e,f,g;
	public GameObject GPs;
	public GPS gps;
	// Use this for initialization
	void Start(){
		gps = GPs.GetComponent<GPS>();
		a = gps.dlat.ToString();
		b = gps.dlon.ToString();
		c = gps.alt.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		//gps.Update ();
		//Debug.Log (gps.alt+" "+gps.lat+" "+gps.lon);
	}

	void OnGUI(){
		GUI.skin = customSkin1;
	//gravity
		GUI.Box(new Rect(0.20f*Screen.width,0.07f*Screen.height,0.6f*Screen.width,0.07f*Screen.height),""+Math.Round(gps.gAcc, 6)+" m/s"+"\u00B2");

		GUI.Box (new Rect (0.20f * Screen.width, 0.14f * Screen.height, 0.6f * Screen.width, 0.07f * Screen.height),Math.Round(gps.gAn, 6)+" mGal");
	//x
		a=GUI.TextField(new Rect(0.16f*Screen.width,0.25f*Screen.height,0.15f*Screen.width,0.07f*Screen.height),a);
		Single.TryParse (a, out e);
	//y
		b=GUI.TextField(new Rect(0.42f*Screen.width,0.25f*Screen.height,0.15f*Screen.width,0.07f*Screen.height),b);
		Single.TryParse (b, out f);
	//z
		c=GUI.TextField(new Rect(0.67f*Screen.width,0.25f*Screen.height,0.15f*Screen.width,0.07f*Screen.height),c);
		Single.TryParse (c, out g);

		//Butoi za Smqna na mode-a na lokaciq
		if (GUI.Button (new Rect (0.15f*Screen.width,0.4f*Screen.height,0.3f*Screen.width,0.1f*Screen.height), "Submit")) {
			gps.Search = false;
			gps.lat=Convert.ToSingle(a);
			if(gps.lat >= 90 || gps.lat <= -90)gps.lat=0;
			gps.lon=Convert.ToSingle(b);
			if(gps.lon >= 180 || gps.lon <= -180)gps.lon=0;
			gps.alt=Convert.ToSingle(c);
			gps.Update();
			gps.updateData();
		}
		if (GUI.Button (new Rect (0.55f*Screen.width,0.4f*Screen.height,0.3f*Screen.width,0.1f*Screen.height), "My location")) {
			gps.Search = true;
			gps.Update();
			gps.Search = true;
			gps.updateData(); 

		}

	}
}
