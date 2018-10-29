using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class LineContentManager : MonoBehaviour {
	public TMP_Text lineText; 
	public InputField xInput; 
	public InputField yInput; 
	public float x; 
	public float y; 
	public int lineNumber; 
	public bool parseErrorX = true; 
	public bool parseErrorY = true; 
	public float xMin = 110;
	public float xMax = 140;
	public float yMin = 100;
	public float yMax = 110; 



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetNumber( int number){
		lineNumber = number; 
		lineText.text = "#" + number.ToString (); 

	}
	public void TryParseX() {
		string xString = xInput.text;
		if (float.TryParse (xString, out x)) {
			if (x < xMin || x > xMax) {
				xInput.image.color = Color.red; 
				parseErrorX = true; 
			} else {
				xInput.image.color = Color.white; 
				parseErrorX = false; 
			}


		} else {
			xInput.image.color = Color.red; 
			parseErrorX = true; 
		}

	}
	public void TryParseY() {
		string yString = yInput.text;
		if (float.TryParse (yString, out y)) {
			if (y < yMin || y > yMax) {
				yInput.image.color = Color.red; 
				parseErrorY = true; 
			} else {
				yInput.image.color = Color.white; 
				parseErrorY = false; 
			}

			
		} else {
			yInput.image.color = Color.red; 
			parseErrorY = true; 
		}
		 

	}

}
