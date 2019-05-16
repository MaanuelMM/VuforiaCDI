using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomicController : MonoBehaviour {

	public GameObject H, C, N, O, Na, Cl;

	public GameObject H2OPrefab, CH4Prefab, NH3Prefab, COPrefab, CO2Prefab, NaClPrefab;

	private bool text = true;

	// Use this for initialization.
	void Start () {
		modificarTextos ();
	}

	// Update is called once per frame
	void Update ()
	{
		actualizarMoleculas ();
		if (Input.GetKeyDown (KeyCode.I))
			modificarTextos ();
	}

	private void actualizarMoleculas ()
	{
		actualizarMolecula (H, O, H2OPrefab, "H2O");
		actualizarMolecula (C, O, CO2Prefab, "CO2");
		actualizarMolecula (C, H, CH4Prefab, "CH4");
		actualizarMolecula (N, H, NH3Prefab, "NH3");
		actualizarMolecula (Na, Cl, NaClPrefab, "NaCl");
	}

	private void actualizarMolecula (GameObject Tarjeta1, GameObject Tarjeta2, GameObject Prefab, string nombre)
	{
		var Molecula = GameObject.Find (nombre);
		if (Vector3.Distance (Tarjeta1.transform.position, Tarjeta2.transform.position) < 10f
			& Tarjeta1.GetComponent<AtomicScript> ().isPresent ()
			& Tarjeta2.GetComponent<AtomicScript> ().isPresent ())
		{
			var Position = new Vector3 ((Tarjeta1.transform.position.x + Tarjeta2.transform.position.x) / 2f,
				               (Tarjeta1.transform.position.y + Tarjeta2.transform.position.y) / 2f,
				               (Tarjeta1.transform.position.z + Tarjeta2.transform.position.z) / 2f);
			if (!Molecula)
			{
				Tarjeta1.transform.GetChild (0).gameObject.SetActive (false);
				Tarjeta2.transform.GetChild (0).gameObject.SetActive (false);
				modificarTexto (Tarjeta1, false);
				modificarTexto (Tarjeta2, false);
				Tarjeta1.GetComponent<AtomicScript> ().incrementNumInstancias ();
				Tarjeta2.GetComponent<AtomicScript> ().incrementNumInstancias ();
				Molecula = (GameObject)Instantiate (Prefab, Position, new Quaternion (0f, 0f, 0f, 0f));
				Molecula.name = nombre;
			}
			else
			{
				Molecula.transform.position = Position;
			}
			modificarTexto (Molecula, text);
		}
		else if (Molecula)
		{
			Destroy (Molecula);
			Tarjeta1.GetComponent<AtomicScript> ().decrementNumInstancias ();
			Tarjeta2.GetComponent<AtomicScript> ().decrementNumInstancias ();
			if (Tarjeta1.GetComponent<AtomicScript> ().getNumInstancias () == 0)
			{
				Tarjeta1.transform.GetChild (0).gameObject.SetActive (true);
				if (text)
					modificarTexto (Tarjeta1, true);
			}
			if (Tarjeta2.GetComponent<AtomicScript> ().getNumInstancias () == 0)
			{
				Tarjeta2.transform.GetChild (0).gameObject.SetActive (true);
				if (text)
					modificarTexto (Tarjeta2, true);
			}
		}
	}

	private void modificarTextos ()
	{
		text = !text;
		if (H.GetComponent<AtomicScript> ().getNumInstancias () == 0)
			modificarTexto (H, text);
		if (C.GetComponent<AtomicScript> ().getNumInstancias () == 0)
			modificarTexto (C, text);
		if (N.GetComponent<AtomicScript> ().getNumInstancias () == 0)
			modificarTexto (N, text);
		if (O.GetComponent<AtomicScript> ().getNumInstancias () == 0)
			modificarTexto (O, text);
		if (Na.GetComponent<AtomicScript> ().getNumInstancias () == 0)
			modificarTexto (Na, text);
		if (Cl.GetComponent<AtomicScript> ().getNumInstancias () == 0)
			modificarTexto (Cl, text);
	}

	private void modificarTexto (GameObject objeto, bool valor)
	{
		objeto.transform.GetChild (1).gameObject.SetActive (valor);
	}

}
