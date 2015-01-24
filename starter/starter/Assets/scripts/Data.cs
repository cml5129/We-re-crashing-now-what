using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {
	public static string title = "Title";
	public GameStates GameState;
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
}
