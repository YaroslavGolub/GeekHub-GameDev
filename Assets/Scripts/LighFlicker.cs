using UnityEngine;
using System.Collections;

public class LighFlicker : MonoBehaviour
{
    public GameObject lamp;

    public float minTimeFlash;
    public float maxTimeFlash;

    public float scarryLampIntencity;
    public float normalLampIntencity;

    private float lastTimeFlashed;

    private static bool flashing = true;

    public float timeBetwieenFlash;

    private float timeBeforeLightOn;
    public Light lampLight;

    public static bool Flashing
    {
        get
        {
            return flashing;
        }

        set
        {
            flashing = value;
        }
    }

    void Start()
    {
        lastTimeFlashed = Time.time;
    }

    private void Update()
    {
        if (Flashing)
        {
            if (Time.time - lastTimeFlashed > timeBetwieenFlash)
            {
                lamp.SetActive(true);
                lastTimeFlashed = Time.time;
                lampLight.intensity = Random.Range(scarryLampIntencity, normalLampIntencity);
                timeBetwieenFlash = Random.Range(minTimeFlash, maxTimeFlash);
            }
            else
            {
                lamp.SetActive(false);
            }



            //lampLight.intensity = scarryLampIntencity;
        }
        else
        {
            lamp.SetActive(true);

            lampLight.intensity = normalLampIntencity;
        }
    }

    public void OnLevelWasLoaded(int level)
    {
        Flashing = true;
    }
}
