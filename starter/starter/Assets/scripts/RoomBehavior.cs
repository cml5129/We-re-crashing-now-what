using UnityEngine;
using System.Collections;

public class RoomBehavior : MonoBehaviour {

	public string roomName;
	public int currentSpareParts = 0;
	public int neededSpareParts = 4;
	
	private Transform player;

	void OnTriggerEnter(Collider other) {
		Debug.Log (roomName + " room currently has " + currentSpareParts + " out of the " + neededSpareParts + " spare parts to be active.");
		
		// Player object should receive this
		other.SendMessage("EnteredRoom", transform);
		player = other.transform;
	}
	
	void OnTriggerExit(Collider other) {
		Debug.Log ("You left the " + roomName + " room");
	
		other.SendMessage("LeftRoom");
		player = null;
	}
	
	// Player object should call this when dismantling
	void Dismantle () {
		if (currentSpareParts > 0) {
			--currentSpareParts;
			player.SendMessage("DismantleSuccess");
			Debug.Log(currentSpareParts + " / " + neededSpareParts);
		} else {
			player.SendMessage("DismantleFailed");
		}
	}
	
	// Player object should call this when putting in a spare part
	void Fix () {
		if (currentSpareParts < neededSpareParts) {
			++currentSpareParts;
			player.SendMessage("FixSuccess");
			Debug.Log(currentSpareParts + " / " + neededSpareParts);
		} else {
			player.SendMessage("FixFailed");
		}
	}
}
