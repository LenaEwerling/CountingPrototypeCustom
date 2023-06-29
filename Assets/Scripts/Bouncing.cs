using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    public float upForce = 9f;
    private float dampingFactor = 0.8f; // Adjust this value to control the damping effect
    public Vector3 direction = new Vector3(0.3f, 1f, 0f);

    private Rigidbody rb;
    private Counter counter;
    public bool scored = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject counterObject = GameObject.Find("Box");
        counter = counterObject.GetComponent<Counter>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.AddForce(direction * upForce, ForceMode.Impulse);
            upForce *= dampingFactor;
            if (rb.position.x < -2 && scored)
            {
                counter.UpdateCounter(-1);
                scored = false;
            }
        }
    }

    public void RemoveAllForces()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        upForce = 0f;
    }
}
