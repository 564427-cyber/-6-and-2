using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public Animator animator;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float smoothTurnVelocity;
    Vector3 direction;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DoMovement();
        DoAnimation();

    }

    void DoMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothTurnVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
       

    }

    void DoAnimation()
    {

        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);

        bool isMoving = direction.magnitude > 0.1f;
        bool isRunning = isMoving && runPressed;


        print("running=" + isRunning + "  isMoving=" + isMoving);

        if (isRunning)
        {
            animator.SetBool("Run", true);
        }
        else if (isMoving)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Walk", true);

        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Walk", false);



        }

        if (jumpPressed)
        {
            animator.SetBool("Jump", true);
        }
        if (jumpPressed && isMoving)
        {
            animator.SetBool("Jump", true);
        }
        else if (isRunning && jumpPressed)
        {
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}