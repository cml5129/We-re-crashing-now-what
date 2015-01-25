using UnityEngine;
using System.Collections;

public class PowerCubeTrigger : MonoBehaviour {
	public Data data;
	public AudioClip audioClipOn;
	public AudioClip audioClipOff;
	public Material materialOn;
	public Material materialOff;
	public MeshRenderer renderer;
	public AudioSource source;
	// Use this for initialization
	void Start () {
		data = GameObject.Find("Data").GetComponent<Data>();
		source = GetComponent<AudioSource>();
		renderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SystemOn() {
		if(audioClipOn != null) {
			source.clip = audioClipOn;
			source.Play();
		}
		if (materialOn != null) {
			renderer.material = materialOn;
		}
	}
	public void SystemOff() {
		if(audioClipOff != null) {
			source.clip = audioClipOff;
			source.Play();
		}
		if (materialOff != null) {
			renderer.material = materialOff;
		}
	}
}
