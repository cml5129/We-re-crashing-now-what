using UnityEngine;
using System.Collections;

public class HaloBehavior : MonoBehaviour {

	void OnBroken () {
		GetComponent<Light>().color = Color.red;
	}

	void OnFix () {
		GetComponent<Light>().color = Color.green;
	}
}
