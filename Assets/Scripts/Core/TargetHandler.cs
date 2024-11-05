using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TargetHandler : MonoBehaviour {

    [SerializeField]
    private NavigationController navigationController;
    [SerializeField]
    private TextAsset targetModelData;
    [SerializeField]
    private TMP_Dropdown targetDataDropdown;

    [SerializeField]
    private GameObject targetObjectPrefab;
    [SerializeField]
    private Transform[] targetObjectsParentTransforms;

    private List<TargetFacade> currentTargetItems = new List<TargetFacade>();

    private void Start() {
        GenerateTargetItems();
        FillDropdownWithTargetItems();
    }

    // Lists all Targets from the Target List JSON FIle
    private void GenerateTargetItems() {
        IEnumerable<Target> targets = GenerateTargetDataFromSource();
        Debug.Log("Number of targets: " + targets.Count());

        foreach (Target target in targets)
        {
            Debug.Log("Target Detected: " + target.Name);
            currentTargetItems.Add(CreateTargetFacade(target));
            Debug.Log("Curr Target Items: " + currentTargetItems.Count());
        }
    }

    private IEnumerable<Target> GenerateTargetDataFromSource() {
        return JsonUtility.FromJson<TargetWrapper>(targetModelData.text).TargetList;
    }

    private TargetFacade CreateTargetFacade(Target target)
    {
        Debug.Log("Target Name: " + target.Name + " Target Parent: " + targetObjectsParentTransforms[target.FloorNumber]);
        GameObject targetObject = Instantiate(targetObjectPrefab, targetObjectsParentTransforms[target.FloorNumber], false);

        int qrLayer = LayerMask.NameToLayer("QR");

        if (target.FloorNumber == 1)
        {
            // Set the layer of the parent object
            targetObject.layer = qrLayer;

            // Set the layer of all children recursively
            SetLayerRecursively(targetObject, qrLayer);
        }

        targetObject.SetActive(true);
        targetObject.name = target.Name;

        targetObject.transform.localPosition = target.Position;
        targetObject.transform.localRotation = Quaternion.Euler(target.Rotation);

        TargetFacade targetData = targetObject.GetComponent<TargetFacade>();
        targetData.Name = target.Name;
        targetData.FloorNumber = target.FloorNumber;

        return targetData;
    }

    // Helper function to set the layer of an object and its children recursively
    private void SetLayerRecursively(GameObject obj, int layer)
    {
        obj.layer = layer;

        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, layer);  // Recursively set the layer for each child
        }
    }

    private void FillDropdownWithTargetItems()
    {
        List<TMP_Dropdown.OptionData> targetFacadeOptionData =
            currentTargetItems
            .Where(x => x.FloorNumber != 1)  // Filter out items with FloorNumber 1
            .Select(x => new TMP_Dropdown.OptionData
            {
                text = x.Name
            }).ToList();

        targetDataDropdown.ClearOptions();
        targetDataDropdown.AddOptions(targetFacadeOptionData);
    }

    public void SetSelectedTargetPositionWithDropdown(int selectedValue) {
        navigationController.TargetPosition = GetCurrentlySelectedTarget(selectedValue);
    }

    private Vector3 GetCurrentlySelectedTarget(int selectedValue) {
        if (selectedValue >= currentTargetItems.Count) {
            return Vector3.zero;
        }

        return currentTargetItems[selectedValue].transform.position;
    }

    public TargetFacade GetCurrentTargetByTargetText(string targetText) {
        return currentTargetItems.Find(x =>
            x.Name.ToLower().Equals(targetText.ToLower()));
    }
}
