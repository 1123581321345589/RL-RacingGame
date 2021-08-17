using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float speed = 7.0f;
    float boostSpeed = 7.0f;
    float rotSpeed = 70f;

    private float x;
    private float z;
    private float y;
    private float GameTime = 10.0f;
    private float timeSince = 0f;

    private float boostRem = 3.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //also set collider HERE when add collisions
    }

    // Update is called once per frame
    void Update()
    {

        z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        y = Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed;

        transform.Translate(Vector3.forward * z);
       /*
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (boostRem > 0)
            {
                rb.AddForce(Vector3.forward * boostSpeed, ForceMode.Impulse);
                boostRem = boostRem - 1.0f;
            }
        }
       */
        if(boostRem < 3.0f)
        {
            timeSince += Time.deltaTime;
            Debug.Log("Boost Regeneration: " + timeSince);
            if (timeSince >= GameTime)
            {
                timeSince = 0f;
                boostRem = boostRem + 1;
                //Debug.Log("Boost Remaining: " + boostRem);

            }
            Debug.Log("Boost Remaining: " + boostRem);
        }

        transform.Rotate(Vector3.up * y);

    }

    void FixedUpdate() //called before each internal physics update
    {
        Vector3 rotation = Vector3.forward * y;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        //rb.MovePosition(this.transform.position + this.transform.forward * x * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * angleRot);

    }
}
