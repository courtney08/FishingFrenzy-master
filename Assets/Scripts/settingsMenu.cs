
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingsMenu : MonoBehaviour
{
    public GameObject HelpPanel;

    public void OnPlayButton(){
        SceneManager.LoadScene("Scene1");
    }

    public void OnHomeButton(){
        SceneManager.LoadScene("MainMenu");
    }

    public void OnHelpButton(){
        HelpPanel.SetActive(true);
    }

    public void OnHelpBackButton(){
        HelpPanel.SetActive(false);
    }
    public void OnSettingsButton(){
        SceneManager.LoadScene("Settings");
    }
}

