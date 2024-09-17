using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atril : MonoBehaviour, IInteractuable
{
    GameManager scriptGM;
    Mesa[] scriptMesas;
    public GameObject[] mesas;

    // Start is called before the first frame update
    void Start()
    {

        scriptGM = GameObject.Find("GameManager").GetComponent<GameManager>();
        mesas = GameObject.FindGameObjectsWithTag("Mesa");
        scriptMesas = new Mesa[mesas.Length];
        for (int i = 0; i < mesas.Length; i++)
        {
            scriptMesas[i] = mesas[i].GetComponent<Mesa>();
        }
        
    }

    void IInteractuable.Interaction()
    {
        Debug.Log("soy atril");

        int nmesas = 0;
        int num = 0;
        for (num = 0; num < mesas.Length; num++)
        {
            if (scriptMesas[num].numeroSillas == scriptGM.genteEsperando[0] && scriptMesas[num].mesaLibre == true)
            {
                nmesas++;

                //scriptMesas[num].OutlineMesa();
                scriptMesas[num].mesaEncontrada = true;
            Debug.Log(scriptMesas);
                scriptMesas[num].outline.enabled = true;
            }
        }
        if (nmesas > 0)
        {
            scriptGM.mesasLibres.Remove(scriptGM.genteEsperando[0]);
            scriptGM.genteEsperando.RemoveAt(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < mesas.Length; i++)
        {
            if (scriptMesas[i].auxSentados == true)
            {
                for (int j = 0; j < mesas.Length; j++)
                {
                    if (scriptMesas[i].numeroSillas == scriptMesas[j].numeroSillas)
                    {
                        scriptMesas[i].mesaEncontrada = false;
                        scriptMesas[j].mesaEncontrada = false;
                        scriptMesas[i].auxSentados = false;
                        scriptMesas[i].outline.enabled = false;
                        scriptMesas[j].outline.enabled = false;
                    }
                }
            }
        }
    }
}
