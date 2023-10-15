using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;
    private bool isAnimationPaused = false;

    public GameObject DepositUI;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.speed = 2f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.speed = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isAnimationPaused)
            {
                ResumeAnimation();
            }
            else
            {
                PauseAnimation();
            }
        }

        if (DepositUI.activeSelf)
        {
            PauseAnimation();
        }
    }

    private void PauseAnimation()
    {
        animator.speed = 0f; // Set the animation speed to 0 to pause it.
        isAnimationPaused = true;
    }

    private void ResumeAnimation()
    {
        animator.speed = 1f; // Set the animation speed to 1 to resume it.
        isAnimationPaused = false;
    }
}
