using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GCodeContentManager : MonoBehaviour {
	public GameObject linePrefab;
	public List<LineContentManager> lineList; 
	public PrinterTraceController pTC;
	public Button GCODEButton; 
	void Start() {
		AddLine (); 
	}

	public void AddLine() {
		LineContentManager lCM = Instantiate (linePrefab, this.transform).GetComponent<LineContentManager>(); 
		lineList.Add (lCM); 
		lCM.SetNumber (lineList.Count); 
	}
	public void RemoveLine() {
		if (lineList.Count > 0) {
			LineContentManager lCM = lineList[lineList.Count-1]; 
			Destroy (lCM.gameObject); 
			lineList.RemoveAt (lineList.Count - 1); 
		}

	}

	public void ValidateGCode () {
		pTC.points = new List<Vector3>(); 
		foreach (LineContentManager lCM in lineList) {
			if (lCM.parseErrorX || lCM.parseErrorY) {
				

				GCODEButton.image.color = Color.red; 

				return; 
			}
			Vector3 point = new Vector3 (lCM.x, lCM.y, 0); 
			pTC.points.Add (point); 

		}
        pTC.StartAnimateSetPoint (); 
		GCODEButton.image.color = Color.gray; 

		
	}
}
