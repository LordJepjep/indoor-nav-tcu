using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateApplicationCanvas : MonoBehaviour
{
    public GameObject localCanvas;
    public GameObject appCanvas;

    public void ActivateAppCanvas()
    {
        appCanvas.SetActive(true);
        localCanvas.SetActive(false);
    }

}
