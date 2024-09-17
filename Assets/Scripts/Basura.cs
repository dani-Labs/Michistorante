using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basura : MonoBehaviour, IInteractuable
{
    public GameObject Cocina;
    Cocina cocinaScript;
    public List<string> platosCocinadosAux = new List<string>();
    [SerializeField] GameObject UIConfirmar;


    void IInteractuable.Interaction()
    {
        UIConfirmar.SetActive(true);
        //cocinaScript = Cocina.GetComponent<Cocina>();
        //cocinaScript.platosCocinados.Clear();

        //for (int i = 0; i < cocinaScript.platosCocinadosgo.Count; i++)
        //{
        //    Debug.Log("destroy");
        //    Destroy(cocinaScript.platosCocinadosgo[i]);
        //    cocinaScript.posPlatos = cocinaScript.posPlatosInicial;
        //}
        //cocinaScript.numplatos = 0;
        //cocinaScript.platosCocinadosgo.Clear();
    
        
    }
    public void SI()
    {
        cocinaScript = Cocina.GetComponent<Cocina>();
        cocinaScript.platosCocinados.Clear();

        for (int i = 0; i < cocinaScript.platosCocinadosgo.Count; i++)
        {
            Debug.Log("destroy");
            Destroy(cocinaScript.platosCocinadosgo[i]);
            cocinaScript.posPlatos = cocinaScript.posPlatosInicial;
        }
        cocinaScript.numplatos = 0;
        cocinaScript.platosCocinadosgo.Clear();
        UIConfirmar.SetActive(false);
    }
    public void No()
    {
        UIConfirmar.SetActive(false);
    }
}
