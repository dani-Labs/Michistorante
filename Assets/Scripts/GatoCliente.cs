using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoCliente : MonoBehaviour
{
    Vector3 posInicial;
    GameObject puntoEspera;
    Vector3 puntoEsperaPos;
    public bool llegado = false;
    public Vector3 posEspera;

    public AudioSource sonidoMeow;
    public AudioSource puertaCampana;

    GameObject gm;
    GameManager scGM;
    public int gente;

    Mesa[] scriptMesas;
    public GameObject[] mesas;
    public int idMesa;



    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
        gm = GameObject.FindWithTag("GameManager");
        scGM = gm.GetComponent<GameManager>();

        mesas = GameObject.FindGameObjectsWithTag("Mesa");
        scriptMesas = new Mesa[mesas.Length];
        for (int i = 0; i < mesas.Length; i++)
        {
            scriptMesas[i] = mesas[i].GetComponent<Mesa>();
        }
    }

    //IEnumerator IrAposEspera()
    //{
    //    while (llegado == false)
    //    {

    //        transform.position = Vector3.MoveTowards(this.transform.position, posEspera, 5 * Time.deltaTime);
    //        if (this.transform.position == puntoEsperaPos)
    //        {
    //            llegado = true;
    //            Debug.Log("llegado true");
    //        }

    //    }

    //    yield return new WaitForEndOfFrame(); 
    //}

    // Update is called once per frame
    void Update()
    {
        //gente = scGM.genteEsperando[0];
        //StartCoroutine(Enfado());
        if (llegado == false)
        {
            //Debug.Log("ayuda");
            transform.position = Vector3.MoveTowards(this.transform.position, posEspera, 5 * Time.deltaTime);
            if (this.transform.position == posEspera)
            {
                llegado = true;
                //Debug.Log("llegado true");
                sonidoMeow.Play();//-------------------------SONIDO
                puertaCampana.Play();//----------------------SONIDO
            }

        }
    }
    //public IEnumerator Enfado()
    //{
    //    if (llegado==true)
    //    {
    //        yield return new WaitForSeconds(30f);
    //        if (!this.gameObject.CompareTag("sentado"))
    //        {
    //            scGM.BajarEstrella();
    //            // Debug.Log("miau enfadado");
    //            //Destroy(this.gameObject);
    //            // llegado = false;
    //            // posEspera.z = -1.17f;
    //        }
    //    }
        //if (this.gameObject.CompareTag("sentado"))
        //{
        //    yield return new WaitForSeconds(30f);
        //    for (int i = 0; i < scriptMesas.Length; i++)
        //    {
        //        if (scriptMesas[i].CompareTag("atendidosMesa"))
        //        {
        //            this.gameObject.tag = "esperandoPedido";
        //        }
        //        else
        //        {
        //            Destroy(this.gameObject);
        //        }
        //    }
        //}
        //if (this.gameObject.CompareTag("esperandoPedido"))
        //{
        //    yield return new WaitForSeconds(30f);
        //    if (atendido == false)
        //    {
        //        Destroy(this.gameObject);
        //    }
        //}
        //yield return null;
   // }
    
}
