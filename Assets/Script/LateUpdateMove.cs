using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateUpdateMove : MonoBehaviour
{
    void Update()
    {
        this.transform.Translate(0, 0, Time.deltaTime);
    }
}