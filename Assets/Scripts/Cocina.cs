using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocina : MonoBehaviour, IInteractuable
{
    [SerializeField] Mesa mesa;
    [SerializeField] Camera camara;
    [SerializeField] GameObject canvasLibroRecetas;
    [SerializeField] GameObject canvasPedidos;
    Canvas canvasScript;
    [SerializeField] GameObject canvasGO;
    [SerializeField] GameObject GMObject;

    [SerializeField] AudioSource olla;
    [SerializeField] AudioSource cronoHorno;
    [SerializeField] AudioSource finCoccion;

    [SerializeField] GameObject PantallaJuegoUI;

    Recetas rec;
    GameManager gm;
    Vector3 v;
    public GameObject ollaObject;
    public GameObject spawnerPlatos;
    public Vector3 posPlatos;
    public Vector3 posPlatosInicial;

    int precioAux;

    public int numplatos = 0;
    public List<string> platosCocinados=new List<string>();
    public List<Recetas.Receta> platosCocinadosObj =new List<Recetas.Receta>();
    public List<GameObject> platosCocinadosgo =new List<GameObject>();
    public GameObject platoInstanciadoGOpedido0;
   // public List<GameObject> platoInstanciadoGOpedido1;
    //public List<GameObject> platoInstanciadoGOpedido2;

    //Despensa 
    public int numHuevo = 5;//HAY Q CAMBIARLO

    public int numGuanciale = 5;
    public int numQueso = 5;
    public int numEspaguetis = 5;
    public int numHarina = 0;
    public int numBerenjena = 0;
    public int numPimientos = 0;
    public int numTomate = 0;
    public int numCalabaza = 0;
    public int numGarbanzos = 0;
    public int numAnchoas = 0;
    public int numChampiñones = 0;
    public int numHierbas = 0;
    public int numQuesoCrema = 0;
    public int numCarnePicada = 0;
    public int numAceiteDeOliva = 0;
    public int numJamon = 0;
    public int numPatata = 0;
    public int numMostaza = 0;
    public int numCebolla = 0;
    public int numLeche = 0;
    public int numVainilla = 0;
    public int numAzucar = 0;
    public int numChocolate = 0;
    public int numPastaCorta = 0;
    public int numArroz = 0;
    public int numPanRallado = 0;
    public int numMozzarella = 0;
    public int numAlbahaca = 0;
    public int numBizcochoSoletilla = 0;
    public int numAceitunas = 0;

    [SerializeField] GameObject noTienesIngredientes;

    void Start()
    {
        canvasScript = canvasGO.GetComponent<Canvas>();
        rec = GMObject.GetComponent<Recetas>();
        Debug.Log(rec.libroRecetas[2]);
        gm = GMObject.GetComponent<GameManager>();
        v = new Vector3(0, 2, 0);
        posPlatos = spawnerPlatos.transform.position;
        posPlatosInicial = spawnerPlatos.transform.position;
        //posPlatos.z -= 2; 
    }

    public void BorrarChecks()
    {
        for (int k = 0; k < gm.checksPedido0.Count; k++)
        {
                  gm.checksPedido2[k].SetActive(false);
                  gm.checksPedido1[k].SetActive(false);
                  gm.checksPedido0[k].SetActive(false);
        }
    }
    public void ComprobarCero()
    {
        for (int i = 0; i < gm.pedidoActual0.Count; i++)
        {
            Debug.Log("ayuda");
            Debug.Log(platosCocinados);
            for (int j = 0; j < platosCocinados.Count; j++)
            {
                if (platosCocinadosgo[j] != null)
                {
                Plato aux = platosCocinadosgo[j].GetComponent<Plato>();
                Debug.Log(i + "+" + j);
                if (platosCocinados[j] == gm.pedidoActual0[i])
                {
                        gm.checksPedido0[i].SetActive(true);

                   //gm.checks[i].SetActive(true);
                }

                }
                
            }
        }
    }
    public void ComprobarUno()
    {
        for (int i = 0; i < gm.pedidoActual1.Count; i++)
        {
            Debug.Log("ayuda");
            Debug.Log(platosCocinados);
            for (int j = 0; j < platosCocinados.Count; j++)
            {
                if (platosCocinadosgo[j] != null)
                {
                        Plato aux = platosCocinadosgo[j].GetComponent<Plato>();
                        Debug.Log(i + "+" + j);
                        if (platosCocinados[j] == gm.pedidoActual1[i])
                              {
                                gm.checksPedido1[i].SetActive(true);

                                 //gm.checks[i].SetActive(true);
                              }
                }
                

            }
        }
    }
    public void ComprobarDos()
    {
        for (int i = 0; i < gm.pedidoActual2.Count; i++)
        {
            Debug.Log("ayuda");
            Debug.Log(platosCocinados);
            for (int j = 0; j < platosCocinados.Count; j++)
            {
                if (platosCocinadosgo[j] != null)
                {
                    Plato aux = platosCocinadosgo[j].GetComponent<Plato>();
                    Debug.Log(i + "+" + j);
                    if (platosCocinados[j] == gm.pedidoActual2[i])
                    {
                        gm.checksPedido2[i].SetActive(true);

                        //gm.checks[i].SetActive(true);
                    }

                }

            }
        }
    }
    void Update()
    {
      
        //for (int i = 0; i < gm.pedidoActual1.Count; i++)
        //{
        //    for (int j = 0; j < platosCocinados.Count; j++)
        //    {
        //        if (platosCocinados[j] == gm.pedidoActual1[i])
        //        {
        //            gm.checks[i].SetActive(true);
        //        }
        //    }
        //}
        //for (int i = 0; i < gm.pedidoActual2.Count; i++)
        //{
        //    for (int j = 0; j < platosCocinados.Count; j++)
        //    {
        //        if (platosCocinados[j] == gm.pedidoActual2[i])
        //        {
        //            gm.checks[i].SetActive(true);
        //        }
        //    }
        //}
    }
    void IInteractuable.Interaction()
    {
        PantallaJuegoUI.SetActive(false);
        canvasLibroRecetas.SetActive(true);
        
        canvasPedidos.SetActive(false);
    }

    
    public IEnumerator Cocinando(Recetas.Receta recetaACocinar)
    {
        if (  ollaObject.activeSelf==false && numplatos < 8)
        {
            canvasScript.ActualizarTextosIngredientes();
            olla.Play();//---------------------------------------------------SONIDO
            cronoHorno.Play();//---------------------------------------------SONIDO
          ollaObject.SetActive(true);
          Debug.Log("Cocinando " + recetaACocinar.nombre);
          numplatos++;
          yield return new WaitForSeconds(recetaACocinar.tiempo);
            cronoHorno.Stop();//------------------------------------------------------//SONIDO
            finCoccion.Play();//------------------------------------------------------//SONIDO
            platosCocinadosgo.Add(Instantiate(recetaACocinar.prefab, posPlatos, Quaternion.identity));
            platosCocinados.Add(recetaACocinar.nombre);
            //Plato pAux = go.GetComponent<Plato>();

            //comparar el que soy con los string de platos cocinados
            //platoInstanciadoGO.Add(go);
            ollaObject.SetActive(false);
                posPlatos.z += 2;
          Debug.Log(recetaACocinar.nombre + " lista.");
          
          //gm.dineroQTengo += recetaACocinar.precio;//HAY QUE CAMBIARLO
      

            //Debug.Log(platosCocinados);
            //platosCocinados.Add(recetaACocinar.nombre);
            //platosCocinadosObj.Add(recetaACocinar);

            //for (int i = 0; i < gm.pedidoActual0.Count; i++)
            //{
            //    if (gm.pedidoActual0[i]==recetaACocinar.nombre)
            //    {
            //        Debug.Log("has hecho una receta del pedido 0");
            //    }
            //}
            //for (int i = 0; i < gm.pedidoActual1.Count; i++)
            //{
            //    if (gm.pedidoActual1[i] == recetaACocinar.nombre)
            //    {
            //        platosCocinados.Add(recetaACocinar.nombre);
            //        Debug.Log("has hecho una receta del pedido 0");
            //    }
            //}
            //for (int i = 0; i < gm.pedidoActual2.Count; i++)
            //{
            //    if (gm.pedidoActual2[i] == recetaACocinar.nombre)
            //    {
            //        platosCocinados.Add(recetaACocinar.nombre);
            //        Debug.Log("has hecho una receta del pedido 0");
            //    }
            //}
        }
        if (numplatos>=8)
        {
            Debug.Log("No hay espacio");
        }
        //if (numplatos >8)
        //{
        //    numplatos = 0;
        //} esto es cuando interactues con los platos y te los lleves
    }

    //Cocinando
    public void TagliatelleBoloñesa()
    {
        if (numCarnePicada >= 1 && numCebolla >= 1 && numEspaguetis >= 1 && numTomate >= 2)
        {
            if (ollaObject.activeSelf == false)
            {
                numCarnePicada--;
                numCebolla--;
                numEspaguetis--;
                numTomate -= 2;
                StartCoroutine(Cocinando(rec.libroRecetas[0]));

            }
        }
        else
        {
            StartCoroutine(NoTienesSuficientesIngredientes());
        }

    }
    public void Carbonara()
    {
            
        if (numHuevo >= 2 && numGuanciale >= 2 && numQueso >= 1 && numEspaguetis >= 1)
        {
            if (ollaObject.activeSelf == false)
            {

                numHuevo -= 2;
                numGuanciale -= 2;
                numQueso--;
                numEspaguetis--;
            
            
                StartCoroutine(Cocinando(rec.libroRecetas[1]));
            }
        }
        else
        {
            StartCoroutine(NoTienesSuficientesIngredientes());
        }
    }
    public void PizzaProsciuttoeFunghi()
    {
        if (numHarina >= 1 && numAceiteDeOliva >= 1 && numJamon >= 1 && numChampiñones >= 2 )
        {
            if (ollaObject.activeSelf == false)
            {

                numHarina--;
                numAceiteDeOliva--;
                numJamon--;
                numChampiñones -= 2;
                StartCoroutine(Cocinando(rec.libroRecetas[2]));
            }
            
        }
        else
        {
            StartCoroutine(NoTienesSuficientesIngredientes());
        }
    }
    public void EnsaladaPiamontesa()
    {
        if (numPatata >= 3 && numJamon >= 2 && numMostaza >= 1 && numTomate >= 2 && numBerenjena >= 1 )
        {
            if (ollaObject.activeSelf == false)
            {

                numPatata -= 3;
                numJamon -= 2;
                numMostaza -= 1;
                numTomate -= 2;
                numBerenjena--;
                StartCoroutine(Cocinando(rec.libroRecetas[3]));
            }
        }
        else
        {
            StartCoroutine(NoTienesSuficientesIngredientes());
        }
    }
    public void Gelato()
    {
        if (numLeche >= 3 && numVainilla >= 1 && numAzucar >= 2 && numQuesoCrema >= 2 )
        {
            if (ollaObject.activeSelf == false)
            {

                numLeche -= 3;
                numVainilla--;
                numAzucar -= 2;
                numQuesoCrema -= 2;
                StartCoroutine(Cocinando(rec.libroRecetas[4]));
            }
        }
        else
        {
            StartCoroutine(NoTienesSuficientesIngredientes());
        }
    }
    public void Pastaececi()
    {
        if (numTomate >= 3 && numGarbanzos >= 3 && numEspaguetis >= 1 )
        {
            if (ollaObject.activeSelf == false)
            {

                numTomate -= 3;
                numGarbanzos -= 3;
                numEspaguetis--;
                StartCoroutine(Cocinando(rec.libroRecetas[5]));
            }
        }
        else
        {
            StartCoroutine(NoTienesSuficientesIngredientes());
        }
    }
    public void Arancini()
    {
        if (numArroz >= 2 && numQueso >= 2 && numHuevo >= 1 && numPanRallado >= 2)
        {
            if (ollaObject.activeSelf == false)
            {

                numArroz -= 2;
                numQueso -= 2;
                numHuevo--;
                numPanRallado -= 2;
                StartCoroutine(Cocinando(rec.libroRecetas[6]));
            }
        }
        else
        {
            StartCoroutine(NoTienesSuficientesIngredientes());
        }
    }
    public void PizzaNapolitana()
    {
        if (numHarina >= 3 && numAceiteDeOliva >= 2 && numTomate >= 2 && numQueso >= 3 && numAlbahaca >= 1)
        {
            if (ollaObject.activeSelf == false)
            {

                numHarina -= 3;
                numAceiteDeOliva -= 2;
                numTomate -= 2;
                numQueso -= 3;
                numAlbahaca--;
                StartCoroutine(Cocinando(rec.libroRecetas[7]));
            }
        }
        else
        {
            StartCoroutine(NoTienesSuficientesIngredientes());
        }
    }
    public void Tiramisu()
    {
        if (numQuesoCrema >= 2 && numBizcochoSoletilla >= 3 && numChocolate >= 2 )
        {
            if (ollaObject.activeSelf == false)
            {

                numQuesoCrema -= 2;
                numBizcochoSoletilla -= 3;
                numChocolate -= 2;
                StartCoroutine(Cocinando(rec.libroRecetas[8]));
            }
        }
        else
        {
            StartCoroutine(NoTienesSuficientesIngredientes());
        }
    }
    public void PizzaalPadellino()
    {
        if (numHarina >= 3 && numAceiteDeOliva >= 2 && numCalabaza >= 1 && numQueso >= 2 && numHierbas >= 1 )
        {
            if (ollaObject.activeSelf == false)
            {

                numHarina -= 3;
                numAceiteDeOliva -= 2;
                numCalabaza--;
                numQueso -= 2;
                numHierbas--;
                StartCoroutine(Cocinando(rec.libroRecetas[9]));
            }
        }
        else
        {
            StartCoroutine(NoTienesSuficientesIngredientes());
        }
    }
    public void Focaccia()
    {
        if (numHarina >= 2 && numAceiteDeOliva >= 1 && numHierbas >= 2 && numAceitunas >= 2)
        {
            if (ollaObject.activeSelf == false)
            {

                numHarina -= 2;
                numAceiteDeOliva--;
                numHierbas -= 2;
                numAceitunas -= 2;
                StartCoroutine(Cocinando(rec.libroRecetas[10]));
            }
        }
        else
        {
            StartCoroutine(NoTienesSuficientesIngredientes());
        }
    }
    public void CaponataSiciliana()
    {
        if (numTomate >= 1 && numPimientos >= 1 && numAnchoas >= 2 && numHarina >= 1 )
        {
            if (ollaObject.activeSelf == false)
            {

                numTomate--;
                numPimientos--;
                numAnchoas -= 2;
                numHarina--;
                StartCoroutine(Cocinando(rec.libroRecetas[11]));
            }
        }
        else
        {
            StartCoroutine(NoTienesSuficientesIngredientes());
        }
    }
    void Cobrar(int precio)
    {
        gm.dineroQTengo += precio;
    }
    IEnumerator NoTienesSuficientesIngredientes()
    {
        noTienesIngredientes.SetActive(true);
        yield return new WaitForSeconds(3f);
        noTienesIngredientes.SetActive(false);

    }
}
