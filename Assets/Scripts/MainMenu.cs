using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    
     public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
     public void OpenSettings()
    {
        SceneManager.LoadScene(2);
    } 
    //public void OpenTutorial() Para cuando tengas el tuto
    //{
    //    SceneManager.LoadScene(n� escena);
    //    Por si no te acuerdas hay que hacer file - Build settings y arrastra la nueva escena con las dem�s
    //}
     public void ExitGame()
    {
        Application.Quit();
    }
    public void Turorial()
    {
        SceneManager.LoadScene(3);
    }

}
