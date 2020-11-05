using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController19 : MonoBehaviour
{
    bool isOnGround = true;
    float jumpForce = 10.0f;
    float gravityModifier = 2.0f;
    float moveSpeed = 8.0f;

    float xBoundary = 4.5f;
    float zBoundaryPos = 29.5f;
    float zBoundaryNeg = -9.5f;

    Rigidbody playerRb;

    public GameObject movingCube;

    // Start is called before the first frame update
    void Start()
    {
        isOnGround = true;
        Physics.gravity *= gravityModifier;

        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * moveSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * moveSpeed);


        if (transform.position.z > zBoundaryPos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundaryPos);
        }
        else if (transform.position.z < zBoundaryNeg)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundaryNeg);
        }
        else if (transform.position.x > xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xBoundary)
        {
            transform.position = new Vector3(-xBoundary, transform.position.y, transform.position.z);
        }

        PlayerJump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Moving"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, movingCube.transform.position.z);
            isOnGround = true;
        }

    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround == true)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
        }
    }
}
