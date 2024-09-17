using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Canvas : MonoBehaviour
{
    [SerializeField] GameObject canvasLibroRecetas;
    [SerializeField] GameObject canvasDespensa;
    [SerializeField] GameObject canvasPedidos;

    [SerializeField] Mesa mesa;

    [SerializeField] AudioSource sonidoPagina;

    //BOTONES CAMBIAR DIFICULTAD DE LOS PLATOS
    [SerializeField] GameObject facil;
    [SerializeField] GameObject medio;
    [SerializeField] GameObject dificil;

    [SerializeField] GameObject uiFacil;
    [SerializeField] GameObject uiMedio;
    [SerializeField] GameObject uiDificil;
    

    [SerializeField] GameObject[] paginasLibro;

    [SerializeField] GameObject Carnes;
    [SerializeField] GameObject Verduras;
    [SerializeField] GameObject Lacteos;
    [SerializeField] GameObject Pasta;
    [SerializeField] GameObject Dulces;

    [SerializeField] GameObject primeroVerduras;
    [SerializeField] GameObject segundoVerduras;

    [SerializeField] GameObject anteriorPagina1;
    [SerializeField] GameObject anteriorPagina2;
    [SerializeField] GameObject anteriorPagina3;
    [SerializeField] GameObject posteriorPagina1;
    [SerializeField] GameObject posteriorPagina2;
    [SerializeField] GameObject posteriorPagina3;

    GameObject camara;
    Recetas scriptReceta;
    GameObject cocina;
    Cocina scriptCocina;
    GameObject gameManager;
    GameManager scriptGameManager;

    [SerializeField] Text textoDinero;
    [SerializeField] GameObject EstrellasGrupo;
    [SerializeField] GameObject PantallaJuegoUI;

    public GameObject pedidoUI;
    public List<Text> textos;
    int precio;

    //30
    public Text[] numeroIngredientesUI = new Text[29];
   
    public void ClicComprar(int precioIngrediente)
    {
        precio = precioIngrediente;
    }

    void Start()
    {
        //coger scripts
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        scriptReceta = camara.GetComponent<Recetas>();
        cocina = GameObject.FindGameObjectWithTag("Cocina");
        scriptCocina = cocina.GetComponent<Cocina>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        scriptGameManager = gameManager.GetComponent<GameManager>();

        ActualizarTextosIngredientes();

    }

    
    void Update()
    {
        textoDinero.text = "" + scriptGameManager.dineroQTengo ;
    }

    public void SalidaLibroRecetas()
    {
        PantallaJuegoUI.SetActive(true);
;       canvasLibroRecetas.SetActive(false);
        canvasPedidos.SetActive(true);
    }
    public void SalidaDespensa()
    {
        EstrellasGrupo.SetActive(true);
        canvasDespensa.SetActive(false);
        canvasPedidos.SetActive(true);
    }

    public void Facil()
    {
        uiFacil.SetActive(true);
        uiMedio.SetActive(false);
        uiDificil.SetActive(false);

        facil.SetActive(true);
        medio.SetActive(false);
        dificil.SetActive(false);
    }
    public void Medio()
    {
        uiFacil.SetActive(false);
        uiMedio.SetActive(true);
        uiDificil.SetActive(false);

        facil.SetActive(false);
        medio.SetActive(true);
        dificil.SetActive(false);
    }
    public void Dificil()
    {
        uiFacil.SetActive(false);
        uiMedio.SetActive(false);
        uiDificil.SetActive(true);

        facil.SetActive(false);
        medio.SetActive(false);
        dificil.SetActive(true);
    }
    
    public void SiguientePagina()
    {
        sonidoPagina.Play();//--------------------------SONIDO

        if (facil.activeSelf)
        {
            if (paginasLibro[0].activeSelf)
            {
                anteriorPagina1.SetActive(true);
                posteriorPagina1.SetActive(false);
                paginasLibro[1].SetActive(true);
                paginasLibro[0].SetActive(false);
            }
        }
        if (medio.activeSelf)
        {
            if (paginasLibro[2].activeSelf)
            {
                anteriorPagina2.SetActive(true);
                posteriorPagina2.SetActive(false);
                paginasLibro[3].SetActive(true);
                paginasLibro[2].SetActive(false);
            }
        }
        if (dificil.activeSelf)
        {
            if (paginasLibro[4].activeSelf)
            {
                anteriorPagina3.SetActive(true);
                posteriorPagina3.SetActive(false);
                paginasLibro[5].SetActive(true);
                paginasLibro[4].SetActive(false);
            }
        }
    }
    public void AnteriorPagina()
    {
        if (facil.activeSelf)
        {
            if (paginasLibro[1].activeSelf)
            {
                anteriorPagina1.SetActive(false);
                posteriorPagina1.SetActive(true);
                paginasLibro[0].SetActive(true);
                paginasLibro[1].SetActive(false);
            }
        }
        if (medio.activeSelf)
        {
            if (paginasLibro[3].activeSelf)
            {
                anteriorPagina2.SetActive(false);
                posteriorPagina2.SetActive(true);
                paginasLibro[2].SetActive(true);
                paginasLibro[3].SetActive(false);
            }
        }
        if (dificil.activeSelf)
        {
            if (paginasLibro[5].activeSelf)
            {
                anteriorPagina3.SetActive(false);
                posteriorPagina3.SetActive(true);
                paginasLibro[4].SetActive(true);
                paginasLibro[5].SetActive(false);
            }
        }
    }

    public void Carnees()
    {
        Carnes.SetActive(true);
        Verduras.SetActive(false);
        Pasta.SetActive(false);
        Lacteos.SetActive(false);
        Dulces.SetActive(false);
    }
    public void Lacteoos()
    {
        Carnes.SetActive(false);
        Verduras.SetActive(false);
        Pasta.SetActive(false);
        Lacteos.SetActive(true);
        Dulces.SetActive(false);
    }
    public void Verduraas()
    {
        Carnes.SetActive(false);
        Verduras.SetActive(true);
        Pasta.SetActive(false);
        Lacteos.SetActive(false);
        Dulces.SetActive(false);
    }
    public void Pastass()
    {
        Carnes.SetActive(false);
        Verduras.SetActive(false);
        Pasta.SetActive(true);
        Lacteos.SetActive(false);
        Dulces.SetActive(false);
    }
    public void Dulcees()
    {
        Carnes.SetActive(false);
        Verduras.SetActive(false);
        Pasta.SetActive(false);
        Lacteos.SetActive(false);
        Dulces.SetActive(true);
    }

    public void Comprar(int indiceIngredientes)
    {
        if (scriptGameManager.dineroQTengo >= precio)
        {
            scriptGameManager.dineroQTengo -= precio;
            switch (indiceIngredientes)//scriptReceta.ingredientes)
            {
                case 0://Huevo
                    scriptCocina.numHuevo++;
                    numeroIngredientesUI[14].text = "(" + scriptCocina.numHuevo + ")";
                    break;
                case 1://guanciale
                    scriptCocina.numGuanciale++;
                    numeroIngredientesUI[0].text = "(" + scriptCocina.numGuanciale + ")";
                    //Debug.Log("Has comprado! Ahora tienes " + scriptCocina.numGuanciale + " " + scriptReceta.ingredientes[indiceIngredientes]);
                    break;
                case 2://Queso
                    scriptCocina.numQueso++;
                    numeroIngredientesUI[15].text = "(" + scriptCocina.numQueso + ")";
                    break;
                case 3://espaguetis
                    scriptCocina.numEspaguetis++;
                    numeroIngredientesUI[19].text = "(" + scriptCocina.numEspaguetis + ")";
                    break;
                case 4://Harina
                    scriptCocina.numHarina++;
                    numeroIngredientesUI[20].text = "(" + scriptCocina.numHarina + ")";
                    break;
                case 5://berenjena
                    scriptCocina.numBerenjena++;
                    numeroIngredientesUI[5].text = "(" + scriptCocina.numBerenjena + ")";
                    break;
                case 6://Pimientos
                    scriptCocina.numPimientos++;
                    numeroIngredientesUI[6].text = "(" + scriptCocina.numPimientos + ")";
                    break;
                case 7://Tomate
                    scriptCocina.numTomate++;
                    numeroIngredientesUI[7].text = "(" + scriptCocina.numTomate + ")";
                    break;
                case 8://Calabazaç
                    scriptCocina.numCalabaza++;
                    numeroIngredientesUI[8].text = "(" + scriptCocina.numCalabaza + ")";
                    break;
                case 9://Garbanzos
                    scriptCocina.numGarbanzos++;
                    numeroIngredientesUI[9].text = "(" + scriptCocina.numGarbanzos + ")";
                    break;
                case 10://Anchoas
                    scriptCocina.numAnchoas++;
                    numeroIngredientesUI[1].text = "(" + scriptCocina.numAnchoas + ")";
                    break;
                case 11://Champiñones
                    scriptCocina.numChampiñones++;
                    numeroIngredientesUI[10].text = "(" + scriptCocina.numChampiñones + ")";
                    break;
                case 12://Hierbas
                    scriptCocina.numHierbas++;
                    numeroIngredientesUI[11].text = "(" + scriptCocina.numHierbas + ")";
                    break;
                case 13://Queso crema
                    scriptCocina.numQuesoCrema++;
                    numeroIngredientesUI[16].text = "(" + scriptCocina.numQuesoCrema + ")";
                    break;
                case 14://Carne Picada
                    scriptCocina.numCarnePicada++;
                    numeroIngredientesUI[3].text = "(" + scriptCocina.numCarnePicada + ")";
                    break;
                case 15://Aceite
                    scriptCocina.numAceiteDeOliva++;
                    numeroIngredientesUI[21].text = "(" + scriptCocina.numAceiteDeOliva + ")";
                    break;
                case 16://Jamon
                    scriptCocina.numJamon++;
                    numeroIngredientesUI[2].text = "(" + scriptCocina.numJamon + ")";
                    break;
                case 17://Patata
                    scriptCocina.numPatata++;
                    numeroIngredientesUI[12].text = "(" + scriptCocina.numPatata + ")";
                    break;
                case 18://Mostaza
                    scriptCocina.numMostaza++;
                    numeroIngredientesUI[17].text = "(" + scriptCocina.numMostaza + ")";
                    break;
                case 19://cabolla
                    scriptCocina.numCebolla++;
                    numeroIngredientesUI[13].text = "(" + scriptCocina.numCebolla + ")";
                    break;
                case 20://Leche
                    scriptCocina.numLeche++;
                    numeroIngredientesUI[18].text = "(" + scriptCocina.numLeche + ")";
                    break;
                case 21://Vainilla
                    scriptCocina.numVainilla++;
                    numeroIngredientesUI[24].text = "(" + scriptCocina.numVainilla + ")";
                    break;
                case 22://azucar
                    scriptCocina.numAzucar++;
                    numeroIngredientesUI[25].text = "(" + scriptCocina.numAzucar + ")";
                    break;
                case 23://chocolate
                    scriptCocina.numChocolate++;
                    numeroIngredientesUI[26].text = "(" + scriptCocina.numChocolate + ")";
                    break;
                case 24://Pasta corta
                    scriptCocina.numPastaCorta++;
                    Debug.Log("Has comprado! Ahora tienes " + scriptCocina.numPastaCorta + " " + scriptReceta.ingredientes[indiceIngredientes]);
                    break;
                case 25://arroz
                    scriptCocina.numArroz++;
                    numeroIngredientesUI[22].text = "(" + scriptCocina.numArroz + ")";
                    break;
                case 26://pan rallado
                    scriptCocina.numPanRallado++;
                    numeroIngredientesUI[23].text = "(" + scriptCocina.numPanRallado + ")";
                    break;
                case 27://albahaca
                    scriptCocina.numAlbahaca++;
                    numeroIngredientesUI[4].text = "(" + scriptCocina.numAlbahaca + ")";
                    break;
                case 28://bizococ
                    scriptCocina.numBizcochoSoletilla++;
                    numeroIngredientesUI[27].text = "(" + scriptCocina.numBizcochoSoletilla + ")";
                    break;
                case 29://aceitunas
                    scriptCocina.numAceitunas++;
                    numeroIngredientesUI[28].text = "(" + scriptCocina.numAceitunas+ ")";
                    break;
            }
        }
        else
        {
            Debug.Log("No tienes suficiente dinero");
        }
       
    }
  
    public void AbrirPedido(int id)
    {
        scriptGameManager.botonEntrega0.SetActive(false);
        scriptGameManager.botonEntrega1.SetActive(false);
        scriptGameManager.botonEntrega2.SetActive(false);
        for (int i = 0; i < textos.Count; i++)//reiniciar checks
        {
            textos[i].enabled = false;
           
        }
       
        if (pedidoUI.activeSelf==false)
        {
            pedidoUI.SetActive(true);
            if (id == 0)
            {
                scriptCocina.BorrarChecks();
                //for (int k = 0; k < scriptGameManager.checksPedido0.Count; k++)
                //{
                //    //if (scriptGameManager.checksPedido0[k].activeSelf)
                //    //{
                //    //   Debug.Log("mevoy");
                //    //   scriptGameManager.checksPedido2[k].SetActive(false);
                //    //   scriptGameManager.checksPedido1[k].SetActive(false);
                //    //}


                //}

                Debug.Log(id);
                Debug.Log(scriptGameManager.pedidoActual0.Count);
                for (int i = 0; i < scriptGameManager.pedidoActual0.Count; i++)
                {
                    Debug.Log("hhhhhhhhhhhhhhhh");
                    textos[i].text = scriptGameManager.pedidoActual0[i];
                    textos[i].enabled = true;
                }
                scriptCocina.ComprobarCero();
                //scriptGameManager.ServirCero();
            }
            else if (id == 1)
            {
                scriptCocina.BorrarChecks();
                //for (int k = 0; k < scriptGameManager.checksPedido1.Count; k++)
                //{
                //    //if (scriptGameManager.checksPedido1[k].activeSelf)
                //    //{
                //    //    scriptGameManager.checksPedido2[k].SetActive(false);
                //    //    scriptGameManager.checksPedido0[k].SetActive(false);
                //    //}
                //}
                for (int i = 0; i < scriptGameManager.pedidoActual1.Count; i++)
                {
                    textos[i].text = scriptGameManager.pedidoActual1[i];
                    textos[i].enabled = true;
                }
                scriptCocina.ComprobarUno();
                //scriptGameManager.ServirUno();
            }
            else if (id==2)
            {
                scriptCocina.BorrarChecks();
                //for (int k = 0; k < scriptGameManager.checksPedido2.Count; k++)
                //{
                //    //if (scriptGameManager.checksPedido2[k].activeSelf)
                //    //{
                //    //    scriptGameManager.checksPedido0[k].SetActive(false);
                //    //    scriptGameManager.checksPedido1[k].SetActive(false);
                //    //}
                //}
                for (int i = 0; i < scriptGameManager.pedidoActual2.Count; i++)
                {
                    textos[i].text = scriptGameManager.pedidoActual2[i];
                    textos[i].enabled = true;
                }
                scriptCocina.ComprobarDos();
                //scriptGameManager.ServirDos();
            }
        }
        else
        {
            pedidoUI.SetActive(false);
            //for (int i = 0; i < scriptGameManager.checks.Count; i++)//reiniciar checks
            //{
            //    scriptGameManager.checks[i].SetActive(false);
            //}
        }
        //scriptCocina.Comprobar();
       
    }
    public void ActualizarTextosIngredientes()
    {
        numeroIngredientesUI[14].text = "(" + scriptCocina.numHuevo + ")";
        numeroIngredientesUI[0].text = "(" + scriptCocina.numGuanciale + ")";
        numeroIngredientesUI[15].text = "(" + scriptCocina.numQueso + ")";
        numeroIngredientesUI[19].text = "(" + scriptCocina.numEspaguetis + ")";
        numeroIngredientesUI[20].text = "(" + scriptCocina.numHarina + ")";
        numeroIngredientesUI[5].text = "(" + scriptCocina.numBerenjena + ")";
        numeroIngredientesUI[6].text = "(" + scriptCocina.numPimientos + ")";
        numeroIngredientesUI[7].text = "(" + scriptCocina.numTomate + ")";
        numeroIngredientesUI[8].text = "(" + scriptCocina.numCalabaza + ")";
        numeroIngredientesUI[9].text = "(" + scriptCocina.numGarbanzos + ")";
        numeroIngredientesUI[1].text = "(" + scriptCocina.numAnchoas + ")";
        numeroIngredientesUI[10].text = "(" + scriptCocina.numChampiñones + ")";
        numeroIngredientesUI[11].text = "(" + scriptCocina.numHierbas + ")";
        numeroIngredientesUI[16].text = "(" + scriptCocina.numQuesoCrema + ")";
        numeroIngredientesUI[3].text = "(" + scriptCocina.numCarnePicada + ")";
        numeroIngredientesUI[21].text = "(" + scriptCocina.numAceiteDeOliva + ")";
        numeroIngredientesUI[2].text = "(" + scriptCocina.numJamon + ")";
        numeroIngredientesUI[12].text = "(" + scriptCocina.numPatata + ")";
        numeroIngredientesUI[17].text = "(" + scriptCocina.numMostaza + ")";
        numeroIngredientesUI[13].text = "(" + scriptCocina.numCebolla + ")";
        numeroIngredientesUI[18].text = "(" + scriptCocina.numLeche + ")";
        numeroIngredientesUI[24].text = "(" + scriptCocina.numVainilla + ")";
        numeroIngredientesUI[25].text = "(" + scriptCocina.numAzucar + ")";
        numeroIngredientesUI[26].text = "(" + scriptCocina.numChocolate + ")";
        numeroIngredientesUI[22].text = "(" + scriptCocina.numArroz + ")";
        numeroIngredientesUI[23].text = "(" + scriptCocina.numPanRallado + ")";
        numeroIngredientesUI[4].text = "(" + scriptCocina.numAlbahaca + ")";
        numeroIngredientesUI[27].text = "(" + scriptCocina.numBizcochoSoletilla + ")";
        numeroIngredientesUI[28].text = "(" + scriptCocina.numAceitunas + ")";
    }
   
}

