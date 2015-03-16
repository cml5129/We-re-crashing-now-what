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
	public bool oculusMode;
	public AudioClip needsPower;
	public AudioClip win;
	public TimeLeft timer;
	public Menu menu;
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		initialCubes = PlayerPowerCubes;
		Screen.showCursor = false;
		menu = GameObject.FindObjectOfType<Menu>();
		if(Player == null) {
			Instantiate(BackupPlayer);
		}
		Player = GameObject.FindGameObjectWithTag("Player");
		audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
	}

	void Update() {
		if(oculusMode && GameState == GameStates.MainMenu && (Input.anyKeyDown || Input.GetAxis("Vertical") > 0)) {
			GameState = GameStates.Running;
		}
	}
	public void PlayNeedsPower() {
		audioManager.PlayAudio(needsPower);
	}
	public void GameOver() {
		Player.transform.position = new Vector3(-10,-10,-10);
		if (!oculusMode) {
			menu.EndGameLose();
		}
	}
	public void Win() {
		audioManager.PlayAudio(win);
		timer.Pause = true;
		if (!oculusMode) {
			menu.EndGameWin();
		}
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
