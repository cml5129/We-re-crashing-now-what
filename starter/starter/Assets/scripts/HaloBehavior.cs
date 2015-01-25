using UnityEngine;
using System.Collections;

public class HaloBehavior : MonoBehaviour {

	void SystemOff () {
		GetComponent<Light>().color = Color.red;
	}

	void SystemOn () {
		GetComponent<Light>().color = Color.green;
	}
}
