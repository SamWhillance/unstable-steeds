using UnityEngine;
using System.Collections;

public class HorseController : MonoBehaviour {

	public GameObject horseRoot;
	public GameObject horseHead;
	public GameObject horseRightLeg;
	public GameObject horseRightKnee;
	public GameObject horseLeftLeg;
	public GameObject horseLeftKnee;

	public GameObject horseRightArm;
	public GameObject horseRightElbow;
	public GameObject horseLeftArm;
	public GameObject horseLeftElbow;

	private Rigidbody horseRightLegRigid;

	public float actionThrust = 50F;
	string actionKey = "space";

	// Use this for initialization
	void Start () {
		/*horseRoot = transform.Find("Root").gameObject;
		horseHead = transform.Find("Root/Hips/Spine/Spine1/Neck/Neck1/Neck2/Head").gameObject;
		horseRightLeg = transform.Find("Root/Hips/RightUpLeg").gameObject;
		horseLeftLeg = transform.Find("Root/Hips/LeftUpLeg").gameObject;
		horseRightKnee = transform.Find("Root/Hips/RightUpLeg/Rightleg/RightFoot").gameObject;
		horseLeftKnee = transform.Find("Root/Hips/LeftUpLeg/LeftLeg/LeftFoot").gameObject;*/

		horseRightLegRigid = transform.Find("Root/Hips/RightUpLeg").GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		// If the action key is down
		if (Input.GetKeyDown(actionKey)) {
			print("action key was pressed");

			// Apply force
			horseRightLegRigid.AddForce(0, 0, actionThrust, ForceMode.Impulse);
		}
	}
}
