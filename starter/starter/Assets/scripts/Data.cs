using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {
	public static string title = "Imminent Uncertainty";
	public GameStates GameState;
	public GameObject Player;
	public int PlayerPowerCubes ;
	public AudioManager audioManager;
	public PowerCube[] WinningPowerStations;
	private int initialCubes;
	public GameObject BackupPlayer;
	public Menu menu;
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		initialCubes = PlayerPowerCubes;
		Screen.showCursor = false;
		Player = GameObject.FindGameObjectWithTag("Player");
		menu = GameObject.FindObjectOfType<Menu>();
		if(Player == null) {
			Instantiate(BackupPlayer);
		}
		audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
	}

	public void GameOver() {
		menu.EndGameLose();
	}
	public void Win() {
		menu.EndGameWin();
	}
	public void CheckWin() {
		foreach(PowerCube Cube in WinningPowerStations) {
			if(!Cube.Complete()) {
				return;
			}
		}
		Win ();
	}

}
