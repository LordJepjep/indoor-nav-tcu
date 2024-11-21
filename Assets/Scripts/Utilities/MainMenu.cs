using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        // Loads the next scene (game scene)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Explore()
    {
        // Loads the explore scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
