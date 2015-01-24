using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {
	public static string title = "Title";
	public GameStates GameState;
	public GameObject Player;
	public int PlayerPowerCubes = 0;
	public AudioManager audioManager;

	public void GameOver() {
		Time.timeScale = 0;
		GameState = GameStates.GameOver;
	}
	public void Win() {
		Time.timeScale = 0;
		GameState = GameStates.WON;
	}
}
