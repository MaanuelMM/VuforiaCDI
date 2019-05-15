using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

	public GameObject H, C, N, O, Na, Cl;

	// Use this for initialization.
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (Vector3.Distance(H.transform.position, O.transform.position));
		Debug.Log (H.GetComponent<AtomicScript> ().isPresent ());
		Debug.Log (O.GetComponent<AtomicScript> ().isPresent ());
		if (Vector3.Distance (H.transform.position, O.transform.position) < 10f & H.GetComponent<AtomicScript> ().isPresent () & O.GetComponent<AtomicScript> ().isPresent ()) {
			H.transform.GetChild (0).gameObject.SetActive (false);
			O.transform.GetChild (0).gameObject.SetActive (false);
		} else {
			H.transform.GetChild (0).gameObject.SetActive (true);
			O.transform.GetChild (0).gameObject.SetActive (true);
		}
	}
}
