using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

	public GameObject H, C, N, O, Na, Cl;

	public GameObject H2OPrefab, CH4Prefab, NH3Prefab, COPrefab, CO2Prefab, NaClPrefab;

	private GameObject H2O, CH4, NH3, CO, CO2, NaCl;

	// Use this for initialization.
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (H.transform.position, O.transform.position) < 10f
		    & H.GetComponent<AtomicScript> ().isPresent ()
		    & O.GetComponent<AtomicScript> ().isPresent ())
		{
			if (!GameObject.Find ("H2O")) {
				H.transform.GetChild (0).gameObject.SetActive (false);
				O.transform.GetChild (0).gameObject.SetActive (false);
				H2O = (GameObject)Instantiate (H2OPrefab, new Vector3 ((H.transform.position.x + O.transform.position.x) / 2f,
					(H.transform.position.y + O.transform.position.y) / 2f,
					(H.transform.position.z + O.transform.position.z) / 2f),
					new Quaternion ((H.transform.rotation.x + O.transform.rotation.x) / 2f,
						(H.transform.rotation.y + O.transform.rotation.y) / 2f,
						(H.transform.rotation.z + O.transform.rotation.z) / 2f,
						(H.transform.rotation.w + O.transform.rotation.w) / 2f));
				H2O.name = "H2O";
			}
			else
			{
				H2O.transform.position = new Vector3 ((H.transform.position.x + O.transform.position.x) / 2f,
					(H.transform.position.y + O.transform.position.y) / 2f,
					(H.transform.position.z + O.transform.position.z) / 2f);
				H2O.transform.rotation = new Quaternion ((H.transform.rotation.x + O.transform.rotation.x) / 2f,
					(H.transform.rotation.y + O.transform.rotation.y) / 2f,
					(H.transform.rotation.z + O.transform.rotation.z) / 2f,
					(H.transform.rotation.w + O.transform.rotation.w) / 2f);
			}
		}
		else if (GameObject.Find ("H2O"))
		{
			Destroy (H2O);
			H.transform.GetChild (0).gameObject.SetActive (true);
			O.transform.GetChild (0).gameObject.SetActive (true);
		}
	}
}
