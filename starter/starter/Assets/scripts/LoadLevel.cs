using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Awake() {
		Application.LoadLevelAdditive("Level01b");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
