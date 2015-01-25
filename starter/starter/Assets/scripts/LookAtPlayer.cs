using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

	private Quaternion startRot;
	public Transform player;

	void Start () {
		startRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion desiredRot = Quaternion.LookRotation(player.position - transform.position);
		transform.rotation = Quaternion.Euler(0, 90, 0) * desiredRot; //startRot * desiredRot;
	}
}
