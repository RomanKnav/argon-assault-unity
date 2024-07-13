using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{ 
    [SerializeField] float controlSpeed = 30;

    // these two values are supposed to be RELATIVE to the rig (5f)

    // maybe change this to be local to 230?
    [SerializeField] float xRange = 5f;

    // Update is called once per frame
    void Update()
    {

        // OLD SYSTEM:
        // these values have values between -1 and 1
        float xThrow = Input.GetAxis("Horizontal");    // throw as in pilot throws joystick from left/right
        float yThrow = Input.GetAxis("Vertical");    // throw as in pilot throws joystick from left/right

        // float xOffset = 0.001f;
        float xOffset = xThrow * controlSpeed * Time.deltaTime;        // how is it that Time.deltaTime makes it slow?

        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float rawXPosition = transform.localPosition.x + xOffset;
        float newYPosition = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPosition, -xRange, xRange);
        // float clampedYPos = Mathf.Clamp(newYPosition, -yRange, yRange);

        // transform.localPosition IS A FLOAT:
        transform.localPosition = new Vector3
        (
            clampedXPos,
            newYPosition,
            transform.localPosition.z
        );
    }
}
