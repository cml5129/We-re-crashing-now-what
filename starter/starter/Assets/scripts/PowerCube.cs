using UnityEngine;
using System.Collections;

public class PowerCube : MonoBehaviour {
	public Data data;
	public int HasPowerCubes;
	public int NeedsPowerCubes;
	public GameObject GainedCube;
	// Use this for initialization
	private float timeSince = 0;
	private float deltaBetweenInput = .5f;
	public bool Complete() {
		return NeedsPowerCubes == 0;
	}
	void Start () {
		data = GameObject.Find("Data").GetComponent<Data>();
	}
	
	// Update is called once per frame
	void Update () {
		timeSince += Time.deltaTime;
	
	}
	void OnTriggerStay(Collider other) {
		if((other.tag == "Player" || other.tag == "MainCamera") && (Input.GetButton("Jump") || Input.GetButton("Fire1")) && timeSince > deltaBetweenInput) {
			Debug.Log("you have "+data.PlayerPowerCubes+" and this has "+HasPowerCubes + " and needs " + NeedsPowerCubes+ " Power Cubes");
			if((Input.GetButton("Fire1") || Input.GetButton("Jump")) && HasPowerCubes > 0 && data.PlayerPowerCubes < 2) {
				foreach (Transform child in transform){
					if(child.gameObject.tag == GainedCube.tag){
						Destroy(child.gameObject);
						break;
					}
				}
				Debug.Log ("Lost Power Cube");
				HasPowerCubes--;
				var oldNeeds = NeedsPowerCubes;
				NeedsPowerCubes++;
				data.PlayerPowerCubes++;
				timeSince = 0;
				if (NeedsPowerCubes == 0 ){
					BroadcastMessage("SystemOn");
					data.CheckWin();
				} else if (oldNeeds == 0 && NeedsPowerCubes > 0) {
					BroadcastMessage("SystemOff");
				}

			}else if((Input.GetButton("Fire1")|| Input.GetButton("Jump")) && NeedsPowerCubes > 0 && data.PlayerPowerCubes > 0) {
				GameObject gainedCube = Instantiate(GainedCube) as GameObject;
				gainedCube.transform.parent = this.gameObject.transform;
				data.PlayerPowerCubes--;
				HasPowerCubes++;
				var oldNeeds = NeedsPowerCubes;
				NeedsPowerCubes--;
				timeSince = 0;
				Debug.Log ("Gained Power Cube");
				if (NeedsPowerCubes == 0 ){
					BroadcastMessage("SystemOn");
					data.CheckWin();
				} else if (oldNeeds == 0 && NeedsPowerCubes > 0) {
					BroadcastMessage("SystemOff");
				}
			}else if((Input.GetButton("Fire1")|| Input.GetButton("Jump")) && NeedsPowerCubes > 0 && data.PlayerPowerCubes == 0) {
				Debug.Log("playing");
				timeSince = 0;
				data.PlayNeedsPower();
			}
		}
	}
}
