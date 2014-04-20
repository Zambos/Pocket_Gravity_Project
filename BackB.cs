using UnityEngine;
using System.Collections;

public class BackB : MonoBehaviour {
	public GUISkin customSkin1;
	public GameObject Sphere;
	// Use this for initialization
	void Start () {
	
	}
	void OnGUI(){
		GUI.skin = customSkin1;
		if(GUI.Button (new Rect(0,0,0.1f*Screen.width,0.1f*Screen.height), "")){
			GetComponent<GUIMenu>().enabled=false;
			GetComponent <BackB>().enabled = false;GetComponent <GUI3MENU>().enabled = false;
			GetComponent <Exit>().enabled = true;GetComponent<GUIMenu1>().enabled=true;
			GetComponent <GUI3MENU1>().enabled = false;
			GetComponent <GUI2MENU>().enabled = false;
			Sphere.SetActive(false);

		}
	}
	// Update is called once per frameq
	void Update () {
	
	}
}
