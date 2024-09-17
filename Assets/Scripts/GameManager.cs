using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public List<int> mesasLibres = new List<int>();
    public List<int> mesas = new List<int>();
    public List<int> genteEsperando = new List<int>();
    public List<GameObject> GOsGenteEsperando = new List<GameObject>();
    public List<GameObject> GOsGenteSentada = new List<GameObject>();

    public GameObject prefabNPC;
    public GameObject spawner;
    private NavMeshAgent agenteGato;

    GameObject puntoEspera;
    Vector3 posEspera;
    Vector3 posEsperaInicial;
    Vector3 posNPCaux;

    public int dineroQTengo = 500;
    public float tiempo = 60f;

    Mesa[] scriptMesas;
    public GameObject[] mesasGO;

    public AudioSource dinero;
    public AudioSource angryMeow;

    //PEDIDOS
    public bool[] indicePedidos = new bool[3];
    public List<string> pedidoActual0 = new List<string>();
    public List<string> pedidoActual1 = new List<string>();
    public List<string> pedidoActual2 = new List<string>();

    public List<GameObject> checksPedido0 = new List<GameObject>();
    public List<GameObject> checksPedido1 = new List<GameObject>();
    public List<GameObject> checksPedido2 = new List<GameObject>();

    public GameObject mesaPedido0, mesaPedido1, mesaPedido2;
    //public int mp0, mp1, mp2;
    public int[] idsMesas = new int[3];
   // public Mesa[] mesasConPedido = new Mesa[3];

    public Animator anim;
    public GameObject[] estrellas = new GameObject[5];
    int auxEstrellas;

    GameObject cocina;
    Cocina scriptCocina;

    public GameObject botonEntrega0;
    public GameObject botonEntrega1;
    public GameObject botonEntrega2;

    int clientesSatisfechos = 0;
    void Start()
    {
        cocina = GameObject.FindGameObjectWithTag("Cocina");
        scriptCocina = cocina.GetComponent<Cocina>();

        mesasGO = GameObject.FindGameObjectsWithTag("Mesa");
        scriptMesas = new Mesa[mesasGO.Length];
        for (int i = 0; i < mesasGO.Length; i++)
        {
            scriptMesas[i] = mesasGO[i].GetComponent<Mesa>();
        }

        puntoEspera = GameObject.Find("puntoEspera");
        posEspera = puntoEspera.transform.position;
        posEsperaInicial = puntoEspera.transform.position;

        posNPCaux = spawner.transform.position;
        posNPCaux.z--;
        mesasLibres.Add(1);
        mesasLibres.Add(1);
        mesasLibres.Add(2);
        mesasLibres.Add(2);
        mesasLibres.Add(2);
        mesasLibres.Add(2);
        mesasLibres.Add(4);
        mesasLibres.Add(4);
        mesasLibres.Add(4);
        mesasLibres.Add(4);
        mesasLibres.Add(4);
        mesasLibres.Add(6);
        mesasLibres.Add(8);

        mesas.Add(1);
        mesas.Add(1);
        mesas.Add(2);
        mesas.Add(2);
        mesas.Add(2);
        mesas.Add(2);
        mesas.Add(4);
        mesas.Add(4);
        mesas.Add(4);
        mesas.Add(4);
        mesas.Add(4);
        mesas.Add(6);
        mesas.Add(8);

        int mesaEscogida = Random.Range(0, mesas.Count);
        Debug.Log("Grupo de " + mesas[mesaEscogida]);
        genteEsperando.Add(mesas[mesaEscogida]);

        StartCoroutine(SpawnearGrupo(mesas[mesaEscogida]));
        mesas.RemoveAt(mesaEscogida);
        for (int i = 0; i < indicePedidos.Length; i++)
        {
            indicePedidos[i] = false;
        }
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z)) // para subir
        //{
        //    // Debug.Log("z");
        //    if (auxEstrellas < 5)
        //    {
        //        anim = estrellas[auxEstrellas].GetComponent<Animator>();
        //        anim.SetBool("EstrellaActiva", true);
        //        anim.SetBool("EstrellaInactiva", false);
        //        auxEstrellas++;
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.X)) // para bajar
        //{
        //    // Debug.Log("x");
        //    if (auxEstrellas >=0)
        //    {
        //        auxEstrellas--;
        //        anim = estrellas[auxEstrellas].GetComponent<Animator>();
        //        anim.SetBool("EstrellaActiva", false);
        //        anim.SetBool("EstrellaInactiva", true);
        //    }
        //}
        tiempo -= Time.deltaTime;
        if (tiempo <= 0)
        {
            tiempo = 0;
        }
        if (mesas.Count > 0 && tiempo == 0 && genteEsperando.Count < 3)//TIMER
        {
            // cada vez que doy click una mesa libre se quita y pasa a ser gente esperando.

            int mesaEscogida = Random.Range(0, mesas.Count);
            Debug.Log("Grupo de " + mesas[mesaEscogida]);
            genteEsperando.Add(mesas[mesaEscogida]);

            StartCoroutine(SpawnearGrupo(mesas[mesaEscogida]));
            mesas.RemoveAt(mesaEscogida);

            if (auxEstrellas == 0)//POPULARIDAD
            {
                tiempo = 60f;
            }
            else if (auxEstrellas == 1)
            {
                tiempo = 50f;
            }
            else if (auxEstrellas == 2)
            {
                tiempo = 40f;
            }
            else if (auxEstrellas == 3)
            {
                tiempo = 30f;
            }
            else if (auxEstrellas == 4)
            {
                tiempo = 20f;
            }
            else if (auxEstrellas == 5)
            {
                tiempo = 10f;
            }
            else
            {
                tiempo = 60f;
            }

        }
        
    }

    public void MesaLibre(int id)
    {

    }

    public void LlenaMesa(int gente, Vector3[] posSillas, int id)
    {
        Vector3 pos;
        for (int i = 0; i < gente; i++)
        {
            agenteGato = GOsGenteEsperando[0].GetComponent<NavMeshAgent>();
            GatoCliente scriptGato = agenteGato.gameObject.GetComponent<GatoCliente>();
            //pos = new Vector3(posSillas[i].x, 0, posSillas[i].z);
            //agenteGato.SetDestination(pos);
            agenteGato.SetDestination(posSillas[i]);
            scriptGato.idMesa = id;
            GOsGenteSentada.Add(agenteGato.gameObject);
           
            Debug.Log(GOsGenteEsperando);
            agenteGato.gameObject.tag = "sentado";
            GOsGenteEsperando.RemoveAt(0);
            //posEspera = posEsperaInicial;
        }
        posEspera.z -= gente * 2;
        GameObject[] esperandoAux = GameObject.FindGameObjectsWithTag("esperando");
        GatoCliente gcAux;
        for (int i = 0; i < esperandoAux.Length; i++)
        {
            gcAux = esperandoAux[i].GetComponent<GatoCliente>();
            gcAux.posEspera.z -= gente * 2;
            gcAux.llegado = false;
        }

    }

        GameObject aux;
        GatoCliente auxSC;
    IEnumerator SpawnearGrupo(int gente)
    {
        posNPCaux.z++;
        for (int i = 0; i < gente; i++)
        {
            aux = Instantiate(prefabNPC, posNPCaux, Quaternion.Euler(0f, 180f, 0f));
            auxSC = aux.GetComponent<GatoCliente>();
            aux.GetComponent<GatoCliente>().posEspera = posEspera;
            GOsGenteEsperando.Add(aux);
            posNPCaux.z += 2;
            posEspera.z += 2;
        }
        yield return new WaitForSeconds(10f);
            StartCoroutine(Enfado(true, aux));
        //Instantiate(prefab, position:,quaternion.euler)
    }
    public IEnumerator EsperaComiendo(int idPedido)
    {
        Debug.Log("ñam ñam ñam");
        int auxIdMesa = idsMesas[idPedido];
        //switch (idPedido)
        //{
        //    default:
        //    case 0:
        //        mesaPedido0.SetActive(true);
        //        //auxIdMesa = mp0;
        //        break;
        //    case 1:
        //        mesaPedido1.SetActive(true);
        //        //auxIdMesa = mp1;
        //        break;
        //    case 2:
        //        mesaPedido2.SetActive(true);
        //       // auxIdMesa = mp2;
        //        break;
        //}
        Mesa mAux = null;
        for (int i = 0; i < scriptMesas.Length; i++)
        {
            if (scriptMesas[i].id == auxIdMesa)
            {
                mAux = scriptMesas[i];
            }
        }
        mAux.cubo.SetActive(true);
        //for (int j = 0; j < scriptMesas.Length; j++)
        //{
        //    if (scriptMesas[j].atendido == true)
        //    {
        //        scriptMesas[j].cubo.SetActive(true);
        //    }

        //}
        yield return new WaitForSeconds(15f);
        angryMeow.Play();//----------------------SONIDO
        for (int i = 0; i < GOsGenteSentada.Count; i++)
        {
            for (int j = 0; j < scriptMesas.Length; j++)
            {
                //if (GOsGenteSentada[i].CompareTag("COMIENDO") && scriptMesas[j].cubo.activeSelf == true && (scriptMesas[j] == mesasConPedido[idPedido]))
                if (GOsGenteSentada[i].CompareTag("COMIENDO") && scriptMesas[j].cubo.activeSelf == true && (scriptMesas[j] == mAux))
                {
                    for (int a = 0; a < scriptMesas[j].bichitos.Count; a++)
                    {
                        Destroy(scriptMesas[j].bichitos[a]);
                    }
                    Debug.Log("destruir");
                    //GOsGenteEsperando[i].gameObject.tag = "Terminado";
                    //Destroy(GOsGenteSentada[i]);
                    dineroQTengo += scriptMesas[j].precioAux;
                    Debug.Log(scriptMesas[j].cubo);
                    scriptMesas[j].cubo.SetActive(false);
                    mesas.Add(scriptMesas[j].numeroSillas);
                    mesasLibres.Add(scriptMesas[j].numeroSillas);
                    scriptMesas[j].mesaLibre = true;
                    scriptMesas[j].atendido = false;
                    scriptMesas[j].pedidoCogido = false;
                    scriptMesas[j].sentados = false;
                    indicePedidos[idPedido] = false;
                    pedidoActual0.Clear();
                    Debug.Log(pedidoActual0);
                    Debug.Log(indicePedidos[idPedido]);
                }

            }
        }

        dinero.Play();//-------------------------SONIDO
        Debug.Log("me voy");
        clientesSatisfechos++;

        if (clientesSatisfechos>=5) //POPULARIDAD
        {
            if (auxEstrellas < 5)
            {
                anim = estrellas[auxEstrellas].GetComponent<Animator>();
                anim.SetBool("EstrellaActiva", true);
                anim.SetBool("EstrellaInactiva", false);
                auxEstrellas++;
            }
            clientesSatisfechos = 0;
        }

    }
    //public void BajarEstrella()
    //{
    //    if (auxEstrellas >= 0)
    //    {
    //        auxEstrellas--;
    //        anim = estrellas[auxEstrellas].GetComponent<Animator>();
    //        anim.SetBool("EstrellaActiva", false);
    //        anim.SetBool("EstrellaInactiva", true);
    //    }
    //}
    public IEnumerator Enfado(bool llegado, GameObject gato)
    {
        Debug.Log(llegado);
        if (llegado == true)
        {
            yield return new WaitForSeconds(20f);
            if (!gato.gameObject.CompareTag("sentado"))
            {
                if (auxEstrellas > 0)
                {
                    auxEstrellas--;
                    anim = estrellas[auxEstrellas].GetComponent<Animator>();
                    anim.SetBool("EstrellaActiva", false);
                    anim.SetBool("EstrellaInactiva", true);
                }
                // Debug.Log("miau enfadado");
                //Destroy(this.gameObject);
                // llegado = false;
                // posEspera.z = -1.17f;
            }
        }
    }

    public void ServirCero()
    {
       int aux = 0;
        if (indicePedidos[0] == true)
        {
            for (int i = 0; i < pedidoActual0.Count; i++)
            {
                for (int j = 0; j < scriptCocina.platosCocinados.Count; j++)
                {
                    if (pedidoActual0[i] == scriptCocina.platosCocinados[j])
                    {
                        Debug.Log("HAY UN CHECK ACTIVADO");
                        aux++;
                    }
                }
            }
        }
        if (aux >= pedidoActual0.Count && aux!=0)
        {
            //PEDIDO 0
            botonEntrega0.SetActive(true);
        }
    }

    public void ServirUno()
    {
        int aux = 0;
        if (indicePedidos[1] == true)
        {
            for (int i = 0; i < pedidoActual1.Count; i++)
            {

                for (int j = 0; j < scriptCocina.platosCocinados.Count; j++)
                {
                    if (pedidoActual1[i] == scriptCocina.platosCocinados[j])
                    {
                        Debug.Log("HAY UN CHECK ACTIVADO");
                        aux++;
                    }
                }
            }
        }
        if (aux == pedidoActual1.Count && aux != 0)
        {
            //PEDIDO 1
            botonEntrega1.SetActive(true);
        }
    }

    public void ServirDos()
    {
        int aux = 0;
        List<string> pedidoActualAux = new List<string>();
        if (indicePedidos[2] == true)
        {
            for (int i = 0; i < pedidoActual2.Count; i++)
            {
                pedidoActualAux.Add(pedidoActual2[i]);
                for (int j = 0; j < scriptCocina.platosCocinados.Count; j++)
                {
                    if (pedidoActualAux[i] == scriptCocina.platosCocinados[j])
                    {
                        Debug.Log("HAY UN CHECK ACTIVADO");
                        Debug.Log(pedidoActualAux[i]);
                        aux++;
                        pedidoActualAux.RemoveAt(i);
                    }
                }
            }
        }
        if (aux >= pedidoActual2.Count && aux != 0)
        {
            //PEDIDO 0
            botonEntrega2.SetActive(true);
        }
    }
}
