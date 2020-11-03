using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Controller : MonoBehaviour
{
    [Header("General")]
    [Tooltip("in ms^-1")] [SerializeField] float Speed = 20f;
    [Tooltip("in m")] [SerializeField] float xRange = 35f;
    [Tooltip("in m")] [SerializeField] float yRange = 35f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -19/7f;
    [SerializeField] float positionYawFactor = 5/3f;
    [Header("Control-throw Based")]
    [SerializeField] float controlPitchThrow = -15f;
    [SerializeField] float controlRollThrow = -15f;
    bool dying = false;
    // Start is called before the first frame update
    float xThrow, yThrow;

    // Update is called once per frame
    void Update()
    {
        if (!dying) {
            ProcessTranslation();
            ProcessRotation();
        }
    }
    private void flagDying()
    {
        dying = true;
    }
    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffset = yThrow * Speed * Time.deltaTime;
        float xPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);
        float yPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);
        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }
}
