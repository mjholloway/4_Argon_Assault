using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 25f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 18f;
    [SerializeField] float xClamp = 5.3f;
    [SerializeField] float yPosClamp = 2.5f;
    [SerializeField] float yNegClamp = -2.5f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -25f;

    [SerializeField] float positionYawFactor = 8f;
    [SerializeField] float controlRollFactor = -15f;

    float xThrow, yThrow;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newXPos = MoveHorizontally();
        float newYPos = MoveVertically();
        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);

        ProcessRotation();
    }

    private float MoveHorizontally()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClamp, xClamp);

        return clampedXPos;
    }

    private float MoveVertically()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, yNegClamp, yPosClamp);

        return clampedYPos;
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

}
