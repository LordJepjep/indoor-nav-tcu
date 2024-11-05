using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

public class RotationIndicator : MonoBehaviour
{
    [SerializeField]
    private XROrigin XROrigin; 
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private TMP_Text textField;
    void Update()
    {
        string rotationText = XROrigin.transform.eulerAngles.y.ToString();
        string cameraText = cam.transform.eulerAngles.y.ToString();
        textField.text = $"XR ORigin Rotation: {rotationText} {Environment.NewLine} Camera Rotation: {cameraText}";
    }
}
