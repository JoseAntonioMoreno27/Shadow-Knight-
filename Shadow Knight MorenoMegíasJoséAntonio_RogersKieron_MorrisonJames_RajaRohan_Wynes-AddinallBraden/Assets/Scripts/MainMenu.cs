using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Allows for different scenes (levels) to be loaded from the script
using System.Threading;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Shadow Knight"); // Loads the scene that is in quotes
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!"); // Unity can close the program itself, we want to know that the button is working as it should. This debug will tell us if it is or is not
        Application.Quit(); // Closes the program when prompted. It works only when it has been built, not in the editor. Don't worry, nothing is wrong
    }
}
