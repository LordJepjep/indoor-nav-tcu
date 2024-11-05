using TMPro;
using UnityEngine;

public class SetUiText : MonoBehaviour {

    [SerializeField]
    private TMP_Text textField;
    [SerializeField]
    private string fixedText;

    public void OnSliderValueChanged(float numericValue) {
        // Remap numericValue from [-1, 1] to [100, 0]
        float clampedValue = Mathf.Lerp(100f, 0f, Mathf.InverseLerp(1f, -1f, numericValue));

        // Update the text field
        textField.text = $"{fixedText}: {clampedValue}%";
    }
}
