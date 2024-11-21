using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetDistanceText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = "Distance: " + CurrentDistance.distance + " to go";
    }
}
