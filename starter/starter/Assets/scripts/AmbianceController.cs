using UnityEngine;
using System.Collections;

public class AmbianceController : MonoBehaviour {

	public AudioSource source;
	public AudioClip EngineOnToOff;
	public AudioClip EngineOffToOn;
	public AudioClip EngineOn;
	public AudioClip EngineOff;
	public Queue AudioQueue;

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
			source.loop = true;
			source.Play();
		}	
	}

	public void EngineTurnedOn() {		
		if(EngineOffToOn != null) {
			source.clip = EngineOffToOn;
			source.loop = false;
			source.Play();
		}
		AudioQueue.Enqueue(EngineOn);
	}
	public void EngineTurnedOff() {		
		source.clip = EngineOff;
		source.loop = true;
		source.Play();
	}
}
