using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	public GUISkin customSkin1;
	// Use this for initialization
	void Start () {}
	
	void OnGUI ()
	{
		GUI.skin = customSkin1;
		if(GUI.Button (new Rect(0,0,0.16f*Screen.width,0.1f*Screen.height), ""))
			Application.Quit();
}
}
//