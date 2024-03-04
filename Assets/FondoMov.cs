using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FondoMov : MonoBehaviour
{
    public RawImage _img;
    public float _x;
    public float y;
    public float increaseAmount = 0.1f; // La cantidad que quieres aumentar _x
    public float increaseInterval = 10f; // El intervalo cada cuántos segundos quieres aumentar la velocidad

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IncreaseSpeedOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, y) * Time.deltaTime, _img.uvRect.size);
    }

    IEnumerator IncreaseSpeedOverTime()
    {
        while(true) // Loop infinito
        {
            yield return new WaitForSeconds(increaseInterval); // Esperar 10 segundos
            _x += increaseAmount; // Aumentar la velocidad en la cantidad definida
        }
    }
}
