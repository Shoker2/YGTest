using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadindCircle : MonoBehaviour
{
    void FixedUpdate()
    {
        gameObject.transform.Rotate(0, 0, -6.0f);
    }
}
