using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	AudioSource source;
	public Queue AudioQueue;
	public Data data;

	public void PlayAudio(AudioClip clip) {
		source.clip = clip;
		source.Play();
	}
	public void PlayAudio(AudioClip clip1, AudioClip clip2) {
		source.clip = clip1;
		source.Play();
		AudioQueue.Enqueue(clip2);

	}
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		AudioQueue = new Queue();
	}
	
	// Update is called once per frame
	void Update () {
		if (!source.isPlaying && AudioQueue.Count > 0) {
			var clip = AudioQueue.Dequeue() as AudioClip;
			source.clip = clip;
			source.Play();
		}
	}
}
