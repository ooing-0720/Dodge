using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    private Color color;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        color = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            color.a = 0.5f;
            GetComponent<Renderer>().material.color = color;
            StartCoroutine(WaitForIt());
        }
            
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1f);
        color.a = 1f;
        GetComponent<Renderer>().material.color = color;
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
