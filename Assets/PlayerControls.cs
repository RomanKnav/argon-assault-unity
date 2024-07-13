using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{ 

    // Update is called once per frame
    void Update()
    {

        // OLD SYSTEM:
        // these values have values between -1 and 1
        float horizontalThrow = Input.GetAxis("Horizontal");    // throw as in pilot throws joystick from left/right
        float verticalThrow = Input.GetAxis("Vertical");    // throw as in pilot throws joystick from left/right
        
        Debug.Log(horizontalThrow);
        Debug.Log(verticalThrow);
    }
}
