using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesa : MonoBehaviour, IInteractuable
{
    public int numeroSillas;
    public bool mesaLibre; //mesa libre o no
    public bool sentados = false; //cuando se sientan
    public bool auxSentados = false; //están sentados?
    public bool mesaEncontrada = false; //encontrar mesa para grupo
    public bool pedidoCogido = false;//cuando cojas el pedido se pone a true pa q no les puedas atender varias veces
    public bool atendido = false;
    public GameObject cubo;

    public List<GameObject> bichitos = new List<GameObject>();
    public int id;

    //recojo las sillas que tiene la mesa y le asigno coordenadas
    public Vector3[] vecSillas;
    public GameObject[] sillas;
   
    List<Recetas.Receta> pedido = new List<Recetas.Receta>();
    public int precioAux = 0;
    //public int precioAux1 = 0;
    //public int precioAux2 = 0;

    [SerializeField] GameObject camara;
    Recetas scriptReceta;

    GameManager scriptGM;
    [SerializeField] GameObject gm;

    Encimera scEncimera;
   public  GameObject encimera;
    Atril scripAtril;
    public Outline outline;

    void Start()
    {
        scriptReceta = gm.GetComponent<Recetas>();
        scEncimera = encimera.GetComponent<Encimera>();
        scriptGM = gm.GetComponent<GameManager>();
        scripAtril = GameObject.Find("Atril").GetComponent<Atril>();
        vecSillas = new Vector3[numeroSillas];
        cubo.SetActive(false);
        outline = gameObject.GetComponent<Outline>();
        outline.enabled = false;
        //coger posición de las sillas.
        for (int i = 0; i < numeroSillas; i++)
        {
            vecSillas[i] = sillas[i].transform.position;
        }
    
    }


    void Update()
    {
        
        if (cubo.activeSelf==true)
        {
                
                //Debug.Log(bichitos.Count);

            for (int i = 0; i < bichitos.Count; i++)
            {
                //Debug.Log("He entrado al for");
                bichitos[i].tag = "COMIENDO";
            }
        }
    }

    public void OutlineMesa()
    {
        //hacer outline :)
    }


    //INTERACCIÓN PLAYER-MESA
    void IInteractuable.Interaction()//si este necesita un parametro de entrada, todos los IInteractuable tendrán que tenerlo también
    {
        if (sentados== true&& pedidoCogido==false)
        {
            CogerPedido(numeroSillas);
            atendido = true;
            pedidoCogido = true;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("mesa de " + numeroSillas);
        if (mesaEncontrada == true)
        {
            mesaLibre = false;
            Debug.Log("Escogida mesa de " + numeroSillas + ", está llena.");
            scriptGM.LlenaMesa(numeroSillas, vecSillas,id);
            sentados = true;
            auxSentados = true;
            for (int i = 0; i < scriptGM.GOsGenteSentada.Count; i++)
            {
                if (scriptGM.GOsGenteSentada[i].GetComponent<GatoCliente>().idMesa == id)
                {
                    Debug.Log("He entrado al if");
                    bichitos.Add(scriptGM.GOsGenteSentada[i]);
                }
            }
        }
    }

    List<Recetas.Receta> CogerPedido(int numSillas)
    {
        this.gameObject.tag = "atendidoMesa";
        precioAux = 0;
        int aux = 0;
        
        //-------
        int numAleatorio;
        List<int> auxA = new List<int>();
        for (int i = 0; i < numeroSillas; i++)
        {
            numAleatorio = Random.Range(0, 12);
            for (int j = 0; j < auxA.Count; j++)
            {
            
                while (numAleatorio == auxA[j])
                {
                    numAleatorio = Random.Range(0, 12);
                    for (int b = 0; b < j; b++)
                    {
                        while (numAleatorio == auxA[j])
                        {
                            numAleatorio = Random.Range(0, 12);

                        }
                    }
                 
                }
            }
                 auxA.Add(numAleatorio);
                 pedido.Add(scriptReceta.libroRecetas[numAleatorio]);
        }
        //-----
        for (int i = 0; i < numSillas; i++)
        {
            
            if (scriptGM.indicePedidos[0]== false && aux < 1)
            {
                scriptGM.mesaPedido0 = cubo;
                scriptGM.idsMesas[0] = id;
                for (int j = 0; j < pedido.Count; j++)
                {
                    scriptGM.pedidoActual0.Add(pedido[j].nombre);
                    Debug.Log("El pedido es: " + pedido[j].nombre);
                    precioAux += pedido[j].precio;
                }
                aux++;
                scriptGM.indicePedidos[0] = true;
            }
            else if (scriptGM.indicePedidos[1] == false && aux < 1)
            {
                scriptGM.mesaPedido1= cubo;
                scriptGM.idsMesas[1] = id;
                for (int j = 0; j < pedido.Count; j++)
                {
                    scriptGM.pedidoActual1.Add(pedido[j].nombre);
                    Debug.Log("El pedido es: " + pedido[j].nombre);
                    precioAux += pedido[j].precio;
                }
                aux++;
                scriptGM.indicePedidos[1] = true;
            }
            else if (scriptGM.indicePedidos[2] == false && aux < 1)
            {
                scriptGM.mesaPedido2 = cubo;
                scriptGM.idsMesas[2] = id;
                for (int j = 0; j < pedido.Count; j++)
                {
                    scriptGM.pedidoActual2.Add(pedido[j].nombre);
                    Debug.Log("El pedido es: " + pedido[j].nombre);
                    precioAux += pedido[j].precio;
                }
                aux++;
                scriptGM.indicePedidos[2] = true;
            }
            
        }
       
        return pedido;

      }


    

    List<Recetas.Receta> CogerPedidoAux()
    {
        int numAleatorio = Random.Range(0, 12);
        for (int i = 0; i < numeroSillas; i++)
        {
            pedido.Add(scriptReceta.libroRecetas[numAleatorio]);
        }
        return pedido;
    }


}

