using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcam : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    void Awake()
    {
        offset = transform.position - target.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position+offset;
    }
}
