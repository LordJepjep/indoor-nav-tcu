using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLayer : MonoBehaviour
{
    [SerializeField]
    public Camera mainCamera; // Reference to the main camera

    private int meshLayer; // Variable to store the "mesh" layer

    void Start()
    {
        // Get the layer index for the "mesh" layer
        meshLayer = LayerMask.NameToLayer("Mesh");
    }

    public void ToggleMeshLayer()
    {
        // Check if the layer is currently visible in the culling mask
        if ((mainCamera.cullingMask & (1 << meshLayer)) != 0)
        {
            // If visible, remove it from the culling mask
            mainCamera.cullingMask &= ~(1 << meshLayer);
        }
        else
        {
            // If not visible, add it to the culling mask
            mainCamera.cullingMask |= (1 << meshLayer);
        }
    }
}
