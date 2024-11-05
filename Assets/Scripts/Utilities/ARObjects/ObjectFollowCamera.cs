using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectFollowCamera : MonoBehaviour
{
    private Camera arCam;
    private void Start()
    {
        arCam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(arCam.transform.position, this.transform.position);
        if(distance <= 100)
        {
            
            this.transform.LookAt(arCam.transform);
            this.transform.Rotate(180, 0, 0);

        }
    }
}
