using UnityEngine;
using System.Collections;

public class RobotController : MonoBehaviour {
	public bool PersonInRange;
	public float ChanceRobot;
	public float TimeBetweenChecks;
	public PowerCube StealFromPower;
	private float TimeSince;
	public GameObject Robot;
	// Use this for initialization
	void Start () {
		TimeSince = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!PersonInRange) {
			TimeSince += Time.deltaTime;
			if(TimeSince > TimeBetweenChecks) {
				if (StealFromPower.HasPowerCubes > 0 && Random.value < ChanceRobot) {
					Instantiate(Robot);
					StealFromPower.HasPowerCubes--;
				}
				TimeSince = 0;
			}
		}
	}
	void OnTriggerEnter(Collider other) {
		if((other.tag == "Player" || other.tag == "MainCamera") ) {
			PersonInRange = true;
		}
	}
	void OnTriggerExit(Collider other) {
		if((other.tag == "Player" || other.tag == "MainCamera") ) {
			PersonInRange = false;
		}
	}
}
