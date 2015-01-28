using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour {
	public Data data;
	public AudioClip play;

	// Use this for initialization
	void Start () {
		data = GameObject.Find("Data").GetComponent<Data>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other) {
		if(other.tag == "Player" || other.tag == "MainCamera") {
			if(!data.audioManager.audio.isPlaying) {
				Debug.Log("Playing Room Queue");
				data.audioManager.PlayAudio(play);
				Destroy(this.gameObject);
			}
		}
	}
}
