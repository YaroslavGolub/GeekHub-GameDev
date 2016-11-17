using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public bool mooving = true;
    public string sceneToLoad;

    public Color32 initialColor = Color.gray;
    public Color32 colorToLerp = Color.green;

    private Renderer theRenderer;

    private ThePlayer player;

    private float distanceBetween;
    private float initialDistanceToPlayer;

    private Vector3 startPosition;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ThePlayer>();
        if(player != null)
            initialDistanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        theRenderer = GetComponent<Renderer>();
        startPosition = transform.position;
    }

    private void Update()
    {
        if(mooving)
            transform.position = startPosition + new Vector3(0, Mathf.Sin(Time.time), 0);

        if(player==null)
            return;

        distanceBetween = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log(distanceBetween / initialDistanceToPlayer + " | " + distanceBetween);
        theRenderer.material.color = Color.Lerp(colorToLerp, initialColor, distanceBetween / initialDistanceToPlayer);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
