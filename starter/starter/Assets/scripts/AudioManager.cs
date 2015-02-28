using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	AudioSource source;
	public GameObject AudioSources;
	public Queue AudioQueue;
	public Data data;

	private bool paused;

	public void PlayAudio(AudioClip clip) {
		AudioQueue.Enqueue(clip);
	}
	public void PlayAudio(AudioClip clip1, AudioClip clip2) {
		AudioQueue.Enqueue(clip1);
		AudioQueue.Enqueue(clip2);

	}
	// Use this for initialization
	void Start () {
		source = AudioSources.GetComponent<AudioSource>();
		AudioQueue = new Queue();
		paused = false;
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
