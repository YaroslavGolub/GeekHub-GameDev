using System;
using UnityEngine;
using UnityEngine.UI;


public class GalleryHelper : MonoBehaviour
{
    public GameObject player;
    public Picture[] pictures;

    public Transform[] paintings;
    public Paint closestPaint;
    public string paintName;
    public Text paintsTextName;
    public Text detailText;
    public float shownDist = 10;
    public GameObject showMoreBtn;

    
    void Update()
    {
        CheckClosest();
    }

    private void CheckClosest()
    {
        //Find the closest one
        int closestIndex = 0;
        
        float dist = Vector3.SqrMagnitude(pictures[closestIndex].transform.position - player.transform.position);
        for (int i = 0; i < pictures.Length; i++)
        {
            float newDistance = Vector3.SqrMagnitude(pictures[i].transform.position - player.transform.position);
            if (newDistance < dist)
            {
                dist = newDistance;
                closestIndex = i;
                
                    //Enum.GetValues(typeof(Paint)).GetValue(closestIndex).ToString();
            }
        }

        if (dist <= shownDist)
        {
            showMoreBtn.GetComponent<Animator>().SetBool("isShown", true);

        }
        else
        {

            showMoreBtn.GetComponent<Animator>().SetBool("isShown", false);
        }

        Debug.Log(dist);
        
        ShowName(pictures[closestIndex].ShowName());
        ShowDescription(pictures[closestIndex].detailDescription);


    }

    private void ShowName(string nameToShow)
    {
        paintsTextName.text = nameToShow;
    }

    private void ShowDescription(string desc)
    {
        detailText.text = desc;
    }

}

public enum Paint
{
    VanGogh = 0,
    Dali = 1,
    MackeAugust,
    Petrov,
    Picasso
}
