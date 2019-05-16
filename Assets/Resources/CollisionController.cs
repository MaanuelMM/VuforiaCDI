using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

	public GameObject H, C, N, O, Na, Cl;

	public GameObject H2OPrefab, CH4Prefab, NH3Prefab, COPrefab, CO2Prefab, NaClPrefab;

	// Use this for initialization.
	void Start () {
		
	}

	// Update is called once per frame
	void Update ()
	{
		crearMolecula (H, O, H2OPrefab, "H2O");
		crearMolecula (C, O, CO2Prefab, "CO2");
		crearMolecula (C, H, CH4Prefab, "CH4");
		crearMolecula (N, H, NH3Prefab, "NH3");
		crearMolecula (Na, Cl, NaClPrefab, "NaCl");
	}

	private void crearMolecula (GameObject Tarjeta1, GameObject Tarjeta2, GameObject Prefab, string nombre)
	{
		var Molecula = GameObject.Find (nombre);
		if (Vector3.Distance (Tarjeta1.transform.position, Tarjeta2.transform.position) < 10f
			& Tarjeta1.GetComponent<AtomicScript> ().isPresent ()
			& Tarjeta2.GetComponent<AtomicScript> ().isPresent ())
		{
			Tarjeta1.transform.GetChild (0).gameObject.SetActive (false);
			Tarjeta2.transform.GetChild (0).gameObject.SetActive (false);
			if (!Molecula) {
				Molecula = (GameObject)Instantiate (Prefab, new Vector3 ((Tarjeta1.transform.position.x + Tarjeta2.transform.position.x) / 2f,
					(Tarjeta1.transform.position.y + Tarjeta2.transform.position.y) / 2f,
					(Tarjeta1.transform.position.z + Tarjeta2.transform.position.z) / 2f),
					new Quaternion ((Tarjeta1.transform.rotation.x + Tarjeta2.transform.rotation.x) / 2f,
						(Tarjeta1.transform.rotation.y + Tarjeta2.transform.rotation.y) / 2f,
						(Tarjeta1.transform.rotation.z + Tarjeta2.transform.rotation.z) / 2f,
						(Tarjeta1.transform.rotation.w + Tarjeta2.transform.rotation.w) / 2f));
				Molecula.name = nombre;
			}
			else
			{
				Molecula.transform.position = new Vector3 ((Tarjeta1.transform.position.x + Tarjeta2.transform.position.x) / 2f,
					(Tarjeta1.transform.position.y + Tarjeta2.transform.position.y) / 2f,
					(Tarjeta1.transform.position.z + Tarjeta2.transform.position.z) / 2f);
				Molecula.transform.rotation = new Quaternion ((Tarjeta1.transform.rotation.x + Tarjeta2.transform.rotation.x) / 2f,
					(Tarjeta1.transform.rotation.y + Tarjeta2.transform.rotation.y) / 2f,
					(Tarjeta1.transform.rotation.z + Tarjeta2.transform.rotation.z) / 2f,
					(Tarjeta1.transform.rotation.w + Tarjeta2.transform.rotation.w) / 2f);
			}
		}
		else if (Molecula)
		{
			Destroy (Molecula);
			Tarjeta1.transform.GetChild (0).gameObject.SetActive (true);
			Tarjeta2.transform.GetChild (0).gameObject.SetActive (true);
		}
	}

}
