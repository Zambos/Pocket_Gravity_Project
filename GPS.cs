using UnityEngine;
using System.Collections;

public class GPS : MonoBehaviour {
	public float lon,alt,lat,dlon,dalt,dlat,accuracy,distance;
	public bool Search = true;
	public double gAn,gAcc;
	int maxWait=3600;
//	Transform show;
//	YieldInstruction yeald;
	Gravity gravity;
	LocationServiceStatus locationStatus;
	void Start(){
		gravity = new Gravity (Application.dataPath+"/Resources/Dg01_cnt2.5x2.bytes");
		Input.location.Start();           //enable location settings
		Input.compass.enabled = true;
		locationStatus = LocationServiceStatus.Running;
		lon = 0; alt = 0; lat = 0;
		dlon = 0; dalt = 0; dlat = 0;
		gAn=gravity.GetGravity(lat,lon,alt);
		gAcc = gravity.GetAcceleration (gAn);
		startLocationService();               //begin GPS transmittion
	}
	
	
	public void Update () 
	{
		if(locationStatus == LocationServiceStatus.Running && Search)
		{

			lat = Input.location.lastData.latitude;
			lon = Input.location.lastData.longitude;
			alt = Input.location.lastData.altitude;
			if(lat!=dlat || lon!= dlon || alt!=dalt){
				gAn=gravity.GetGravity(lat,lon,alt);
				gAcc = gravity.GetAcceleration(gAn);
				dlat=lat;
				dlon=lon;
				dalt=alt;
			}
			
		}
		//Debug.Log (lat+" "+lon+" "+alt+" "+gAn+" "+gAcc+" "+locationStatus);
	}

	IEnumerator startLocationService()
	{
		Input.location.Start(accuracy, distance);
		
		
		while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) 
		{
			yield return (new WaitForSeconds(1));
			maxWait--;
			locationStatus = Input.location.status;
		}
	}
	void OnGUI() {
	//	GUI.Label(new Rect(0,0,300,300)," Latitude => " + lat.ToString() + "\n Longitude => " + lon.ToString() + "\n Altitude => "  +alt.ToString() +"\n gravityAn "+gAn+"\n file=> "+Application.dataPath+"/Und_min2.5x2.txt"+"\n Aceleroration => "+gravity.GetAcceleration(gAn));

	}
	public void updateData(){
		gAn=gravity.GetGravity(lat,lon,alt);
		gAcc = gravity.GetAcceleration(gAn);
	}
	
}