using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMover : MonoBehaviour
{
    [Header("Options")]
    public bool CanMoveLeftRight;

    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public GameObject pauseMenu;
    public GameObject WelcomeMenu;

    CharacterController characterController;
    public bool FootStepSounds;
    public bool JumpSounds;
    public AudioSource FootStepAudio;
    public AudioSource JumpAudio;

    [HideInInspector]
    public bool canMove = true;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public GameObject[] BodyParts;
    public GameObject SnakeHead;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;

        if (CanMoveLeftRight)
        {
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        }
        else
        {
            moveDirection = (forward * curSpeedX);
        }

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
            if (JumpSounds)
            {
                JumpAudio.Play();
            }
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove && Input.GetAxis("Vertical") > 0)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        if (Input.GetButtonDown("Vertical"))
        {
            SnakeHead.GetComponent<CamMover>().CanMove = false;
            transform.localEulerAngles = SnakeHead.transform.eulerAngles;
            SnakeHead.transform.localEulerAngles = new Vector3(0, 0, 0);

            if (FootStepSounds)
            {
                FootStepAudio.Play();
            }

            foreach (GameObject bp in BodyParts)
            {
                Animation anim = bp.GetComponent<Animation>();
                foreach (AnimationState state in anim)
                {
                    state.speed = 1;
                }
            }
        }
        if (Input.GetButtonUp("Vertical"))
        {
            SnakeHead.GetComponent<CamMover>().CanMove = true;

            FootStepAudio.Stop();

            foreach (GameObject bp in BodyParts)
            {
                Animation anim = bp.GetComponent<Animation>();
                foreach (AnimationState state in anim)
                {
                    state.speed = 0;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!WelcomeMenu.activeInHierarchy)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        /*rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);*/
    }

    public void IncreaseSpeed()
    {
        walkingSpeed += 1;
        foreach (GameObject bp in BodyParts)
        {
            bp.GetComponent<Target>().StartSpeed += 1;
        }
    }

}
