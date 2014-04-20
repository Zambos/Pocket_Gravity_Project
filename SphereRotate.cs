using UnityEngine;
using System.Collections;

public class SphereRotate{
	float rotateLat=1f,rotateLon=0.5f,rotateSpeed=10f,latTo,lonTo;
	public bool rotateLat1=false;
	public bool rotateLon1=false;
	private GameObject Sphere;
	GUI2MENU1 menut;
	// Use this for initialization
	public void setMenu (GUI2MENU1 menu) {
		menut = menu;
	}
	void Start () {
	}
	public SphereRotate(GameObject sphere){
		Sphere=sphere;
	}
	public void startRotate (){
		rotateLat1 = true;
		rotateLon1 = true;
	}
	// Update is called once per frame
	public void Update (){
		if (rotateLat1) {
			Sphere.transform.Rotate (rotateLat, 0, 0);

		}
		if (rotateLon1) {
			Sphere.transform.Rotate(0,menut.gps.lon,0);
		}
	}
}
