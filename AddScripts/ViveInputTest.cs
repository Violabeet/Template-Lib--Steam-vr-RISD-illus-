using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class ViveInputTest : MonoBehaviour {



    



    public SteamVR_Action_Single squeezeAction;
    public SteamVR_Action_Vector2 touchPadAction;
    public SteamVR_Action_Pose myHandPose;
    public SteamVR_Action_Boolean PressGrip;
    public GameObject SwitchBetweenStats;
    public Transform rig;
    //rig is for the player collider follow along the camera

    public bool Gon;
    //gon is a varaiable turn on and off gravity for the virtual player collider

    void Start()
    {
       
        Gon = SwitchBetweenStats.GetComponent<Rigidbody>().useGravity;
    }
    void Update ()
    {

        float NaviSpeed = 5.0f;




        bool switchgravity = PressGrip.GetLastStateUp(SteamVR_Input_Sources.Any);
        if (switchgravity == true)
        {
            print("Gravity Stats changed");
            Gon = !Gon;
            SwitchBetweenStats.GetComponent<Rigidbody>().useGravity = Gon;
        }


        

        float triggerValue = squeezeAction.GetAxis(SteamVR_Input_Sources.Any);
        if (triggerValue > 0.0f && triggerValue != 1.0f) 
        {
            
            print(triggerValue);
        }
        if (triggerValue >= 1.0f)

        {
            print("hold trigger");
            NaviSpeed = 25.0f;
        }



        //---------------------------------------------------



        Vector2 touchPadValue = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);

        if (touchPadValue != Vector2.zero)
        {

            print("Touchpad Reading =");
            print(touchPadValue);


            if (rig != null)
            {
               
                Quaternion myHandPoseValue = myHandPose.GetLocalRotation(SteamVR_Input_Sources.Any);
                print("myHandPoseValue=");
                print(myHandPoseValue);
                rig.position += myHandPoseValue*(transform.right * touchPadValue.x * NaviSpeed + transform.forward * touchPadValue.y * NaviSpeed) * Time.deltaTime;
                // this says the rig's movement speed depends on how far the person touch the touchpad;
                // and "myHandPoseValue" defines the direction of movement by reading the controller's direction. 
                float y;
                if (rig.position.y < 0.64f)
                {
                    y = 0.64f;
                    //set the collider to where colliding still happens, prevent from accidental sinking below surface 
                }
                else
                {
                    y = rig.position.y;
                }
                rig.position = new Vector3(rig.position.x, y, rig.position.z);
            }


        }
	}
}
