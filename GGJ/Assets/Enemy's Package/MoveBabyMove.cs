using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBabyMove : MonoBehaviour
{
    Rigidbody myRigidbody;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myRigidbody.velocity.y == 0)
        {
        myRigidbody.velocity = Vector3.forward * Time.deltaTime * speed;
        }
    }
}
