using UnityEngine;
using System.Collections;

public class SystemLightBehavior : MonoBehaviour {

	// checked for lights that should be on when system is fixed
	// unchecked for lights that should be on when system is broken
	public bool OnWhenFixed = true;

	void SystemOn () {
		gameObject.SetActive(OnWhenFixed);
	}

	void SystemOff () {
		gameObject.SetActive(!OnWhenFixed);
	}
}
