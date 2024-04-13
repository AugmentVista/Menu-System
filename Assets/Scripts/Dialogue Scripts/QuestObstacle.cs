using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObstacle : MonoBehaviour
{
    public GameObject on;
    public GameObject off;
    void Update()
    {
        if (on.activeSelf)
        {
            off.SetActive(false);
        }
        else if (!on.activeSelf)
        {
            off.SetActive(true);
        }
    }
}
