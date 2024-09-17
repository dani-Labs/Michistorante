using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Movimiento basico personaje
    [SerializeField] Rigidbody rb;
    Vector3 moverse;
    [SerializeField] int velocidad;
    Vector3 otroInput;
    //hjijbjknkj

    //Toma de pedidos
    [SerializeField] Transform posOverlap;
    [SerializeField] float radio;
    Collider[] overlapColl;
    bool tocandoAlgo;

    [SerializeField] GameObject canvasNevera;
    [SerializeField] GameObject canvasPedidos;

    [SerializeField] GameObject EstrellasGrupo;
    void Start()
    {



    }


    void Update()
    {
        CorreccionRotacion();
        Overlap();
        Inputs();
        ADondeMira();


    }
    private void FixedUpdate()
    {
        Movimiento();
    }
    void ADondeMira()
    {
        if (moverse != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, -45, 0));

            otroInput = matrix.MultiplyPoint3x4(moverse);

            var relative = (transform.position + otroInput) - transform.position;
            var rotacion = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = rotacion;
        }
    }
    void Movimiento()
    {

        rb.MovePosition(transform.position + (-transform.right * moverse.magnitude) * velocidad * Time.deltaTime);
    }
    void Inputs()
    {
        moverse = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.E) && ComprobarOverlap())//hay algo en mi radio de interacción y he presionado E 
        {
            if (overlapColl[0].TryGetComponent<IInteractuable>(out IInteractuable mesaInteraction) && overlapColl[0].CompareTag("Mesa"))
            {
                mesaInteraction.Interaction();
            }
            else if (overlapColl[0].TryGetComponent<IInteractuable>(out IInteractuable cocinaInteraction) && overlapColl[0].CompareTag("Cocina"))
            {
                cocinaInteraction.Interaction();
            }
            else if (overlapColl[0].TryGetComponent<IInteractuable>(out IInteractuable atrilInteraction) && overlapColl[0].CompareTag("Atril"))
            {
                atrilInteraction.Interaction();
            }
            else if (overlapColl[0].CompareTag("Nevera"))
            {
                canvasNevera.SetActive(true);
                EstrellasGrupo.SetActive(false);
                canvasPedidos.SetActive(false);
            }
            else if (overlapColl[0].TryGetComponent<IInteractuable>(out IInteractuable basuraInteraction) && overlapColl[0].CompareTag("Basura"))
            {
                basuraInteraction.Interaction();
            }
            else if (overlapColl[0].TryGetComponent<IInteractuable>(out IInteractuable encimeraInteraction) && overlapColl[0].CompareTag("Encimera"))
            {
                encimeraInteraction.Interaction();
            }
        }
    }
    void Overlap()
    {
        overlapColl = Physics.OverlapSphere(posOverlap.position, radio);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(posOverlap.position, radio);
    }
    bool ComprobarOverlap()
    {
        if (overlapColl == null)
        {
            tocandoAlgo = false;
        }
        else
        {
            tocandoAlgo = true;
        }
        return tocandoAlgo;
    }
    void CorreccionRotacion()
    {
        //he tenido que crear este método porque al colisionar con un collider se "caía" el player, a pesar de tener la rotación en X y en Z freezeados :(
        Quaternion qt = this.transform.rotation;
        qt.x = 0;
        qt.z = 0;
        this.transform.rotation = qt;
    }
}

