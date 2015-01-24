using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	AudioSource source;
	public AudioClip[] Queue;

	public void PlayAudio(AudioClip clip) {
		source.clip = clip;
		source.Play();
	}
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
