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
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		initialCubes = PlayerPowerCubes;
		Screen.showCursor = false;
		Player = GameObject.FindGameObjectWithTag("Player");
		if(Player == null) {
			Instantiate(BackupPlayer);
		}
		audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
	}

	public void GameOver() {
		Time.timeScale = 0;
		PlayerPowerCubes = initialCubes;
		GameState = GameStates.GameOver;
	}
	public void Win() {
		Time.timeScale = 0;
		PlayerPowerCubes = initialCubes;
		GameState = GameStates.WON;
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
