using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    bool isMoving;

    private Vector3 lastPosition = new Vector3(0f,0f,0f);

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // Resetting the defould velocity
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Getting the inputs
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        // Creating the moving vector
        Vector3 move = transform.right * X + transform.forward * Z; //(right - red axis, forward - blue axis)

        // Moving the player
        controller.Move(move * speed * Time.deltaTime);

        // Checking if the player van jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Actually jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Falling down
        velocity.y += gravity * Time.deltaTime;

        // Exetuting the jump
        controller.Move(velocity * Time.deltaTime);

        if (lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
            // For later use
        }
        else
        {
            isMoving=false;
            // For later use
        }

        lastPosition = gameObject.transform.position;





    }
}
