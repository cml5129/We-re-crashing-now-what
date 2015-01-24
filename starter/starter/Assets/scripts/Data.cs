using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {
	public static string title = "Title";
	public GameStates GameState;
	public GameObject Player;
	public int PlayerPowerCubes = 0;
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
}
