using UnityEngine;
using System.Collections;

public class GenerateRocks : MonoBehaviour {

	public int minRocks;
	public int maxRocks;

	public Transform rock;

	void Start () {

		int numberOfRocks = (int)Random.Range ((float)minRocks, (float)maxRocks);
		print ("Creating "+numberOfRocks+" rocks");
		for (int i = 0; i < numberOfRocks; i++) {

			float randomScale = Random.Range (1.0F, 7.0F);

			// Random position within this transform
			Vector3 rndPosWithin;
			rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
			rndPosWithin = transform.TransformPoint(rndPosWithin * .5f);
			GameObject newRock = Instantiate(rock, rndPosWithin, transform.rotation) as GameObject;

			// Set as child of RockGenerator
			newRock.transform.parent = GameObject.Find("RockGenerator").transform;

			newRock.transform.localScale = new Vector3 (randomScale, randomScale, randomScale);
			//newRock.transform.rotation = Quaternion.Euler( Vector3 (0, Random.Range (0.0F, 360.0F), 0) );
		}
			
	}
}
