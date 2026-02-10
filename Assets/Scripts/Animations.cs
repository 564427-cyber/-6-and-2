using UnityEngine;

public class Animations : MonoBehaviour
{

    Animator animator;
    int WalkHash;
    int RunHash;
    int JumpHash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        WalkHash = Animator.StringToHash("Walk");
        RunHash = Animator.StringToHash("Run");
        JumpHash = Animator.StringToHash("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        bool Run = animator.GetBool(RunHash);
        bool Walk = animator.GetBool(WalkHash);
        bool Jump = animator.GetBool(JumpHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
        /*
        if (!Walk && forwardPressed)
        {
            animator.SetBool(WalkHash, true);
        }

        if (Walk && !forwardPressed)
        {
            animator.SetBool(WalkHash, false);
        }
       
        if (!Run && (forwardPressed && runPressed))
        {
            animator.SetBool(RunHash, true);
        }
        if (Run && (!forwardPressed || !runPressed))
        {
            animator.SetBool(RunHash, false);
        }
        */
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
