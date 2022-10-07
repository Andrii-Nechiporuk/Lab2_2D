using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement1 : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpHeight = 450f;
    public bool isJumping;

    Vector2 movementVector;
    Rigidbody2D rbody;

    //VariableForDoorLogic
    public Rigidbody2D door;
    private bool isOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerVelocity = new Vector2(movementVector.x * movementSpeed, rbody.velocity.y);
        rbody.velocity = playerVelocity;
        
    }

    private void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
        Debug.Log(movementVector);
    } 
    private void OnJump(InputValue value)
    {
        if (value.isPressed && isJumping == false)
        {
            rbody.AddForce(new Vector2(rbody.velocity.x, jumpHeight));
            Debug.Log("jumpHeight");
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isJumping = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isJumping = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isOpened == false)
        {
            door.transform.position += new Vector3(0, -6.5f, 0);
            isOpened = true;
        }
        else
        {
            door.transform.position += new Vector3(0, 6.5f, 0);
            isOpened = false;
        }

    }
}
