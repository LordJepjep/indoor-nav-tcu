using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    void Update()
    {
        // Handles Android physical back button
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
            Back();
    }
    public void Back()
    {
        // Loads the main menu scene
        SceneManager.LoadScene("MainMenuScene");
    }
}
