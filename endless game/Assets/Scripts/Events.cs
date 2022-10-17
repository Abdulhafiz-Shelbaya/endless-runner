using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // needed to manage scenes in the code

public class Events : MonoBehaviour
{
   public void ReplayGame()
    {
        SceneManager.LoadScene("MainScene");//reloads the scene after we click the replay button it was assigned to
    }
    

    public void QuitGame()
    {
        Application.Quit();//quits the game after we click the quit button it was assigned to
    }
}
