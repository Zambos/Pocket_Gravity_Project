using UnityEngine;
using System.Collections;
public class GUIMenu1 : MonoBehaviour {
	public GUISkin customSkin1;
	public GameObject Sphere;
	void Start(){
		GetComponent <Exit>().enabled = true;
	}
	void OnGUI ()
	{
	//	GUI.Box(new Rect(0.17f*Screen.width,0.720f*Screen.height,0.67f*Screen.width,0.166f*Screen.height),"Gravity");
		GUI.skin = customSkin1;
		Rect MenuBackground = new Rect (0,0,Screen.width,Screen.height);
		GUI.Box (MenuBackground,"Pocket Gravity");


		Rect Map3DButton = new Rect (0.17f*Screen.width,0.285f*Screen.height,0.67f*Screen.width,0.166f*Screen.height);
		if (GUI.Button (Map3DButton, "3D Map")) 
		{
			GetComponent <BackB>().enabled = true;
			GetComponent <GUIMenu1>().enabled = false;
			GetComponent <Exit>().enabled = false;
			GetComponent <GUIMenu>().enabled = true;
			Sphere.SetActive(true);
		}

		Rect WorkspaceButton = new Rect (0.17f*Screen.width,0.502f*Screen.height,0.67f*Screen.width,0.166f*Screen.height);
		if (GUI.Button (WorkspaceButton, "Workspace")) 
		{
			GetComponent <BackB>().enabled = true;
			GetComponent <GUIMenu1>().enabled = false;
			GetComponent <Exit>().enabled = false;
			GetComponent <GUI3MENU1>().enabled = true;
			GetComponent <GUI3MENU>().enabled = true;

		}

		Rect AboutButton = new Rect (0.17f*Screen.width,0.722f*Screen.height,0.67f*Screen.width,0.166f*Screen.height);
		if (GUI.Button (AboutButton, "About")) 
		{
			GetComponent <BackB>().enabled = true;
			GetComponent <GUIMenu1>().enabled = false;
			GetComponent <Exit>().enabled = false;
			GetComponent <ABOUT>().enabled=true;
		}

	}

}
//qqq