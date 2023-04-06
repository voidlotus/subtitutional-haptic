using System.Collections;
using System.Collections.Generic;
using fofulab;
using Leap.Unity;
using UnityEngine;

public class HapticPinch : MonoBehaviour
{

    public GameObject _pinchDetector;
    private PinchDetector _pinch;
    public float val;

	// Use this for initialization
	void Start ()
    {
        _pinch = _pinchDetector.GetComponent<PinchDetector>();
        val = _pinch.GetPinchStrengthValue;
        //_pinch = _pinchDetector.GetComponent<PinchDetector>();
        //_pinch = gameObject.AddComponent<PinchDetector>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        val = _pinch.GetPinchStrengthValue;
        //Debug.Log("hapticPinch: "+val);
    }
}
