//using UnityEngine;

//public class PlayerMovementScript : MonoBehaviour
//{
//    //Serialize fields//
//    [Header("Player movement controls")]
//    [SerializeField] public float playerSpeed;
//    [SerializeField] public float playerSprintSpeed;
//    [SerializeField] public float playerJumpSpeed;
//    [SerializeField] public CharacterController controller;
//    [SerializeField] Transform playerView;

//    //numbers//
//    float rotX;
//    float rotY;
//    float rotZ;
//    float xMouseSensitivity=2f;
//    float yMouseSensitivity=2f;
//    float movementSpeed_;

//    //Bools//
//    bool isSprinting;
//    bool isJumping;
//    [SerializeField] bool holdJumpTojump= false;
//    struct Cmd
//    {
//        public float forwardMove;
//        public float rightMove;
//        public float upMove;
//    }
//    Cmd cmd;
//    Vector3 moveDirectionNorm = Vector3.zero;


//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        rotX -= Input.GetAxisRaw("Mouse Y") * xMouseSensitivity;
//        rotY += Input.GetAxisRaw("Mouse X") * yMouseSensitivity;

//        if (rotX < -90)
//        {
//            rotX = -90;
//        }
//        else if (rotX > 90)
//        {
//            rotX = 90;
//        }

//        Jumping();
//        Movement();

//    }

//    void Movement()
//    {
//        Vector3 movedirection;

//        SetMovementDir();

//        movedirection = new Vector3(cmd.rightMove, 0, cmd.forwardMove);
//        movedirection = transform.TransformDirection(movedirection);
//        movedirection.Normalize();
//        moveDirectionNorm = movedirection;

//        movementSpeed_ = movedirection.magnitude;
//        movementSpeed_ *= playerSpeed;

//        Sprinting();



//    }

//    void Sprinting()
//    {
//        if (Input.GetButton("Sprint"))
//        {
//            movementSpeed_ *= playerSprintSpeed;
//            isSprinting = true;
//        }
//        if (Input.GetButtonUp("Sprint"))
//        {
//            movementSpeed_ /= playerSprintSpeed;
//            isSprinting=false;
//        }
//    }

//    void Jumping()
//    {
//        if (holdJumpTojump)
//        {
//            isJumping = Input.GetButton("Jump");
//            return;
//        }

//        if (Input.GetButtonDown("Jump") && !isJumping)
//        {
//            isJumping = true;
//        }
//        if (Input.GetButtonUp("Jump"))
//        {
//            isJumping = false;
//        }
//    }

//    private void SetMovementDir()
//    {
//        cmd.forwardMove = Input.GetAxisRaw("Vertical");
//        cmd.rightMove = Input.GetAxisRaw("Horizontal");
//    }




//}
using UnityEngine;
using System.Collections;


public class PlayerMovementScript : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 15.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // Player is grounded, so recalculate move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }

            if(Input.GetButtonDown("Sprint"))
            {
                speed= speed*10f;
            }
        }

        // Apply the gravity. The gravity is multiplied by deltaTime twice 

        // when the moveDirection is multiplied by deltaTime), this is because gravity should be applied as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller!
        characterController.Move(moveDirection * Time.deltaTime);
    }
}