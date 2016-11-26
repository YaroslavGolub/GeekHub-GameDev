using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour
{
    private Rigidbody rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    public bool IsFallen()
    {
        if (transform.up.y < 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
