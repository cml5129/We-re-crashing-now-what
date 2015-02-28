using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public Data data;
	public Text information;
	public Text playButtonText;
	public Text quitButtonText;
	public Text titleText;	
	public Button playButton;
	public Button quitButton;
	public GameObject play;	
	public GameObject quit;
	public GameObject prefab;
	public GameObject visibleMenu;
	public GameObject canvas;

	// Use this for initialization
	void Start () {
		data = GameObject.Find("Data").GetComponent<Data>();
//		playButtonText = play.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
		quitButtonText = quitButton.gameObject.GetComponentInChildren<Text>();
		if(data.GameState== GameStates.MainMenu ||data.GameState== GameStates.Paused) {
			Time.timeScale = 0;
			showMenu();
			MainMenu();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Pause();
		}
	}
	void OnGUI() {
		Screen.showCursor = true;
		switch (data.GameState)
		{
		case GameStates.MainMenu:
			//MainMenu();
			break;
		case GameStates.Paused:
			//PauseMenu();
			break;
		case GameStates.GameOver:
			//GameOverMenu();
			break;
		case GameStates.WON:
			//WinMenu();
			break;
		case GameStates.Running:
			Screen.showCursor = false;
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
	void PrintTitle(string text = "") {
		titleText.text = Data.title;
		information.text = text + "Credits\nChris Spencer (www.sophiahatstudio.com; chris@chrisspencercreative.com)\nChris Lorenz <cml5129@gmail.com> https://lorenzgames.wordpress.com/ \nRobert Rood (therobertrood@gmail.com)\nVictor Brodin (vbrodin2@gmail.com)\nColby Welch <colwel@gmail.com>\nFrancis Joseph Serina (francis.serina@gmail; www.xeratol.com)\n" +
			"\nControls\n Space or Z or Jump: Take Power Cube\n ctrl or Fire1: Put Power Cube";
		//quitButtonText.text = "Quit";
		Debug.Log("Setting title:"+text);
		quitButton.onClick.AddListener(() => {
			Debug.Log("Quit button clicked");
			Quit();
		}); 

	}
	void MainMenu() {
		PrintTitle();
		//playButtonText.text = "Play";
		Debug.Log("Setting Play");
		playButton.onClick.AddListener(() => {
			Debug.Log("start button clicked");
			StartGame();
		});

	}
	void GameOverMenu() {
		playButtonText.text = "Retry";
		playButton.onClick.AddListener(() => {
			UnPause();
		});
		PrintTitle("Game Over\n");
	}
	void WinMenu() {
		playButtonText.text = "Restart";
		playButton.onClick.AddListener(() => {
			UnPause();
		});
		PrintTitle("Congratulations You Survived\n");
	}
	void PauseMenu() {
		playButtonText.text = "Continue";
		playButton.onClick.AddListener(() => {
			UnPause();
		});
		PrintTitle("PAUSED\n");
	}
	void Quit() {
		Application.Quit();
	}
	public void EndGameLose() {
		Time.timeScale = 0;
		data.GameState = GameStates.GameOver;
		showMenu();
		GameOverMenu();
	}
	public void EndGameWin() {
		Time.timeScale = 0;
		data.GameState = GameStates.WON;
		showMenu();
		WinMenu();
	}
	void Pause() {
		Time.timeScale = 0;
		data.GameState = GameStates.Paused;
		showMenu();
		PauseMenu();
	}
	void UnPause() {
		Time.timeScale = 1;
		data.GameState = GameStates.Running;
		hideMenu();
	}
	void StartGame() {
		Time.timeScale = 1;
		data.GameState = GameStates.Running;
		hideMenu();
		//TODO: Send message
	}
	void ReStartGame() {
		Time.timeScale = 1;
		data.GameState = GameStates.Running;
		hideMenu();
		Application.LoadLevel(Application.loadedLevel);
	}
	void showMenu() {
		visibleMenu = (GameObject)Instantiate(prefab);
		playButton = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<Button>();
		playButtonText = playButton.gameObject.GetComponentInChildren<Text>();
		quitButton = GameObject.FindGameObjectWithTag("QuitButton").GetComponent<Button>();
		quitButtonText = playButton.gameObject.GetComponentInChildren<Text>();
		information = GameObject.FindGameObjectWithTag("Information").GetComponent<Text>();
		//visibleMenu.transform.parent = canvas.transform;
	}
	void hideMenu() {
		Destroy(visibleMenu);
	}
}
