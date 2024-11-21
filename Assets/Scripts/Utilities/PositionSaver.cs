using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


[ExecuteInEditMode]
public class PositionSaver : MonoBehaviour
{
    public string filePath = "Assets/Resources/TargetData.json";

    private void OnValidate()
    {
        UpdateTargetPosition();
        Debug.Log("Validating...");
    }

    private void UpdateTargetPosition()
    {
        TargetWrapper targetWrapper;

        // Load existing JSON data
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            targetWrapper = JsonUtility.FromJson<TargetWrapper>(json);
        }
        else
        {
            targetWrapper = new TargetWrapper { TargetList = new Target[0] };
        }

        // Convert the array to a list for easy manipulation
        List<Target> targetList = new List<Target>(targetWrapper.TargetList);

        // Find the target with the matching GameObject name or create a new one
        Target target = targetList.Find(t => t.Name == gameObject.name);
        if (target == null)
        {
            target = new Target
            {
                Name = gameObject.name,
                TargetType = TargetTypeChecker(gameObject.name),
                Position = Vector3.zero,
                Rotation = Vector3.zero
            };
            targetList.Add(target);
        } else
        {
            Debug.Log(gameObject.name + " is in the target list");
        }

        // Update position and rotation
        target.Position.x = transform.position.x;
        target.Position.y = transform.position.y;
        target.Position.z = transform.position.z;

        target.Rotation.x = transform.rotation.eulerAngles.x;
        target.Rotation.y = transform.rotation.eulerAngles.y;
        target.Rotation.z = transform.rotation.eulerAngles.z;

        Debug.Log("Target Name: " + target.Name);
        Debug.Log("Target Floor: " + target.TargetType);
        Debug.Log("Target Position: " + target.Position);
        Debug.Log("Target Rotation: " + target.Rotation);
        // Save updated JSON data
        string updatedJson = JsonUtility.ToJson(targetWrapper, true);
        File.WriteAllText(filePath, updatedJson);
        Debug.Log("Position and rotation saved to JSON: " + updatedJson);
    }

    private int TargetTypeChecker(string name)
    {
        if (name.Contains("Qr"))
        {
            return 1;
        }

        return 0;
    }
}