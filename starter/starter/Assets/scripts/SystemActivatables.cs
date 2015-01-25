using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SystemActivatables : MonoBehaviour {

	private List<Transform> children;
	public bool initiallyOn;

	void Start () {
		children = new List<Transform>();
		foreach (Transform child in transform) {
			children.Add(child);
			child.SendMessage(initiallyOn ? "SystemOn" : "SystemOff", SendMessageOptions.DontRequireReceiver);
		}
	}

	void SystemOn () {
		foreach (Transform c in children) {
			c.gameObject.SetActive(true); // hack
			c.SendMessage("SystemOn", SendMessageOptions.DontRequireReceiver);
		}
	}

	void SystemOff () {
		foreach (Transform c in children) {
			c.gameObject.SetActive(true); // hack
			c.SendMessage("SystemOff", SendMessageOptions.DontRequireReceiver);
		}
	}
}
