﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitaCl : MonoBehaviour {

	private GameObject orbita1, orbita2, orbita3;

	void Start () {
		orbita1 = new GameObject { name = "OrbitaCl1" };
		orbita2 = new GameObject { name = "OrbitaCl2" };
		orbita3 = new GameObject { name = "OrbitaCl2" };
		orbita1.transform.SetParent (this.transform);
		orbita2.transform.SetParent (this.transform);
		orbita3.transform.SetParent (this.transform);
		orbita1.transform.position = orbita1.transform.parent.transform.position;
		orbita2.transform.position = orbita2.transform.parent.transform.position;
		orbita3.transform.position = orbita3.transform.parent.transform.position;
		orbita1.DibujarOrbita (2f, .02f, 2);
		orbita2.DibujarOrbita (2.5f, .02f, 8);
		orbita3.DibujarOrbita (3f, .02f, 7);
	}

	void Update () {
		orbita1.transform.Rotate (new Vector3(0f, 25f, 0f)*Time.deltaTime);
		orbita2.transform.Rotate (new Vector3(0f, -25f, 0f)*Time.deltaTime);
		orbita3.transform.Rotate (new Vector3(0f, 25f, 0f)*Time.deltaTime);
	}
}
