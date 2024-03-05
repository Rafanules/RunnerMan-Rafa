using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FondoMov : MonoBehaviour
{
    public RawImage _img;
    public float _x;
    public float y;
    public float increaseAmount = 0.1f; 
    public float increaseInterval = 15f; // Cada cuanto sube la velocidad

    void Start()
    {
        StartCoroutine(IncreaseSpeedOverTime());
    }

    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, y) * Time.deltaTime, _img.uvRect.size);
    }

    IEnumerator IncreaseSpeedOverTime()
    {
        while(true) 
        {
            yield return new WaitForSeconds(increaseInterval);
            _x += increaseAmount; 
        }
    }
}
