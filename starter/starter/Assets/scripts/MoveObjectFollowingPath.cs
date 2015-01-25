using UnityEngine;
using System.Collections;

public class MoveObjectFollowingPath : MonoBehaviour {
	public Transform objectToMove;
	public float speed;
	public Transform[] points;
	public int currentPoint;
	public Vector3? currentDestination;
	public float threshold = 1.0f;
	// Use this for initialization
	void Start () {
		if(points.Length > 0) {
			currentDestination = points[0].position;
			currentPoint = 0;
			transform.LookAt(currentDestination.Value);
		}
	}
	void Update() {
		if(currentDestination != null ) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, currentDestination.Value, step);
			if(Vector3.Distance(transform.position,currentDestination.Value) < threshold) {
				currentPoint++;
				if(currentPoint >= points.Length) {
					currentDestination = null;
				} else {
					currentDestination = points[currentPoint].position;
					transform.LookAt(currentDestination.Value);
				}
			}
		}
	}
}
