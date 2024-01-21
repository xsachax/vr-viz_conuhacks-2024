using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateRay : MonoBehaviour
{
    public GameObject leftRay;
    public GameObject rightRay;

    public InputActionProperty leftRayActivate;
    public InputActionProperty rightRayActivate;
    void Update()
    {
        leftRay.SetActive(leftRayActivate.action.ReadValue<float>() > 0.1f);
        rightRay.SetActive(rightRayActivate.action.ReadValue<float>() > 0.1f);
        
    }
}
