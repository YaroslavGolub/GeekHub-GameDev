using UnityEngine;
using System.Collections;

public class Picture : MonoBehaviour
{
    public Paint paint;
    public string name;
    public string author;
    public string detailDescription;

    public string ShowName()
    {
        return name + "\n" + author;
    }
}
