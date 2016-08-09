using UnityEngine;
using System.Collections;

public class MakeTreeRandom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		// Make the tree scale slightly random
		float newHeightScale = Random.Range(-0.5F, 0.6F);
		float newWidthScale = Random.Range(-0.5F, 0.5F);
		float distanceFromTrack;

		transform.localScale += new Vector3(newWidthScale, newHeightScale, newWidthScale);
	}
}
