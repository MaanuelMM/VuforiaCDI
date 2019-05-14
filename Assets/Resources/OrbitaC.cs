using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitaC : MonoBehaviour {

	private GameObject orbita1, orbita2;

	void Start () {
		orbita1 = new GameObject { name = "OrbitaC1" };
		orbita2 = new GameObject { name = "OrbitaC2" };
		orbita1.transform.SetParent (this.transform);
		orbita2.transform.SetParent (this.transform);
		orbita1.transform.position = orbita1.transform.parent.transform.position;
		orbita2.transform.position = orbita2.transform.parent.transform.position;
		orbita1.DibujarOrbita (2f, .02f, 2);
		orbita2.DibujarOrbita (2.5f, .02f, 4);
	}

	void Update () {
		orbita1.transform.Rotate (0f, 1.25f, 0f);
		orbita2.transform.Rotate (0f, -1.25f, 0f);
	}
}
