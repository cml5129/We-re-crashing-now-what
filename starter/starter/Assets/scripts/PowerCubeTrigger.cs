using UnityEngine;
using System.Collections;

public class PowerCubeTrigger : MonoBehaviour {
	public Data data;
	public AudioClip audioClipOn;
	public AudioClip audioClipOff;
	// Use this for initialization
	void Start () {
		data = GameObject.Find("Data").GetComponent<Data>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SystemOn() {
		Debug.Log("system on");
		if(audioClipOn != null) {
			data.audioManager.PlayAudio(audioClipOn);
		}
	}
	public void SystemOff() {
		Debug.Log("system off");
		if(audioClipOff != null) {
			data.audioManager.PlayAudio(audioClipOff);
		}
	}
}
