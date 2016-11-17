using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour
{
    private ThePlayer player;
    private Animator anim;

    public GameObject switcherHint;

    public float minDistanceToPlayer = 1.8f;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<ThePlayer>();

        anim.SetBool("On", !LighFlicker.Flashing);
    }

    private void Update()
    {
        if (player != null && Vector3.Distance(transform.position, player.transform.position) < minDistanceToPlayer)
        {
            //activate switcher interface
            switcherHint.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
                SwitchLight();
        }
        else
        {
            switcherHint.SetActive(false);
        }

    }

    public void SwitchLight()
    {
        LighFlicker.Flashing = !LighFlicker.Flashing;
        anim.SetBool("On", !LighFlicker.Flashing);
    }
}
