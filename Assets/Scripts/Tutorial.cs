﻿using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public float duration;
	private float time = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= duration) {
			Destroy (this.gameObject);
		}
	}
}
