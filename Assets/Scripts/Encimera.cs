using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encimera : MonoBehaviour,IInteractuable
{
    GameManager scriptGameManager;
    GameObject gameManager;
    GameObject cocina;
    Cocina scriptCocina;

    public bool pedidoListo0 = false;
    public bool pedidoListo1 = false;
    public bool pedidoListo2 = false;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        scriptGameManager = gameManager.GetComponent<GameManager>();
        cocina = GameObject.FindGameObjectWithTag("Cocina");
        scriptCocina = cocina.GetComponent<Cocina>();
    }

   
    void IInteractuable.Interaction()
    {
        Debug.Log("soy encimera");
        if (scriptGameManager.indicePedidos[0] == true)
        {
            int aux = 0;
            for (int i = 0; i < scriptGameManager.pedidoActual0.Count; i++)
            {
                for (int j = 0; j < scriptCocina.platosCocinados.Count; j++)
                {
                    if (scriptGameManager.pedidoActual0[i] == scriptCocina.platosCocinados[j])
                    {
                        Debug.Log("HAY UN CHECK ACTIVADO");
                        aux++;
                    }

                }
                //Debug.Log("he entrado al for");
            }
            Debug.Log(aux);
            Debug.Log( scriptGameManager.pedidoActual0.Count);
            List<string> pedidoAux = new List<string>();
            int auxAyuda = 0;
            if (aux == scriptGameManager.pedidoActual0.Count)//PEDIDO 0
            {
                pedidoListo0 = true;
                for (int i = 0; i < scriptCocina.platosCocinadosgo.Count; i++)
                {
                   Plato auxPlato = scriptCocina.platosCocinadosgo[i].GetComponent<Plato>();
                    Debug.Log(auxPlato);
                    for (int a = 0; a < scriptGameManager.pedidoActual0.Count; a++)
                    {
                        pedidoAux.Add(scriptGameManager.pedidoActual0[a] + "(Clone)");
                        //scriptGameManager.pedidoActual0[a] += ("(Clone)");
                        Debug.Log(scriptGameManager.pedidoActual0[a] +" + "+ auxPlato.queSoy);
                        if (pedidoAux[a]==auxPlato.queSoy)//comparamos el nombre del obj del plato con el nombre de el pedido
                        {
                            Debug.Log("for");
                            Destroy(scriptCocina.platosCocinadosgo[i]);
                            //scriptGameManager.pedidoActual0.RemoveAt(0);
                            pedidoAux.RemoveAt(a);
                            StartCoroutine(scriptGameManager.EsperaComiendo(0));
                            auxAyuda = a;
                            //Destroy(scriptCocina.platoInstanciadoGO[0]);
                        }
                    }
                            scriptCocina.posPlatos.z = (scriptCocina.posPlatosInicial.z += auxAyuda*2);
                }

            }
        }

        if (scriptGameManager.indicePedidos[1] == true)
        {
            int aux = 0;
            for (int i = 0; i < scriptGameManager.pedidoActual1.Count; i++)
            {
                for (int j = 0; j < scriptCocina.platosCocinados.Count; j++)
                {
                    if (scriptGameManager.pedidoActual0[i] == scriptCocina.platosCocinados[j])
                    {
                        Debug.Log("HAY UN CHECK ACTIVADO");
                        aux++;
                    }

                }
                //Debug.Log("he entrado al for");
            }
            Debug.Log(aux);
            Debug.Log(scriptGameManager.pedidoActual1.Count);
            List<string> pedidoAux = new List<string>();
            int auxAyuda = 0;
            if (aux == scriptGameManager.pedidoActual1.Count)//PEDIDO 0
            {
                pedidoListo1 = true;
                for (int i = 0; i < scriptCocina.platosCocinadosgo.Count; i++)
                {
                    Plato auxPlato = scriptCocina.platosCocinadosgo[i].GetComponent<Plato>();
                    Debug.Log(auxPlato);
                    for (int a = 0; a < scriptGameManager.pedidoActual1.Count; a++)
                    {
                        pedidoAux.Add(scriptGameManager.pedidoActual1[a] + "(Clone)");
                        //scriptGameManager.pedidoActual0[a] += ("(Clone)");
                        Debug.Log(scriptGameManager.pedidoActual1[a] + " + " + auxPlato.queSoy);
                        if (pedidoAux[a] == auxPlato.queSoy)//comparamos el nombre del obj del plato con el nombre de el pedido
                        {
                            Debug.Log("for");
                            Destroy(scriptCocina.platosCocinadosgo[i]);
                            //scriptGameManager.pedidoActual0.RemoveAt(0);
                            pedidoAux.RemoveAt(a);
                            StartCoroutine(scriptGameManager.EsperaComiendo(1));
                            auxAyuda = a;
                            //Destroy(scriptCocina.platoInstanciadoGO[0]);
                        }
                    }
                    scriptCocina.posPlatos.z = (scriptCocina.posPlatosInicial.z += auxAyuda * 2);
                }

            }
        }

        if (scriptGameManager.indicePedidos[2] == true)
        {
            int aux = 0;
            for (int i = 0; i < scriptGameManager.pedidoActual2.Count; i++)
            {
                for (int j = 0; j < scriptCocina.platosCocinados.Count; j++)
                {
                    if (scriptGameManager.pedidoActual2[i] == scriptCocina.platosCocinados[j])
                    {
                        Debug.Log("HAY UN CHECK ACTIVADO");
                        aux++;
                    }

                }
                //Debug.Log("he entrado al for");
            }
            Debug.Log(aux);
            Debug.Log(scriptGameManager.pedidoActual2.Count);
            List<string> pedidoAux = new List<string>();
            int auxAyuda = 0;
            if (aux == scriptGameManager.pedidoActual2.Count)//PEDIDO 0
            {
                pedidoListo2 = true;
                for (int i = 0; i < scriptCocina.platosCocinadosgo.Count; i++)
                {
                    Plato auxPlato = scriptCocina.platosCocinadosgo[i].GetComponent<Plato>();
                    Debug.Log(auxPlato);
                    for (int a = 0; a < scriptGameManager.pedidoActual2.Count; a++)
                    {
                        pedidoAux.Add(scriptGameManager.pedidoActual2[a] + "(Clone)");
                        //scriptGameManager.pedidoActual0[a] += ("(Clone)");
                        Debug.Log(scriptGameManager.pedidoActual2[a] + " + " + auxPlato.queSoy);
                        if (pedidoAux[a] == auxPlato.queSoy)//comparamos el nombre del obj del plato con el nombre de el pedido
                        {
                            Debug.Log("for");
                            Destroy(scriptCocina.platosCocinadosgo[i]);
                            //scriptGameManager.pedidoActual0.RemoveAt(0);
                            pedidoAux.RemoveAt(a);
                            StartCoroutine(scriptGameManager.EsperaComiendo(2));
                            auxAyuda = a;
                            //Destroy(scriptCocina.platoInstanciadoGO[0]);
                        }
                    }
                    scriptCocina.posPlatos.z = (scriptCocina.posPlatosInicial.z += auxAyuda * 2);
                    scriptCocina.numplatos -= auxAyuda;
                }

            }
        }
    }

    public void EntregarPedidoCero()
    {
        int aux = 0;
        int auxPlatos = 0;
        Debug.Log(aux);
      float auxAyuda = 0;
        //Vector3 auxAyuda = new Vector3(0, 0, 0);
        Debug.Log(scriptGameManager.pedidoActual0.Count);
        List<string> pedidoAux = new List<string>();
        pedidoListo0 = true;
        for (int i = 0; i < scriptCocina.platosCocinadosgo.Count; i++)
        {
            Plato auxPlato = scriptCocina.platosCocinadosgo[i].GetComponent<Plato>();
            Debug.Log(auxPlato);
            for (int a = 0; a < scriptGameManager.pedidoActual0.Count; a++)
            {
                pedidoAux.Add(scriptGameManager.pedidoActual0[a] + "(Clone)");
                //scriptGameManager.pedidoActual0[a] += ("(Clone)");
                Debug.Log(scriptGameManager.pedidoActual0[a] + " + " + auxPlato.queSoy);
                if (pedidoAux[a] == auxPlato.queSoy)//comparamos el nombre del obj del plato con el nombre de el pedido
                {
                    Debug.Log("for");
                    auxAyuda++;
                    auxPlatos++;
                    //auxAyuda = scriptCocina.platosCocinadosgo[i].transform.position;
                    Destroy(scriptCocina.platosCocinadosgo[i]);
                  //  pedidoAux.RemoveAt(a);
                    //scriptGameManager.pedidoActual0.RemoveAt(0);
                    StartCoroutine(scriptGameManager.EsperaComiendo(0));
                   // auxAyuda = a;
                    //Destroy(scriptCocina.platoInstanciadoGO[0]);
                }
            }
            scriptCocina.posPlatos.z -= (auxAyuda+1);
            scriptCocina.numplatos -= auxPlatos;
            Debug.Log(scriptCocina.posPlatos);
           // scriptCocina.posPlatos.z = (scriptCocina.posPlatosInicial.z += auxAyuda * 2);
        }
    }

    public void EntregarPedidoUno()
    {
        int aux = 0;
        int auxPlatos = 0;
        //Vector3 auxAyuda = new Vector3(0, 0, 0);
        Debug.Log(aux);
        float auxAyuda = 0;
        Debug.Log(scriptGameManager.pedidoActual1.Count);
        List<string> pedidoAux = new List<string>();
        pedidoListo1 = true;
        for (int i = 0; i < scriptCocina.platosCocinadosgo.Count; i++)
        {
            Plato auxPlato = scriptCocina.platosCocinadosgo[i].GetComponent<Plato>();
            Debug.Log(auxPlato);
            for (int a = 0; a < scriptGameManager.pedidoActual1.Count; a++)
            {
                pedidoAux.Add(scriptGameManager.pedidoActual1[a] + "(Clone)");
                //scriptGameManager.pedidoActual0[a] += ("(Clone)");
                Debug.Log(scriptGameManager.pedidoActual1[a] + " + " + auxPlato.queSoy);
                if (pedidoAux[a] == auxPlato.queSoy)//comparamos el nombre del obj del plato con el nombre de el pedido
                {
                    Debug.Log("for");
                    auxAyuda++;
                    auxPlatos++;
                    //auxAyuda = scriptCocina.platosCocinadosgo[i].transform.position;
                    Destroy(scriptCocina.platosCocinadosgo[i]);
                    //scriptGameManager.pedidoActual0.RemoveAt(0);
                    //pedidoAux.RemoveAt(a);
                    StartCoroutine(scriptGameManager.EsperaComiendo(1));
                  //  auxAyuda = a;
                    //Destroy(scriptCocina.platoInstanciadoGO[0]);
                }
            }
            scriptCocina.posPlatos.z -= (auxAyuda +1);
            scriptCocina.numplatos -= auxPlatos;
            Debug.Log(scriptCocina.posPlatos);
           // scriptCocina.posPlatos.z = (scriptCocina.posPlatosInicial.z += auxAyuda * 2);
        }
    }

    public void EntregarPedidoDos()
    {
        int aux = 0;
        int auxPlatos = 0;
        //Debug.Log(aux);
        float auxAyuda = 0;
        //Vector3 auxAyuda = new Vector3(0,0,0);
        //Debug.Log(scriptGameManager.pedidoActual2.Count);
        List<string> pedidoAux = new List<string>();
        pedidoListo2 = true;
        for (int i = 0; i < scriptCocina.platosCocinadosgo.Count; i++)
        {
            Plato auxPlato = scriptCocina.platosCocinadosgo[i].GetComponent<Plato>();
            //Debug.Log(auxPlato);
            for (int a = 0; a < scriptGameManager.pedidoActual2.Count; a++)
            {
                pedidoAux.Add(scriptGameManager.pedidoActual2[a] + "(Clone)");
                //scriptGameManager.pedidoActual0[a] += ("(Clone)");
                Debug.Log(scriptGameManager.pedidoActual2[a] + " + " + auxPlato.queSoy);
                if (pedidoAux[a] == auxPlato.queSoy)//comparamos el nombre del obj del plato con el nombre de el pedido
                {
                    //Debug.Log("for");
                    //  auxAyuda = scriptCocina.platosCocinadosgo[i].transform.position;
                    auxAyuda++;
                    auxPlatos++;
                    Destroy(scriptCocina.platosCocinadosgo[i]);
                    //scriptGameManager.pedidoActual0.RemoveAt(0);
                   // pedidoAux.RemoveAt(a);
                    StartCoroutine(scriptGameManager.EsperaComiendo(2));
                    //Destroy(scriptCocina.platoInstanciadoGO[0]);
                   // auxAyuda = a;
                }
            }
            scriptCocina.posPlatos.z -= (auxAyuda +1);
            scriptCocina.numplatos -= auxPlatos;
            //  scriptCocina.posPlatos = auxAyuda;
        }
    }
}
