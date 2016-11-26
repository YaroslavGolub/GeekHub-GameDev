using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ball : MonoBehaviour
{
    private GameManager gMan;
    public Vector3 launchVelocity;
    public bool inPlay = false;

    private Vector3 startPosition;
    private Vector3 moveVector;
    private Rigidbody rbody;
    private bool firstPinCollision = false;

    public float forceToAdd;
    public Text forceText;

    private void Start()
    {
        gMan = FindObjectOfType<GameManager>();
        rbody = GetComponent<Rigidbody>();
        rbody.useGravity = false;
        startPosition = transform.position;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

        if (Input.GetMouseButton(0))
        {
            forceToAdd += 1;
            forceText.text = "Force : " + forceToAdd;

        }

        if (Input.GetMouseButtonUp(0))
        {
            launchVelocity.z = forceToAdd;
            forceToAdd = 0;
            if (!inPlay)
                Launch(launchVelocity);
        }
        Aim();

    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;

        rbody.useGravity = true;
        rbody.velocity = velocity;
    }

    public void Reset()
    {
        inPlay = false;
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        rbody.velocity = Vector3.zero;
        rbody.angularVelocity = Vector3.zero;
        rbody.useGravity = false;
    }

    private void Aim()
    {
        moveVector.x = Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Translate(moveVector);
    }

    public void OnCollisionEnter(Collision coll)
    {
        if (!firstPinCollision)
        {
            if (coll.gameObject.CompareTag("Pin"))
            {
                firstPinCollision = true;
                gMan.StartCoroutine("GameOver");

            }
        }
    }
}
