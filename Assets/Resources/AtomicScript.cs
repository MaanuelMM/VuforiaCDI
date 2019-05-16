using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AtomicScript : MonoBehaviour, ITrackableEventHandler {

	private bool present = false;

	private int numInstancias = 0;

	private TrackableBehaviour mTrackableBehaviour;

	void Start ()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	public void OnTrackableStateChanged (TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			present = true;
		}
		else
		{
			present = false;
		}
	}

	public bool isPresent ()
	{
		return present;
	}

	public int getNumInstancias ()
	{
		return numInstancias;
	}

	public void incrementNumInstancias ()
	{
		numInstancias++;
	}

	public void decrementNumInstancias ()
	{
		numInstancias--;
	}

}
