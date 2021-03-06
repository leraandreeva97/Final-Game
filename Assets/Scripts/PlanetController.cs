﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {

	public GameObject[] Planets;

	Queue<GameObject> availablePlanets = new Queue<GameObject>();

	// Use this for initialization
	void Start () {

		availablePlanets.Enqueue (Planets [0]);
		availablePlanets.Enqueue (Planets [1]);
		availablePlanets.Enqueue (Planets [2]);
		availablePlanets.Enqueue (Planets [3]);
		availablePlanets.Enqueue (Planets [4]);
		availablePlanets.Enqueue (Planets [5]);
		availablePlanets.Enqueue (Planets [6]);
		availablePlanets.Enqueue (Planets [7]);
		availablePlanets.Enqueue (Planets [8]);
		availablePlanets.Enqueue (Planets [9]);

		InvokeRepeating ("MovePlanetDown", 0, 20f);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MovePlanetDown(){

		EnqueuePlanets ();

		if (availablePlanets.Count == 0)
			return;

		GameObject aPlanet = availablePlanets.Dequeue ();

		aPlanet.GetComponent<Planet> ().isMoving = true;

	}

	void EnqueuePlanets(){

		foreach (GameObject aPlanet in Planets) {

			if ((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<Planet>().isMoving)) {
				
				aPlanet.GetComponent<Planet>().ResetPosition ();

				availablePlanets.Enqueue(aPlanet);
			}

		}
	}
}
