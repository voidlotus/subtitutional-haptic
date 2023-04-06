//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using Leap;
//using Leap.Unity.Interaction;
//using UnityEngine;

//public class TryPinchStrength : MonoBehaviour
//{

//    Controller controller;

//    private Frame frame;

//    private Frame previous;
//    // Use this for initialization
//    void Start ()
//    {
//        controller = new Controller();
//        if (controller != null) Debug.Log("Controller Ready!");
//        //if (controller.IsConnected)
//        //{
//            //controller is a Controller object
//            Debug.Log("Controller is connected!");
//            frame = controller.Frame(); //The latest frame
//            previous = controller.Frame(1); //The previous frame
//        //}
//    }
	
//	// Update is called once per frame
//	void Update () {
        
//        if (frame != null) Debug.Log("Frame Ready!");
//        if (frame.Hands != null) Debug.Log("Hands Ready!");
//        Debug.Log(frame.Hands.Count);
//        if (frame.Hands.Count > 0)
//        {
//            List<Hand> hands = frame.Hands;
//            Hand firstHand = hands[0];
//            Vector position = firstHand.PalmPosition;
//            Vector velocity = firstHand.PalmVelocity;
//            Vector direction = firstHand.Direction;
            
//            Debug.Log("pos: "+position);
//        }
//	}
//}
