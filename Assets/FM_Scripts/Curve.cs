using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[ExecuteInEditMode]
public class Curve : MonoBehaviour {


	private List<GameObject> controlPoints = new List<GameObject>();
	public Color color = Color.white;
	public float width = 0.2f;
	public int numberOfPoints = 20;

	[Range(0,1)]public float moveT;
	public int moveJ;



	// Use this for initialization
	void Start () {

		LineRenderer lineRender = GetComponent<LineRenderer>();
		if (null == lineRender)
		{
			gameObject.AddComponent<LineRenderer>();
		}
		lineRender = GetComponent<LineRenderer>();
		lineRender.useWorldSpace = true;
		lineRender.material = new Material(
			Shader.Find("Particles/Additive"));
		foreach(Transform child in transform){
			
			controlPoints.Add(child.gameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	

		#region Display the line Render
		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		if (null == lineRenderer || controlPoints == null 
		    || controlPoints.Count< 3)
		{
			return; // not enough points specified
		} 
		// update line renderer
		lineRenderer.SetColors(color, color);
		lineRenderer.SetWidth(width, width);
		if (numberOfPoints < 2)
		{
			numberOfPoints = 2;
		}
		lineRenderer.SetVertexCount(numberOfPoints * 
		                            (controlPoints.Count - 2));
		Vector3 p0;
		Vector3 p1;
		Vector3 p2;

		for (int j = 0; j < controlPoints.Count - 2; j++)
		{
			// check control points
			if (controlPoints[j] == null || 
			    controlPoints[j + 1] == null ||
			    controlPoints[j + 2] == null)
			{
				return;  
			}
			// determine control points of segment
			p0 = 0.5f * (controlPoints[j].transform.position 
			            + controlPoints[j + 1].transform.position);
			p1 = controlPoints[j + 1].transform.position;
			p2 = 0.5f * (controlPoints[j + 1].transform.position 
			            + controlPoints[j + 2].transform.position);
			
			// set points of quadratic Bezier curve
			Vector3 position;
			float t; 
			float pointStep = 1.0f / numberOfPoints;
			if (j == controlPoints.Count - 3)
			{
				pointStep = 1.0f / (numberOfPoints - 1.0f);
				// last point of last segment should reach p2
			}  
			for(int i = 0; i < numberOfPoints; i++) 
			{
				t = i * pointStep ;
				t = i / (numberOfPoints - 1.0f);
				position = BCurve(p0,p1,p2,t);
				/*position = (1.0f - t) * (1.0f - t) * p0 
					+ 2.0f * (1.0f - t) * t * p1
						+ t * t * p2; 
				 */
			  
				lineRenderer.SetPosition(i + j * numberOfPoints, position);
			//	                        
			}



		}
		#endregion




	
	}
	//bezier formula
	 public static Vector3 BCurve(Vector3 P0, Vector3 P1, Vector3 P2, float t){
		return  (1.0f - t) * (1.0f - t) * P0 
			  + 2.0f * (1.0f - t) * t * P1
				+ t * t * P2;
	}











	
}
