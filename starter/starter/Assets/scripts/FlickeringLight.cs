using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Light)) ]

public class FlickeringLight : MonoBehaviour {
		
	private float maxLightIntensity;
	private Light lightComponent;

	IEnumerator Start () {
		lightComponent = GetComponent<Light>();
		maxLightIntensity = lightComponent.intensity;

		while (true) {
			lightComponent.intensity = 0;
			yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));

			int count = Random.Range (1,5);
			while (count > 0) {
				lightComponent.intensity = Random.Range (0.2f, maxLightIntensity);
				yield return new WaitForSeconds(Random.Range (0.01f,0.3f) );

				lightComponent.intensity = 0;
				yield return new WaitForSeconds(Random.Range (0.05f,0.3f) );
				--count;
			}
		}
	}
}
