using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ThirdPersonController : MonoBehaviourPun
{
    public CharacterController controller;

    public Transform camera;

    public float walkSpeed = 6f;
    private float speed;
    private float runSpeed;

    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    Vector3 vertVelocity;
    
    private bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isJumping;

    public float turnSmoothTime = 0.1f;
    private float targetAngle;
    private float smoothAngle;
    private float turnSmoothVelocity;
    private Vector3 moveDirection;

    private Animator _animator;
    public GameObject YBot;
    
    // Start is called before the first frame update
    void Start()
    { 
        runSpeed = walkSpeed * 1.5f;
        _animator = YBot.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        _animator.SetBool("isGrounded", isGrounded);
        _animator.SetBool("isFalling", false);

        // if (isGrounded)
        // {
        //     vertVelocity.y = gravity * Time.deltaTime;
        //     if (Input.GetKey(KeyCode.Space))
        //     {
        //         vertVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        //         _animator.SetTrigger("isJumping");
        //         isJumping = true;
        //     }
        //
        //     if (isJumping || !isGrounded)
        //     {
        //         _animator.SetBool("isFalling", true);
        //         isJumping = false;
        //     }
        //     // else 
        //     //     _animator.SetBool("isJumping", false);
        // }
        // else
        // {
        //     vertVelocity.y += gravity * Time.deltaTime;
        // }

        if (isGrounded)
        {
            if (vertVelocity.y < 0)
            {
                vertVelocity.y = -2f;
            }
            if (Input.GetButton("Jump"))
            {
                vertVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                _animator.SetTrigger("isJumping");
                isJumping = true;
            }
        }
        else if ((isJumping || !isGrounded) && vertVelocity.y < -3f)
        {
            _animator.SetBool("isFalling", true); 
            isJumping = false;
        }
        
        //gravity
        vertVelocity.y += gravity * Time.deltaTime;
        
        //gravity
        // vertVelocity.y += gravity * Time.deltaTime;
        controller.Move(vertVelocity * Time.deltaTime);
        
        
        if (!base.photonView.IsMine) return;
        //get direction
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(hAxis, 0, vAxis).normalized;

        //walk and run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _animator.SetBool("isRunning", true);
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = walkSpeed;
            _animator.SetBool("isRunning", false);
        }
        
        //move character
        if (direction.magnitude >= 0.1)
        {
            _animator.SetBool("isWalking", true);
            //get angle in degrees and camera direction
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            //smooth rotation
            smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                turnSmoothTime);
            //turn character to walk direction
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);

            //move in camera direction
            moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            //move
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
        else
            _animator.SetBool("isWalking", false);
    }
}
