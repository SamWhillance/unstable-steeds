﻿using UnityEngine;
using System.Collections;

public class HorseController : MonoBehaviour {

	//public GameObject horseRoot;

	/*
	 * Default mass
	 * Hips and spine - 3.125
	 * Legs and feet - 1.875
	 * Arms, hands and head - 1.25
	 * */

	[Header("Thrust")]
	public float hipsUpwardConstant = 70F;
	public float spineUpwardConstant = 100F;
	public float spineForwardConstant = 5F;
	public float hipsForwardAction = 20F;
	public float hipsUpwardAction = 50F;
	public float spineForwardAction = 10F;
	public float spineUpwardAction = 10F;
	[Space(10)]

	[Header("Controls")]
	public string actionKey = "space";
	[Space(10)]

	[Header("Horse Parts")]
	public GameObject horseHead;
	public GameObject horseHips;
	public GameObject horseSpine;
	public GameObject horseRightLeg;
	public GameObject horseRightKnee;
	public GameObject horseLeftLeg;
	public GameObject horseLeftKnee;
	public GameObject horseRightArm;
	public GameObject horseRightElbow;
	public GameObject horseLeftArm;
	public GameObject horseLeftElbow;

	// Use this for initialization
	void Start () {
		horseHips = transform.Find("Root/Hips").gameObject;
		horseSpine = transform.Find("Root/Hips/Spine").gameObject;
		horseHead = transform.Find("Root/Hips/Spine/Spine1/Neck/Neck1/Neck2/Head").gameObject;
		horseRightLeg = transform.Find("Root/Hips/RightUpLeg").gameObject;
		horseRightKnee = transform.Find ("Root/Hips/RightUpLeg/Rightleg/RightFoot").gameObject;
		horseLeftLeg = transform.Find("Root/Hips/LeftUpLeg").gameObject;
		horseLeftKnee = transform.Find("Root/Hips/LeftUpLeg/LeftLeg/LeftFoot").gameObject;
		horseRightArm = transform.Find("Root/Hips/Spine/Spine1/Neck/RightArm").gameObject;
		horseRightElbow = transform.Find("Root/Hips/Spine/Spine1/Neck/RightArm/RightforeArm").gameObject;
		horseLeftArm = transform.Find("Root/Hips/Spine/Spine1/Neck/LeftArm").gameObject;
		horseLeftElbow = transform.Find("Root/Hips/Spine/Spine1/Neck/LeftArm/LeftForeArm").gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		// Apply a constant upward force to keep horse upright
		getHorsePartRigidBody(horseHips).AddForce(0, hipsUpwardConstant, 0, ForceMode.Force);
		getHorsePartRigidBody(horseSpine).AddForce(0, spineUpwardConstant, 0, ForceMode.Force);
		getHorsePartRigidBody(horseSpine).AddForce(0, 0, spineForwardConstant, ForceMode.Force);

		// If the action key is down
		if (Input.GetKeyDown(actionKey)) {
			print("action key was pressed");

			// Apply upward force to the hips/spine
			applyForwardForceImpulse(horseHips, hipsForwardAction);
			applyUpwardForceImpulse(horseHips, hipsUpwardAction);
			applyForwardForceImpulse(horseSpine, spineForwardAction);
			applyUpwardForceImpulse(horseSpine, spineUpwardAction);
		}
	}

	// Give this function a horse part, it will return its Rigid Body (for applying forces)
	Rigidbody getHorsePartRigidBody (GameObject aHorsePart) {
		return aHorsePart.GetComponent<Rigidbody>();
	}

	void applyForwardForceImpulse(GameObject aHorsePart, float aThrustValue){
		getHorsePartRigidBody(aHorsePart).AddForce(0, 0, aThrustValue, ForceMode.Impulse);
	}

	void applyUpwardForceImpulse(GameObject aHorsePart, float aThrustValue){
		getHorsePartRigidBody(aHorsePart).AddForce(0, aThrustValue, 0, ForceMode.Impulse);
	}
		
}
