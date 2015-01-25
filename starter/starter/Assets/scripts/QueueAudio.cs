using UnityEngine;
using System.Collections;

public class QueueAudio : MonoBehaviour {
	public AudioClip[] clips;
	public Data data;
	// Use this for initialization
	void Start () {
		data = GameObject.Find("Data").GetComponent<Data>();
	}
	
	// Update is called once per frame
	void Update () {
		if (data.GameState == GameStates.Running) {
			foreach(var clip in clips) {
				data.audioManager.PlayAudio(clip);
			}
			Destroy(this.gameObject);
		}
	}
}
