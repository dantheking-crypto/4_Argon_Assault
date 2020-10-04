using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Controller : MonoBehaviour
{
    [Tooltip("in ms^-1")] [SerializeField] float Speed = 20f;
    [Tooltip("in m")] [SerializeField] float xRange = 35f;
    [Tooltip("in m")] [SerializeField] float yRange = 35f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffset = yThrow * Speed * Time.deltaTime;
        float xPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);
        float yPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);
        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }
}
