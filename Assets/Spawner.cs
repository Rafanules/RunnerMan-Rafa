using System.Collections;
using UnityEngine;

public class MoverObjetoConIncrementoYAleatoriedad : MonoBehaviour
{
    private Vector3 posicionInicial;
    public float velocidadInicialX = 0.7f; // Velocidad inicial en el eje X.
    private float velocidadX; // Velocidad actual que se actualizará.
    public float increaseAmount = 0.2f; // Cantidad en la que aumentará la velocidad.
    public float increaseInterval = 10f; // Intervalo de tiempo (en segundos) para el aumento de velocidad.
    private float duracionMovimiento = 4.0f; // Duración del movimiento antes de regresar a la posición inicial.

    void Start()
    {
        posicionInicial = transform.position; // Guarda la posición inicial del objeto.
        velocidadX = velocidadInicialX; // Inicializa la velocidad actual con la velocidad inicial.
        StartCoroutine(MoverConIncrementoYAleatoriedad());
    }

    IEnumerator MoverConIncrementoYAleatoriedad()
    {
        while (true) // Loop infinito para repetir el comportamiento.
        {
            // Espera un tiempo aleatorio antes de mover el objeto.
            yield return new WaitForSeconds(Random.Range(1f, 3f)); // Espera entre 1 y 3 segundos antes de iniciar el movimiento.

            // Mueve el objeto restando en el eje X durante 'duracionMovimiento'.
            float tiempoInicioMovimiento = Time.time;
            while (Time.time - tiempoInicioMovimiento < duracionMovimiento)
            {
                transform.position -= new Vector3(velocidadX * Time.deltaTime, 0, 0); // Resta en X para mover hacia la izquierda.
                yield return null;
            }

            // Restablece la posición inicial del objeto después de moverlo.
            transform.position = posicionInicial;

            // Espera un intervalo antes de incrementar la velocidad, ajustando el tiempo de espera para que el ciclo total dure 'increaseInterval'.
            yield return new WaitForSeconds(increaseInterval - (Time.time - tiempoInicioMovimiento));
            velocidadX += increaseAmount; // Incrementa la velocidad del objeto.
        }
    }
}
