using UnityEngine;
using System.Collections;

public class RotateAlongX : MonoBehaviour {

	public Vector3 axis;
	public float rotSpeed;

	void Update () {
		transform.Rotate(axis * rotSpeed * Time.deltaTime);
	}
}
