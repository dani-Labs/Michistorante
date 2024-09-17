using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundLogic : MonoBehaviour
{
    public Slider slider;
    public float sliderVal;
    public GameObject imageMute;
    public GameObject imageFullScreen;

    // Start is called before the first frame update
    void Start()
    {
        //slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        imageMute.SetActive(false);
        imageFullScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = slider.value;
        CheckMute();
    }

    public void ChangeSlider(float valor)
    {
        sliderVal = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderVal);
        AudioListener.volume = slider.value;
        CheckMute();
    }

    public void CheckMute()
    {
        if (sliderVal ==  0)
        {
            imageMute.SetActive(true);
        }

        else
        {
            imageMute.SetActive(false);
        }
    }


    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        imageFullScreen.SetActive(true);
    }
    public void SalirDeAjustes()
    {
        SceneManager.LoadScene(0);
    }
}
