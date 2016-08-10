using UnityEngine;
using System.Collections;

public class GenerateRocks : MonoBehaviour {

	public int minRocks;
	public int maxRocks;

	public Transform boundingBox;
	public Transform rock;

	void Start () {

		if (boundingBox == null) {
			Debug.LogError ("Rock generator not given a bounding box");
		}

		int numberOfRocks = (int)Random.Range ((float)minRocks, (float)maxRocks);
		print ("Laying down "+numberOfRocks+" rocks");

		Transform newRock;
		float randomScale;

		for (int i = 0; i < numberOfRocks; i++) {

			// Randomize scale
			randomScale = Random.Range (0.1F, 3.0F);

			// Random position within this transform
			Vector3 rndPosWithin;
			rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
			rndPosWithin = boundingBox.TransformPoint(rndPosWithin * .5f);

			var randomRotation = Quaternion.Euler( Random.Range(0, 360) , 0 , 0);

			// Instantiate
			newRock = Instantiate(rock, rndPosWithin, randomRotation) as Transform;
			newRock.parent = this.transform.FindChild("GeneratedRocks");

			//newRock.Rotate (new Vector3 (10F, 10F, 10F));
			newRock.localScale += new Vector3 (randomScale, randomScale, randomScale);
		}
			
	}
}
