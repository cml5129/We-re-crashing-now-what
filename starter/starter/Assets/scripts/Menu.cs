using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Data data;

	// Use this for initialization
	void Start () {
		if(data.GameState== GameStates.MainMenu ||data.GameState== GameStates.Paused) {
			Time.timeScale = 0;
		}
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
		case GameStates.GameOver:
			GameOverMenu();
			break;
		case GameStates.WON:
			WinMenu();
			break;
		case GameStates.Running:
			HUD();
			break;
		}
		
	}
	void HUD() {
		string cubes = "";
		if(data.PlayerPowerCubes > 2) {
			cubes = "ERROR";
		}
		if(data.PlayerPowerCubes > 1) {
			cubes = "two";
		} else if (data.PlayerPowerCubes > 0) {
			cubes = "one";
		}
		GUI.Label(new Rect(10, 10, 500, 200), cubes);
	}
	void PrintTitle() {
		GUIStyle myStyle = new GUIStyle(GUI.skin.label);
		myStyle.fontSize = 50;
		GUI.Label(new Rect((Screen.width / 2) - 25, 10, 200, 200), Data.title,myStyle);
	}
	void MainMenu() {
		PrintTitle();
		if (GUI.Button(new Rect((Screen.width / 2) - 50, Screen.height - 100 , 100, 50), "Start")) {
			StartGame();
		}
	}
	void GameOverMenu() {
		PrintTitle();
		GUI.Label(new Rect((Screen.width / 2) - 25, 110, 200, 200), "Game Over");
		if (GUI.Button(new Rect((Screen.width / 2) - 50, Screen.height - 100 , 100, 50), "Quit")) {
			Application.Quit();
		}
		if (GUI.Button(new Rect((Screen.width / 2) - 50, Screen.height - 200 , 100, 50), "Restart")) {
			ReStartGame();
		}
	}
	void WinMenu() {
		PrintTitle();
		GUI.Label(new Rect((Screen.width / 2) - 25, 110, 200, 200), "Congratulations You Survived");
		if (GUI.Button(new Rect((Screen.width / 2) - 50, Screen.height - 100 , 100, 50), "Quit")) {
			Application.Quit();
		}
		if (GUI.Button(new Rect((Screen.width / 2) - 50, Screen.height - 200 , 100, 50), "Retry")) {
			ReStartGame();
		}
	}
	void PauseMenu() {
		PrintTitle();
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
	void ReStartGame() {
		Time.timeScale = 1;
		data.GameState = GameStates.Running;
		Application.LoadLevel(Application.loadedLevel);
		//TODO: Send message
	}
}
