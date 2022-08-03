 using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
 using UnityEngine.Serialization;

 public class ThirdPersonController : MonoBehaviourPun
{
    public CharacterController controller;

    public Transform camera;

    public float walkSpeed = 3f;
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

    private Animator animator;
    [SerializeField] private GameObject player;

    
    // Start is called before the first frame update
    void Start()
    { 
        runSpeed = walkSpeed * 2.5f;
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
        
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isFalling", false);

        if (isGrounded)
        {
            if (vertVelocity.y < 0)
            {
                vertVelocity.y = -2f;
            }
            if (Input.GetButton("Jump"))
            {
                vertVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                animator.SetTrigger("isJumping");
                isJumping = true;
            }
        }
        else if ((isJumping || !isGrounded) && vertVelocity.y < -3f)
        {
            animator.SetBool("isFalling", true); 
            isJumping = false;
        }
        
        //gravity
        vertVelocity.y += gravity * Time.deltaTime;
        
        controller.Move(vertVelocity * Time.deltaTime);
        
        
        //get direction
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(hAxis, 0, vAxis).normalized;

        //walk and run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            animator.SetBool("isRunning", true);
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = walkSpeed;
            animator.SetBool("isRunning", false);
        }
        
        //move character
        if (direction.magnitude >= 0.1)
        {
            animator.SetBool("isWalking", true);
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
            animator.SetBool("isWalking", false);
    }
}
