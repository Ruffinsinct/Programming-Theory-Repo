using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperties : MonoBehaviour
{
    public float points;

    // Start is called before the first frame update
    void OnDestroy()
    {
        FindObjectOfType<HungerManager>().AddPointsToHunger(points);    }

}
