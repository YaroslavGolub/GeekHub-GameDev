using UnityEngine;
using System.Collections;

public class Oscillator : MonoBehaviour
{
    private float timeCounter;

    public float speed;    
    public float amplitude = 1; 

    private Vector3 pos;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = pos = transform.position;
    }
    void Update()
    {
        if (LighFlicker.Flashing)
        {
            timeCounter += Time.deltaTime * speed;
            pos.x += amplitude * Mathf.Cos(timeCounter);            
            transform.position = pos;
        }
        else
        {
            transform.position = startPosition;
        }
    }
}
