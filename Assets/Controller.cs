using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private float speed = 5f;
    //private float friction = 0.7f;
    //private float jumpStrength = 0.08f;

    private Quaternion rotation;
    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation;
        GameObject.Find("Camera").transform.rotation = Quaternion.Euler(15, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        rotation = transform.rotation;

        if(Input.GetKey(KeyCode.A)) {
            if(GetComponent<Rigidbody>().velocity[0] > -speed)
            GetComponent<Rigidbody>().AddForce(new Vector3(-10 * 10, 0, 0));
        }

        if(Input.GetKey(KeyCode.D)) {
            if(GetComponent<Rigidbody>().velocity[0] < speed)
            GetComponent<Rigidbody>().AddForce(new Vector3(10 * 10, 0, 0));
        }

        if(Input.GetKey(KeyCode.W)) {
            if(GetComponent<Rigidbody>().velocity[2] < speed)
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 10 * 10));
        }

        if(Input.GetKey(KeyCode.S)) {
            if(GetComponent<Rigidbody>().velocity[2] > -speed)
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -10 * 10));
        }

        if(canJump && Input.GetKey(KeyCode.Space)) {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 400 * 10, 0));
            canJump = false;
        }


        GameObject.Find("Camera").transform.position = transform.position + new Vector3(0, 5, -15);
    }

    void OnCollisionEnter(Collision other)
    {
        canJump = true;
    }
}
