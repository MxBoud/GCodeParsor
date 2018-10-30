using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterTraceController : MonoBehaviour {
	public LineRenderer lR; 
	public Vector3 offset; 

	public List<Vector3> points;


    //Animation part 
    private bool setPointsAnimate = false;
    private int animateIndex = 0;
    private Vector3[] pointsArrayAnim;
    private Vector3 currentAnimPos;
    private Vector3 targetAnimPos;
    public float speed = 0.5f;


    // Use this for initialization
    void Start () {
		points = new List<Vector3>(); 
		
	}
	
	// Update is called once per frame
	void Update () {
        if (setPointsAnimate){
            AnimateSetPoint(); 
        }
		
    }
    public void StartAnimateSetPoint()
    {
        if (points.Count <2){
            return;
        }
        animateIndex = 0;
        setPointsAnimate = true;
        pointsArrayAnim = new Vector3[points.Count];
        pointsArrayAnim = points.ToArray();
        currentAnimPos = pointsArrayAnim[animateIndex];
        targetAnimPos = pointsArrayAnim[animateIndex+1];

        lR.positionCount = animateIndex+2;
        lR.SetPosition(animateIndex, (pointsArrayAnim[animateIndex] - offset));



    }
    bool NextPointAnim() {
        animateIndex++; 
        if (animateIndex  == points.Count-1){
            setPointsAnimate = false;
            return false; 
        }
        targetAnimPos = pointsArrayAnim[animateIndex + 1];
        //Add another slo 
        lR.positionCount = animateIndex + 2;
        lR.SetPosition(animateIndex, pointsArrayAnim[animateIndex] - offset);
        lR.SetPosition(animateIndex+1, pointsArrayAnim[animateIndex] - offset);
        return true; 
    }

    void AnimateSetPoint() {

        Vector3 distance = targetAnimPos - currentAnimPos; 
        if (distance.magnitude <0.05f){
            if(NextPointAnim()) {
                return; 
            }

        }
        else {
            currentAnimPos = currentAnimPos + distance.normalized* speed*Time.deltaTime;
            lR.SetPosition(animateIndex + 1, currentAnimPos - offset);

        }



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
