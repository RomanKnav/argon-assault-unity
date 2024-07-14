using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{ 
    [SerializeField] float controlSpeed = 30;

    // these two values are supposed to be RELATIVE to the rig (5f)

    // maybe change this to be local to 230?
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 5f;     // player should be moved RELATIVE to camera, not other way around.

    [SerializeField] float positionPitchFactor = 3.5f;
    [SerializeField] float controlPitchFactor = 10f;

    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlYawFactor = 12f;

    // NEED TO MAKE NEW CRAP FOR ROLL (Z)
    [SerializeField] float positionRollFactor = 2f;
    [SerializeField] float controlRollFactor = 13f;


    float xThrow, yThrow;   // values between -1 and 1, depending for how long player holds the directional buttons

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    // NEED TO CHANGE ROLL ON CONTROL THROW

    void ProcessRotation() {
        // the pitch (rock back and forth) caused by position:
        float pitchFromPosition = transform.localPosition.y * positionPitchFactor;
        float pitchFromControlThrow = yThrow * controlPitchFactor;

        float yawFromPosition = transform.localPosition.x * positionYawFactor;
        float yawFromControlThrow = xThrow * controlYawFactor;

        // float rollFromPosition = transform.localPosition.z * positionRollFactor;
        float rollFromControlThrow = transform.localRotation.z * controlRollFactor;

        // the extra yThrow * controlPitchFactor makes the plane nose move up and down more: 
        float pitch = pitchFromPosition + pitchFromControlThrow;
        // float yaw = transform.localPosition.x * positionYawFactor;
        float yaw = yawFromPosition + yawFromControlThrow;
        float roll = xThrow * controlRollFactor;

        // transform.localRotation.x wouldn't work. Order in which we change the axes matters.
        // why do we use Quaternion.Euler(-30, 30, 0)? idk, but it rotates our obj.
        // pitch, yaw, and roll:
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    // translation on the horizontal/vertical axes
    void ProcessTranslation()
    {
        // these values have values between -1 and 1
        xThrow = Input.GetAxis("Horizontal");    // throw as in pilot throws joystick from left/right
        yThrow = Input.GetAxis("Vertical");    // throw as in pilot throws joystick from up/down

        // float xOffset = 0.001f;
        float xOffset = xThrow * controlSpeed * Time.deltaTime;        // how is it that Time.deltaTime makes it slow?

        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float rawXPosition = transform.localPosition.x + xOffset;
        float newYPosition = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPosition, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(newYPosition, -yRange, yRange);

        // transform.localPosition IS A FLOAT:
        transform.localPosition = new Vector3
        (
            clampedXPos,
            clampedYPos,
            transform.localPosition.z
        );
    }
}
