using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public BezierCurve path;
    public Transform target;

    private float percentage=0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (path != null && percentage<=1.0f)
        {
            transform.position = path.GetPointAt(percentage);
            percentage += Time.deltaTime;
        }
        if (target != null)
        {
            transform.LookAt(target);
        }
	}
}
