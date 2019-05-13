using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitaH : MonoBehaviour {
	
	public GameObject parent;

	private GameObject orbita;

	void Start () {
		orbita = new GameObject { name = "OrbitaH" };
		orbita.transform.SetParent (parent.transform);
		orbita.transform.position = orbita.transform.parent.transform.position;
		orbita.DibujarOrbita (2f, .02f, 1);
	}

	void Update () {
		orbita.transform.Rotate (0f, 1.25f, 0f);
	}
}
