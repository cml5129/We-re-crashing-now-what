using UnityEngine;
using System.Collections;

public class TimeLeft : MonoBehaviour {
	public float TotalTimeLeft;
	public bool Pause;
	public Data data;
	public float[] Queues;
	public AudioClip[] AudioQueue;
	public AudioClip StandardAudio;
	public bool[] QueueReached;
	public bool hud;
	public string text;
	// Use this for initialization
	void Start () {
		data = GameObject.Find("Data").GetComponent<Data>();
	}
	
	// Update is called once per frame
	void Update () {
		if(data.GameState == GameStates.Running && ! Pause) {
			TotalTimeLeft -= Time.deltaTime;
			for(int i = 0; i < Queues.Length; i++) {
				if (Queues[i] > TotalTimeLeft && !QueueReached[i]) {
					Debug.Log("PLay audio queue:"+i);
					data.audioManager.PlayAudio(StandardAudio,AudioQueue[i]);
					QueueReached[i] = true;
				}
			}
			if (TotalTimeLeft <= 0 ) {
				data.GameOver();
			}
		}
	}void OnGUI() {
		if(hud && data.GameState == GameStates.Running) {			
			GUI.Label(new Rect((Screen.width) - 100, Screen.height - 30, 200, 200), string.Format("{0}:{1}",text,TotalTimeLeft));
		}
		
	}
}
