using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Light)) ]

public class FlickeringLight : MonoBehaviour {
		
	private float maxLightIntensity;
	private Light lightComponent;

	void Awake () {
		lightComponent = GetComponent<Light>();
		maxLightIntensity = lightComponent.intensity;
	}

	void OnEnable () {
		StartCoroutine("Flicker");
	}

	void OnDisable () {
		StopCoroutine("Flicker");
	}

	IEnumerator Flicker () {
		while (true) {
			lightComponent.intensity = 0;
			yield return new WaitForSeconds(Random.Range(0.2f, 0.7f));

			int count = Random.Range (1,5);
			while (count > 0) {
				lightComponent.intensity = Random.Range (0.5f, 1) * maxLightIntensity;
				yield return new WaitForSeconds(Random.Range (0.01f,0.9f) );

				lightComponent.intensity = 0;
				yield return new WaitForSeconds(Random.Range (0.01f,0.1f) );
				--count;
			}
		}
	}
}
