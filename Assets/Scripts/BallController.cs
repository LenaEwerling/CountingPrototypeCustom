using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveSpeed = 0.02f;
    private Rigidbody rb;
    private Bouncing bounceScript;
    private Spawner spawner;
    private float verticalInput;
    private bool timerStarted = false;
    private bool canPressEnter = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        bounceScript = GetComponent<Bouncing>();
        GameObject spawnerObject = GameObject.Find("Spawner");
        spawner = spawnerObject.GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * verticalInput);
        
        if (Input.GetKeyDown(KeyCode.Return) && canPressEnter && !timerStarted)
        {
            rb.useGravity = true;
            bounceScript.upForce = rb.position.y * 2.25f;
            canPressEnter = false;
            StartCoroutine(Timer());
            StartCoroutine(DestroyIfStayInfrontOfBox());
        }

        if (rb.transform.position.x <= -15)
        {
            // float y = Random.Range(2f, 8f);
            // rb.transform.position = new Vector3(10f, y, 0f);
            // rb.useGravity = false;
            // bounceScript.RemoveAllForces();
            Destroy(gameObject);
        }
    }

    IEnumerator Timer()
    {
        if (!timerStarted)
        {
            yield return new WaitForSeconds(2);
            spawner.CreateBallInstance(1);
            timerStarted = true;
            canPressEnter = true;
        }
    }

    IEnumerator DestroyIfStayInfrontOfBox()
    {
        yield return new WaitForSeconds(10);
        if (rb.position.x >= 2f)
        {
            Destroy(gameObject);
        }
    }
}
