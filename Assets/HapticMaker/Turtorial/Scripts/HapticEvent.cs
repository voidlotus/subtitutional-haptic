using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fofulab;
using Leap.Unity;

public class HapticEvent : MonoBehaviour {

    public enum TriggerType {None, TriggerEnter, TriggerExit, TriggerStay, CollisionEnter, CollisionExit, CollisionStay, KeyDown, KeyUp, Key}
    public TriggerType triggerType;
    public KeyCode Key;
    public int HMIndex;
    public HapticParams[] Actions;

    [Header("Input Haptic")] private HapticPinch hapticPinch;
    //public GameObject _pinchDetector;
    //private PinchDetector _pinch;
    //private float val;

    // Use this for initialization
    void Start () {
        //_pinch = _pinchDetector.GetComponent<PinchDetector>();
        hapticPinch = this.gameObject.GetComponent<HapticPinch>();
    }
	
	// Update is called once per frame
	void Update () {

        
        //Debug.Log("hapticEvent: " + hapticPinch.val);

        if (triggerType == TriggerType.KeyDown) {
            if (Input.GetKeyDown(Key)) {
                InvokeHaptic(HMIndex);
            }
        }

        if (triggerType == TriggerType.KeyUp) {
            if (Input.GetKeyUp(Key)) {
                InvokeHaptic(HMIndex);
            }
        }

        if (triggerType == TriggerType.Key) {
            if (Input.GetKey(Key)) {
                InvokeHaptic(HMIndex);
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(triggerType == TriggerType.CollisionEnter)
            InvokeHaptic(HMIndex);
    }

    private void OnCollisionExit(Collision collision) {
        if (triggerType == TriggerType.CollisionExit)
            InvokeHaptic(HMIndex);
    }

    private void OnCollisionStay(Collision collision) {
        if (triggerType == TriggerType.CollisionStay)
            InvokeHaptic(HMIndex);
    }

    private void OnTriggerEnter(Collider other) {
        if (triggerType == TriggerType.TriggerEnter)
            InvokeHaptic(HMIndex);
    }

    private void OnTriggerExit(Collider other) {
        if (triggerType == TriggerType.TriggerExit)
            InvokeHaptic(HMIndex);
    }

    private void OnTriggerStay(Collider other) {
        if (triggerType == TriggerType.TriggerStay)
            InvokeHaptic(HMIndex);
    }

    public void InvokeHaptic(int index = 0) {
        if (Actions != null) {
            for (int i = 0; i < Actions.Length; i++) {
                if (Actions[i] == null)
                    continue;

                int v = (int)(Actions[i].value * (Actions[i].type == PinType.SERVO ? 180 : 255));
                if (hapticPinch.val != null && Actions[i].type == PinType.SERVO)
                {
                    //float angleOffset = hapticPinch.val;
                    float angleOffset = (hapticPinch.val - 0.0f) * ((1.0f / 1.0f - 0.0f) * 180.0f);
                    //Debug.Log("Servo Raw Val: " + angleOffset);
                    Debug.Log("current/raw: " + v + " / " + angleOffset);
                    v = (int)Mathf.Clamp(v + angleOffset, 95, 180);
                    //v = 0 + (int)angleOffset;
                    Debug.Log("Angle: "+v);
                }
                else
                {
                    Debug.Log("Haptic Pinch is NULL");
                }
                HapticMakerManager.setValue(index, Actions[i].pin, v, Actions[i].type, Actions[i].curve, Actions[i].duration);
                if (Actions[i].changeDefaultValue) {
                    int dv = (int)(Actions[i].value * (Actions[i].type == PinType.SERVO ? 180 : 255));
                    HapticMakerManager.setDefaultValue(index, Actions[i].pin, dv, Actions[i].type);
                }
            }
        }
    }
}

[System.Serializable]
public class HapticParams {
    public OutputPin pin;
    [Range(0f, 1f)]
    public float value;
    public PinType type;
    public AnimationCurve curve;
    public float duration;

    public bool changeDefaultValue;
    [Range(0f, 1f)]
    public float defaultValue;
}
