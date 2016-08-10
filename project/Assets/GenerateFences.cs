using UnityEngine;
using System.Collections;

public class GenerateFences : MonoBehaviour {

	public Transform fence;
	public Transform track;

	void Start () {

		float fenceWidth = fence.GetComponent<Renderer> ().bounds.extents.x*2.0F;
		float trackWidth = track.GetComponent<Renderer> ().bounds.extents.z;

		// Top Fence
		float fenceTopLeftX = track.position.x - track.GetComponent<Renderer>().bounds.extents.x;
		float fenceBottomLeftX = track.position.x + track.GetComponent<Renderer>().bounds.extents.x;
		float fenceTopLeftZ = track.position.z - track.GetComponent<Renderer>().bounds.extents.z;

		float currentZ = fenceTopLeftZ;

		Transform newFence;

		do {

			// Create top fence
			newFence = Instantiate (fence, new Vector3 (fenceTopLeftX, track.position.y, currentZ), Quaternion.Euler(0, 90, 0)) as Transform;
			newFence.parent = transform.FindChild("Top");

			//(Instantiate (fence, new Vector3 (fenceTopLeftX, track.position.y, currentZ), Quaternion.Euler(0, 90, 0)) as GameObject).transform.parent = this.transform;

			// Create bottom fence
			newFence = (Instantiate (fence, new Vector3 (fenceBottomLeftX, track.position.y, currentZ), Quaternion.Euler(0, 90, 0)) as Transform);
			newFence.parent = transform.FindChild("Bottom");;

			// Move position forward
			currentZ += fenceWidth;
		} while (currentZ < trackWidth);

	}
}
