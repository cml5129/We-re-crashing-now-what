using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour {
	public Data data;
	public AudioClip play;
	public PowerCube powerCube;
	public PowerCube powerCube2;
	public bool deleteAfterPlay;
	public bool playDuringOff;
	public bool playDuringOn;
	public bool deleteAfterOn;
	public bool deleteAfterOff;
	// Use this for initialization
	void Start () {
		data = GameObject.Find("Data").GetComponent<Data>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player" || other.tag == "MainCamera") {
			if(!data.audioManager.audio.isPlaying && (isCubesOff() && playDuringOff || isCubesOn()  && playDuringOn)) {
				Debug.Log("Playing Room Queue");
				data.audioManager.PlayAudio(play);
				if(deleteAfterPlay) {
					Destroy(this.gameObject);
				}
			}
			if (isCubesOn() && deleteAfterOn) {
				Destroy(this.gameObject);
			}
			if (isCubesOff() && deleteAfterOff) {
				Destroy(this.gameObject);
			}
		}
	}
	public bool isCubesOff() {
		return powerCube.NeedsPowerCubes > 0 || (powerCube2 != null && powerCube2.NeedsPowerCubes > 0);
	}
	public bool isCubesOn() {
		return powerCube.NeedsPowerCubes < 1 || (powerCube2 != null && powerCube2.NeedsPowerCubes < 1);
	}
}
