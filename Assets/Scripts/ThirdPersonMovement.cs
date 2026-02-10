using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    Animator animator;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float smoothTurnVelocity;
    Vector3 direction;

    int WalkHash;
    int RunHash;
    int JumpHash;
    int IdleHash;

    private void Start()
    {
        animator = GetComponent<Animator>();
        WalkHash = Animator.StringToHash("Walk");
        RunHash = Animator.StringToHash("Run");
        JumpHash = Animator.StringToHash("Jump");
        IdleHash = Animator.StringToHash("Idle");
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
        print("mag=" + direction.magnitude);

    }

    void DoAnimation()
    {

        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);

        bool Run = animator.GetBool(RunHash);
        bool Jump = animator.GetBool(JumpHash);
        bool Idle = animator.GetBool(IdleHash);

        bool isMoving = direction.magnitude > 0.1f;



        if ( direction.magnitude > 0.1f && !runPressed)
        {
            animator.SetBool(WalkHash, true);
        }
        if(direction.magnitude < 0.1f)
        {
            animator.SetBool(WalkHash, false);
        }

        if(direction.magnitude > 0.1f && runPressed)
        {
            animator.SetBool(RunHash, true);
        }
        else
        {
            animator.SetBool(RunHash, false);
            animator.SetBool(WalkHash, true);
        }

        if (direction.magnitude < 0.1f && runPressed)
        {
            animator.SetBool(RunHash, false);
            animator.SetBool(WalkHash, false);
        }

        if (direction.magnitude < 0.1f && !runPressed)
        {
            animator.SetBool(RunHash, false);
            animator.SetBool(WalkHash, false);
        }

        if (runPressed && isMoving)
        {
            animator.SetBool (RunHash, true);   
        }
       
        if (runPressed && !isMoving)
        {
            animator.SetBool (RunHash, false);   
        }

        if (Jump && jumpPressed)
        {
            animator.SetBool(JumpHash, true);
        }

        if (!Jump && !jumpPressed)
        {
            animator.SetBool(JumpHash, false);
        }


    }

}
