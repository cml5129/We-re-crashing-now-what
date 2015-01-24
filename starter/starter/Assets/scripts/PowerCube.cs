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
	void Start () {
		data = GameObject.Find("Data").GetComponent<Data>();
	}
	
	// Update is called once per frame
	void Update () {
		timeSince += Time.deltaTime;
	
	}
	void OnTriggerStay(Collider other) {
		if((other.tag == "Player" || other.tag == "MainCamera") && Input.GetButton("Jump") && timeSince > deltaBetweenInput) {
			Debug.Log("you have "+data.PlayerPowerCubes+" and this has "+HasPowerCubes + " and needs " + NeedsPowerCubes+ " Power Cubes");
			if(HasPowerCubes > 0 && data.PlayerPowerCubes < 2) {
				foreach (Transform child in transform){
					if(child.gameObject.tag == GainedCube.tag){
						Destroy(child.gameObject);
						break;
					}
				}
				HasPowerCubes--;
				NeedsPowerCubes++;
				data.PlayerPowerCubes++;
				timeSince = 0;
			}else if(NeedsPowerCubes > 0 && data.PlayerPowerCubes > 0) {
				GameObject gainedCube = Instantiate(GainedCube) as GameObject;
				gainedCube.transform.parent = this.gameObject.transform;
				data.PlayerPowerCubes--;
				HasPowerCubes++;
				NeedsPowerCubes--;
				timeSince = 0;
			}
		}
	}
}
