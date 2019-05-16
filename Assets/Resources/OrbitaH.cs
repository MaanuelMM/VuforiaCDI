using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitaH : MonoBehaviour {
	
	private GameObject orbita;

	void Start () {
		orbita = new GameObject { name = "OrbitaH1" };
		orbita.transform.SetParent (this.transform);
		orbita.transform.position = orbita.transform.parent.transform.position;
		orbita.DibujarOrbita (2f, .02f, 1);
	}

	void Update () {
		orbita.transform.Rotate (new Vector3(0f, 25f, 0f)*Time.deltaTime);
	}
}
