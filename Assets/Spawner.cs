using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    private Vector3 posicionInicial;
    public float velocidadInicialX = 0.7f;
    private float velocidadX;
    public float increaseAmount = 0.2f;
    public float increaseInterval = 10f;
    private float duracionMovimiento = 4.0f;
    public GameObject[] vidas;
    private int vidaActual = 0;
    private bool puedeMoverse = false;

    void Start()
    {
        posicionInicial = transform.position;
        velocidadX = velocidadInicialX;
        StartCoroutine(MoverConIncrementoYAleatoriedad());
    }

    void Update()
    {
        if (transform.position.x <= -12)
        {
            RestablecerPosicionYVelocidad();
        }
    }

    IEnumerator MoverConIncrementoYAleatoriedad()
    {
        while (true)
        {
            
            puedeMoverse = false;
            
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            
            puedeMoverse = true;
            float tiempoInicioMovimiento = Time.time;

            // Mueve el objeto hacia la izquierda
            while (puedeMoverse && Time.time - tiempoInicioMovimiento < duracionMovimiento)
            {
                transform.position -= new Vector3(velocidadX * Time.deltaTime, 0, 0);
                yield return null;
            }

            if (puedeMoverse)
            {
                
                RestablecerPosicionYVelocidad();
            }

            
            yield return new WaitForSeconds(increaseInterval - (Time.time - tiempoInicioMovimiento));
            velocidadX += increaseAmount;
        }
    }

    void RestablecerPosicionYVelocidad()
    {
        transform.position = posicionInicial;
        velocidadX = velocidadInicialX;
        StopCoroutine(MoverConIncrementoYAleatoriedad());
        StartCoroutine(MoverConIncrementoYAleatoriedad());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    Debug.Log($"Colisión detectada con: {collision.gameObject.tag} en el tiempo {Time.time}");
    	if (collision.gameObject.CompareTag("Disparo"))
        {
            RestablecerPosicionYVelocidad();
        }

            if (collision.gameObject.CompareTag("Player"))
             {
                if (vidaActual == 2)
                {
                    SceneManager.LoadScene("LoadScene");
                }else{
					Destroy(vidas[vidaActual]);
                	vidaActual++;
				}
            
            RestablecerPosicionYVelocidad();
        }
    }
}
