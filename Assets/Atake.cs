using System.Collections;
using UnityEngine;

public class Atake : MonoBehaviour
{
    public Transform objetoDestino;
    private bool enMovimiento = false;
    private Coroutine movimientoCorutina;
    private float targetYPosition; 

    void Start()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !enMovimiento)
        {
            movimientoCorutina = StartCoroutine(MoverEnX());
        }
        if (Input.GetKeyDown(KeyCode.W) && !enMovimiento && transform.position.y < 3.79f)
        {
            targetYPosition = Mathf.Min(transform.position.y + 2, 7.79f);
            StartCoroutine(MoverEnY(targetYPosition)); 
        }
        else if (Input.GetKeyDown(KeyCode.S) && !enMovimiento)
        {
            targetYPosition = Mathf.Max(transform.position.y - 2, -4.20f);
            StartCoroutine(MoverEnY(targetYPosition)); 
        }
    }

    IEnumerator MoverEnX()
    {
        enMovimiento = true;
        GetComponent<Renderer>().enabled = true;

        Vector2 direccionMovimiento = Vector2.right;
        float tiempoInicio = Time.time;
        float duracion = 5f;
        float velocidad = 5f;
        transform.position += new Vector3(1f, 0, 0);
        
        while (Time.time - tiempoInicio < duracion)
        {
            transform.position += new Vector3(direccionMovimiento.x * velocidad * Time.deltaTime, 0, 0);
            yield return null;
        }

        RegresarAPosicionInicial();
    }

    IEnumerator MoverEnY(float posicionY)
    {
        // Aquí va la lógica para mover el objeto hacia la posición deseada
        while (Mathf.Abs(transform.position.y - posicionY) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, posicionY, transform.position.z), Time.deltaTime * 5);
            yield return null;
        }
        enMovimiento = false;
    }

    void RegresarAPosicionInicial()
    {
        transform.position = new Vector3(objetoDestino.position.x, objetoDestino.position.y, transform.position.z);
        GetComponent<Renderer>().enabled = false;
        enMovimiento = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            DetenerYMoverAInicio();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            DetenerYMoverAInicio();
        }
    }

    void DetenerYMoverAInicio()
    {
        if (movimientoCorutina != null)
        {
            StopCoroutine(movimientoCorutina);
            movimientoCorutina = null;
        }
        RegresarAPosicionInicial();
    }
}
