using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{

    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    private float timer;
    private float waitingTime;
    private bool god;

 

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, 3f);

        timer = 0.0f;
        waitingTime = 1.0f;
        god = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            god = true;    
            StartCoroutine(WaitForIt());
        }
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(waitingTime);
        god = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if(god == false && other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
