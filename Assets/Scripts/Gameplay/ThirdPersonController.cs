using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{

    public CharacterController controller;

    public Transform camera;

    private float speed;

    public float walkSpeed = 6f;
    
    private float runSpeed;

    public float turnSmoothTime = 0.1f;
    private float targetAngle;
    private float smoothAngle;
    private float turnSmoothVelocity;
    private Vector3 moveDirection;
    
    // Start is called before the first frame update
    void Start()
    { 
        runSpeed = walkSpeed * 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //get direction
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(hAxis, 0, vAxis).normalized;

        //walk and run
        if (Input.GetKey(KeyCode.LeftShift))
            speed = runSpeed;
        if (!Input.GetKey(KeyCode.LeftShift))
            speed = walkSpeed;

        //move character
        if (direction.magnitude >= 0.1)
        {
            //get angle in degrees and camera direction
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            //smooth rotation
            smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //turn character to walk direction
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);

            //move in camera direction
            moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            //move
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
    }
}
