using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
		
	public AudioSource source;
	public AudioClip EngineOnToOff;
	public AudioClip EngineOffToOn;
	public AudioClip EngineOn;
	public AudioClip EngineOff;
	public AudioClip Low;
	public AudioClip Medium;
	public AudioClip High;
	public AudioClip transition1;
	public AudioClip transition2;
	public Queue AudioQueue;
	public TimeLeft timeLeft;
	public float startTransition1;
	public float startTransition2;
	public bool tran1 = false;
	public bool med = false;
	public bool high = false;
	public bool tran2 = false;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		AudioQueue = new Queue();
		timeLeft = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimeLeft>();
	}
		
		// Update is called once per frame
	void Update () {
		if (timeLeft.TotalTimeLeft < startTransition1 && !tran1) {
		Debug.Log("Starting Transition");
			var newAudio = this.gameObject.AddComponent<AudioSource>();
			newAudio.clip = transition1;
			newAudio.loop = false;
			newAudio.Play();
			source.Stop();
			tran1 = true;
		}	
		if (timeLeft.TotalTimeLeft < startTransition1-4 && !med) {
			Debug.Log("Ending Transition playing middle");
			source.clip = Medium;
			source.loop = true;
				source.Play();
				med = true;
			}	
		if (timeLeft.TotalTimeLeft < startTransition2 && !tran2) {
			Debug.Log("Starting Transition");
			var newAudio = this.gameObject.AddComponent<AudioSource>();
			newAudio.clip = transition2;
			newAudio.loop = false;
			newAudio.Play();
			source.Stop();
			tran2 = true;
		}	
		if (timeLeft.TotalTimeLeft < startTransition2-4 && !high) {
			Debug.Log("Ending Transition playing high");
			source.clip = High;
			source.loop = true;
			source.Play();
			high = true;
		}
	}
}
		
