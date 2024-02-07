using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Starts The Game
        SceneManager.LoadScene("LoadingScreen");        
    }

    public void Options()
    {
        //Goes To Credits Screen
        SceneManager.LoadScene("Options");
    }

    public void ExitGame()
    {
        // Exits The Game
        Application.Quit();
    }

    // Mutes Music If Box Ticked
    /*public void MuteToggle(bool muted)
    {
        if (muted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }*/
}
