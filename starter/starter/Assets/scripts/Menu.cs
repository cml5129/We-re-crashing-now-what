using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Data data;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Pause();
		}
	}
	void OnGUI() {
		switch (data.GameState)
		{
		case GameStates.MainMenu:
			MainMenu();
			break;
		case GameStates.Paused:
			PauseMenu();
			break;
		}
		
	}
	void MainMenu() {
		GUI.Label(new Rect((Screen.width / 2) - 25, 10, 200, 200), Data.title);
		if (GUI.Button(new Rect((Screen.width / 2) - 50, Screen.height - 100 , 100, 50), "Start")) {
			StartGame();
		}
	}
	void PauseMenu() {
		GUI.Label(new Rect((Screen.width / 2) - 25, 10, 200, 200), Data.title);
		GUI.Label(new Rect((Screen.width / 2) - 25, 110, 200, 200), "PAUSED");
		if (GUI.Button(new Rect((Screen.width / 2) - 50, Screen.height - 100 , 100, 50), "Quit")) {
			Application.Quit();
		}
		if (GUI.Button(new Rect((Screen.width / 2) - 50, Screen.height - 200 , 100, 50), "Continue")) {
			UnPause();
		}
	}
	void Pause() {
		Time.timeScale = 0;
		data.GameState = GameStates.Paused;
	}
	void UnPause() {
		Time.timeScale = 1;
		data.GameState = GameStates.Running;
	}
	void StartGame() {
		Time.timeScale = 1;
		data.GameState = GameStates.Running;
		//TODO: Send message
	}
}
