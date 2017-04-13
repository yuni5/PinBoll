﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour {
	
	Material myMaterial;

	private float minEmission = 0.3f;

	private float magEmission = 2.0f;

	private int degree = 0;

	private int speed = 10;

	Color defaultColor = Color.white;

	// Use this for initialization
	void Start () {
		
		if (tag == "SmallStarTag") {
			this.defaultColor = Color.white;
		} else if (tag == "LargeStarTag") {
			this.defaultColor = Color.yellow;
		}else if(tag == "SmallCloudTag" || tag == "LargeCloudTag") {
			this.defaultColor = Color.blue;
		}

		this.myMaterial = GetComponent<Renderer> ().material;

		myMaterial.SetColor ("_EmissionColor", this.defaultColor*minEmission);
	}


	void Update () {

		if (this.degree >= 0) {
			
			Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magEmission);

			myMaterial.SetColor ("_EmissionColor", emissionColor);

			this.degree -= this.speed;
		}
	}

	void OnCollisionEnter(Collision other) {
		
		this.degree = 180;
	}
}
