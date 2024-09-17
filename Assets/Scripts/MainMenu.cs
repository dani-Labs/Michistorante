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
    //    SceneManager.LoadScene(nº escena);
    //    Por si no te acuerdas hay que hacer file - Build settings y arrastra la nueva escena con las demás
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
