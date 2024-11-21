using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class NavigationController : MonoBehaviour {

    public Vector3 TargetPosition { get; set; } = Vector3.zero;

    public NavMeshPath CalculatedPath { get; private set; }

    public float navigationDistance;

    private void Start() {
        CalculatedPath = new NavMeshPath();
        NavMeshHit hit;
        float maxDistance = 1.0f;

        // Check if source position is on the NavMesh
        if (NavMesh.SamplePosition(transform.position, out hit, maxDistance, NavMesh.AllAreas))
        {
            Debug.Log("Source is on the NavMesh at: " + hit.position);
        }
        else
        {
            Debug.Log("Source is NOT on the NavMesh. Nearest point: " + hit.position);
        }

        // Optionally set the source to the nearest valid point on the NavMesh
        transform.position = hit.position;
        CalculateNavDistance();
    }


    private void Update() {
        if (TargetPosition != Vector3.zero) {
            NavMesh.CalculatePath(transform.position, TargetPosition, NavMesh.AllAreas, CalculatedPath);
            NavMeshHit hit;
            if (NavMesh.SamplePosition(TargetPosition, out hit, 1.0f, NavMesh.AllAreas))
            {
                Debug.Log("Target is on the NavMesh.");
            }
            else
            {
                Debug.Log("Target is not on the NavMesh.");
            }
            
        }
        CalculateNavDistance();
    }

    private void CalculateNavDistance()
    {
        navigationDistance = Vector3.Distance(transform.position, CalculatedPath.corners[0]);
        for (int i = 1; i < CalculatedPath.corners.Length; i++)
        {
            navigationDistance += Vector3.Distance(CalculatedPath.corners[i - 1], CalculatedPath.corners[i]);
        }
        CurrentDistance.distance = (navigationDistance - 1.2).ToString("0.00") + "m";
        Debug.Log(CurrentDistance.distance);
    }
}
