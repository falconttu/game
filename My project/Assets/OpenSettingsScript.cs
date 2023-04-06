using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingsScript : MonoBehaviour
{
    // Initialising Public GameObject
    public GameObject SettingsPanel;

    // Creating Function for Opening/Closing Panel
    public void OpenSettingsPanel()
    {
        if (SettingsPanel != null)
        {
            SettingsPanel.SetActive(true);
        }
    }
}
