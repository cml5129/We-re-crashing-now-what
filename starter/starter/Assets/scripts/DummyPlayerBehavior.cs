using UnityEngine;
using System.Collections;

public class DummyPlayerBehavior : MonoBehaviour {

	public int sparePartsOnHand = 2;
	private Transform room;
	
	void EnteredRoom ( Transform enteredRoom ) {
		room = enteredRoom;
	}
	
	void LeftRoom () {
		room = null;
	}
	
	void DismantleSuccess () {
		++sparePartsOnHand;
		Debug.Log ("I acquired a spare part");
	}
	
	void DismantleFailed () {
		Debug.Log ("Room has no more spare parts");
	}
	
	void FixSuccess () {
		--sparePartsOnHand;
		Debug.Log("Placed a spare part");
	}
	
	void FixFailed () {
		Debug.Log ("Room has enough parts to work");
	}
	
	void Update () {
		if (room) {
			if (Input.GetKeyDown(KeyCode.Q)) {
				// Salvage
				room.SendMessage("Dismantle");
			} else if (Input.GetKeyDown(KeyCode.E)) {
				if (sparePartsOnHand > 0) {
					// Power Up
					room.SendMessage("Fix");
				} else {
					Debug.Log ("I don't have enough spare parts");
				}
			}
		}
	}
}
