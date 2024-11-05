using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorRotate : MonoBehaviour
{
    [SerializeField]
    private Camera arCam;
    [SerializeField]
    private GameObject indicator;

    // Update is called once per frame
    void Update()
    {
        Vector3 camRotation = transform.eulerAngles;
        camRotation.y = arCam.transform.eulerAngles.y + 180;
        indicator.transform.eulerAngles = camRotation;
    }
}
