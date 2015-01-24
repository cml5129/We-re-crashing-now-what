using UnityEngine;
using System.Collections;

public class RotateAlongX : MonoBehaviour {

	public float rotSpeed;

	void Update () {
		transform.Rotate(rotSpeed * Time.deltaTime,0,0);
	}
}
