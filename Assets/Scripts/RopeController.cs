using UnityEngine;
using System.Collections;

public class RopeController : MonoBehaviour {

    
    public Transform lampHandler;

    public int maxRopeFrameCount;
    public int ropeFrameCount;

    public LineRenderer lineRenderer;
	
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
	
	}
	
	
	void LateUpdate () {
        lineRenderer.SetVertexCount(2);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, lampHandler.position);
	}
}
