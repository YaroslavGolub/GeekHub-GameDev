using UnityEngine;
using System.Collections;

public class ThePlayer : MonoBehaviour
{
    public float speed = 1.8f;

    private float rotation;

    private Vector3 moveDirection;

    private void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        moveDirection.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal");

        transform.Translate(moveDirection);
        transform.Rotate(0, rotation, 0);
    }
}
