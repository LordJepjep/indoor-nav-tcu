using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PathLineVisualisation : MonoBehaviour {

    [SerializeField]
    private NavigationController navigationController;
    [SerializeField]
    private LineRenderer line;
    [SerializeField]
    private Slider navigationYOffset;

    private NavMeshPath path;
    private Vector3[] calculatedPathAndOffset;

    private void Update() {
        path = navigationController.CalculatedPath;
        AddOffsetToPath();
        AddLineOffset();
        SetLineRendererPositions();
    }

    private void AddOffsetToPath()
    {
        calculatedPathAndOffset = new Vector3[path.corners.Length];
        //Debug.Log("The path: ");
        for (int i = 0; i < path.corners.Length; i++)
        {
            // Preserve original Y value and add slider offset
            calculatedPathAndOffset[i] = new Vector3(
                path.corners[i].x,
                path.corners[i].y + navigationYOffset.value,  // Add offset to the original Y value
                path.corners[i].z
            );
            //Debug.Log($"{path.corners[i]}, ");
        }
    }

    private void AddLineOffset() {
        if (navigationYOffset.value != 0) {
            for (int i = 0; i < calculatedPathAndOffset.Length; i++) {
                calculatedPathAndOffset[i] += new Vector3(0, navigationYOffset.value, 0);
            }
        }
    }

    private void SetLineRendererPositions() {
        line.positionCount = calculatedPathAndOffset.Length;
        line.SetPositions(calculatedPathAndOffset);
    }
}
