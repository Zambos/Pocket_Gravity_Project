using UnityEngine;
using System.Collections;
using System.IO;
using System;
public class Gravity {
	private string filePath="Assets\\Resources\\Dg01_cnt2.5x2.txt";
	private double exclud=9999.0d, dlatg=2.5d/60.0d,dlong=2.5d/60.0d;
	private static int nrowsg=4320,ncolsg=8640,i,j;
	private float[] data= new float[ncolsg];
	private double[] data1= new double[ncolsg];
	private byte[] floatBytes;
	private double gravityAn,lat,lon,alt;
	private String[] str;
	private string filePath1;
	
	public Gravity(string str){
		filePath = str;
	}
	
	public double GetGravity(double rlat,double rlon,double alt){
		//filePath1 =  "/Assets/Dg01_cnt2.5x2.txt";
		lat = rlat;
		lon = rlon;
		alt = this.alt;
		TextAsset asset = Resources.Load ("Dg01_cnt2.5x2") as TextAsset;
		Stream s = new MemoryStream (asset.bytes);
		BinaryReader reader = new BinaryReader (s);
		Debug.Log (filePath);
		int i = Convert.ToInt32((90.0d + rlat + dlatg * 0.5) / dlatg);
		int j = Convert.ToInt32((rlon+180-dlong * 0.5d) / dlong);
		reader.ReadBytes (((i - 1) * j) * 4);
		for (int k=1; k<ncolsg; k++) {
			floatBytes = reader.ReadBytes(4);
			Array.Reverse(floatBytes);
			data[k] = BitConverter.ToSingle(floatBytes, 0);
			//Debug.Log(data[k]+" ");
		}
		
		gravityAn = data [j];
		
		
		reader.Close ();
		return gravityAn;
	}
	public double GetAcceleration(double gravityAn){
		return 9.780327*(((1+0.0053024*Math.Sin(lat)*Math.Sin(lat)) -(0.0000058*Math.Sin(2*lat)*Math.Sin(2*lat))) - (3.155*10e-7*alt))+(gravityAn*0.00001);
	}	
} 
/*using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Gravity{
	private string filePath="Assets\\Resources\\Dg01_cnt2.5x2.txt";
	private double exclud=9999.0d, dlatg=2.5d/60.0d,dlong=2.5d/60.0d;
	private static int nrowsg=4320,ncolsg=8640,i,j;
	private float[] data= new float[ncolsg];
	private double[] data1= new double[ncolsg];
	private byte[] floatBytes;
	private float gravityAn;
	private String[] str;
	private string filePath1;
	
	public float GetGravity(double rlat,double rlon){
		filePath1 =  "/Assets/Dg01_cnt2.5x2.txt";
		BinaryReader reader = new BinaryReader (File.Open (filePath, FileMode.Open));
		int i = Convert.ToInt32((90.0d + rlat + dlatg * 0.5) / dlatg);
		int j = Convert.ToInt32((rlon+180-dlong * 0.5d) / dlong);
		reader.ReadBytes (((i - 1) * j) * 4);
			for (int k=1; k<ncolsg; k++) {
				floatBytes = reader.ReadBytes(4);
				Array.Reverse(floatBytes);
				data[k] = BitConverter.ToSingle(floatBytes, 0);
			//Debug.Log(data[k]+" ");
			}

		gravityAn = data [j];
		
		
		reader.Close ();
		return gravityAn;
	}
	public float GetAcceleration(float gravityAn){
		return 9.80665f+(gravityAn*0.00001f);
	}
	public string[] GetLocation(){
		str=Directory.GetFiles (filePath1);
		return str;
	}
} */
