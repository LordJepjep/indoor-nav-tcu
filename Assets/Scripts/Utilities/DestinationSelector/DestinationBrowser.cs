using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelBrwoser : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject buttonParent;

    private void OnEnable()
    {
        foreach (Target target in GameManager.Instance.destinationCounts)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);
            string destinationString = target.Name; // name of the destination
            newButton.GetComponent<DestinationButton>().destinationText.text = destinationString; // button text
            newButton.GetComponent<Button>().onClick.AddListener(() => SelectDestination(destinationString));
        }
    }

    // opens navigation scene then sends destination name
    private void SelectDestination(string destination)
    {
        Debug.Log("Loaded destination: " + destination);
        CurrentDestination.selectedDestination = destination;
        SceneManager.LoadScene("NavigationScene");
    }
}
