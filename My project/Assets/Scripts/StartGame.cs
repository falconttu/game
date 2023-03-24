using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
   public void StartingGame()
    {
        // Loads the next scene one the button is clicked
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
