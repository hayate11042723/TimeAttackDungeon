using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abyss : MonoBehaviour
{
    public GameObject isObject;
    public float x;
    public float y;
    public float z;

    public string Tag;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tag))
        {
            isObject.transform.position = new Vector3(x, y, z);
        }
    }
}
