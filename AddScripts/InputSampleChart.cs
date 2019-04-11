using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class InputSampleChart : MonoBehaviour
{


    //Sample for Single : inAction.Squeeze
    public SteamVR_Action_Single squeeze;
    //Sample for bool: inAction.InteractUI
    public SteamVR_Action_Boolean interactUI;
    //Sample for bool : inAction.Teleport
    public SteamVR_Action_Boolean teleport;
    //sample for bool : inAction.GrabPinch
    public SteamVR_Action_Boolean grabPinch;
    //sample for bool : inAction.GrabGrip
    public SteamVR_Action_Boolean grabGrip;
    //sample for vector2 : inAction.TouchpadTouch (in sample proejct)
    public SteamVR_Action_Vector2 touchpadTouch;
    //sample for bool : inAction.Pose
    public SteamVR_Action_Pose pose;

    //item to activeTHIS, usually can be use to start a action script binded on another object.
    public GameObject startScript;
    //item refer to rig
    private GameObject cameraRig;

    void Start()
    {
        //Activate Component
        startScript.SetActive(true);

        cameraRig = GameObject.Find("Camera Control(sample)");
        if (cameraRig != null)
        {
            print("Find CameraRig placeholder");
        }

    }

    void Update()
    {
        //check if interactUI, same with other bools 
        if (interactUI != null)
        {
            //do something
            print("interactUI");
        }


        //check if squeeze, same with other singles
        if (squeeze != null)
        {
            //do something
            float squeezeValue = squeeze.GetAxis(SteamVR_Input_Sources.Any);
            print("SqueezeValue="+squeezeValue);
        }

 
        // check if touchpad touched, same with other vector2
        if (touchpadTouch != null)
        {
            //do something
            Vector2 touchpadValue = touchpadTouch.GetAxis(SteamVR_Input_Sources.Any);
            print("TouchpadValue=" + touchpadValue);
        }

        // check if have pose (for all inputs)

        if (pose != null)
        {
            //display position and rotation of left controller
            Vector3 leftposePos = pose.GetLocalPosition(SteamVR_Input_Sources.LeftHand);
            Quaternion leftposeRot = pose.GetLocalRotation(SteamVR_Input_Sources.LeftHand);
            //display position and rotation of right controller
            Vector3 rightposePos = pose.GetLocalPosition(SteamVR_Input_Sources.RightHand);
            Quaternion rightposeRot = pose.GetLocalRotation(SteamVR_Input_Sources.RightHand);
            //display position and rotation of headset (had not test yet)
            Vector3 posePos = pose.GetLocalPosition(SteamVR_Input_Sources.Head);
            Quaternion poseRot = pose.GetLocalRotation(SteamVR_Input_Sources.Head);

            print("LeftPose=" + leftposePos + leftposeRot);
            print("RightPose=" + rightposePos + rightposeRot);
            print("HeadPose=" + posePos + poseRot);

            if (cameraRig != null)

            {
                //do something to the cameraRig

            }

        }

        

    }




}