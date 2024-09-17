using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject[] paginas = new GameObject[8];
    int aux = 0;
    [SerializeField] GameObject botonSiguiente;
    [SerializeField] GameObject botonAnterior;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SiguientePagina()
    {
        paginas[aux].SetActive(false);
        paginas[aux+1].SetActive(true);
        aux++;
        if (aux>0&&aux<8)
        {
            botonSiguiente.SetActive(true);
            botonAnterior.SetActive(true);
        }
        else
        {
            botonSiguiente.SetActive(false);

        }
    }
    public void AnteriorPagina()
    {
        paginas[aux].SetActive(false);
        paginas[aux - 1].SetActive(true);
        aux--;
        if (aux > 1 && aux <= 8)
        {
            botonAnterior.SetActive(true);
            botonSiguiente.SetActive(true);
        }
        else if (aux ==0)
        {
            botonAnterior.SetActive(false);

        }
      
    }
    public void SalirDelTutorial()
    {
        SceneManager.LoadScene(0);
    }
}
