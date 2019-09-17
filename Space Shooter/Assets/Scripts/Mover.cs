using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public Rigidbody sc;
    public float speed;

    void Start()
    {
        sc = GetComponent<Rigidbody>();
        sc.velocity = transform.forward * speed;
    }
}
