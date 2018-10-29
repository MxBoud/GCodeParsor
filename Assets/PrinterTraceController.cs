using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterTraceController : MonoBehaviour {
	public LineRenderer lR; 
	public Vector3 offset; 

	public List<Vector3> points; 

	// Use this for initialization
	void Start () {
		points = new List<Vector3>(); 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AddRandomPoint() {
		AddPoint (Random.Range (110f, 140f), Random.Range (100f, 110f)); 
	}
	public void AddPoint(float x, float y) {
		points.Add((new Vector3(x,y,0))); 
		SetPoints (); 

	}
	public void SetPoints() {
		Vector3[] pointsArray = points.ToArray (); 

		lR.positionCount = pointsArray.Length;
		int index = 0; 
		foreach (Vector3 point in pointsArray) {
			lR.SetPosition (index, (point-offset)); 
			index++; 
		}


	}
}
