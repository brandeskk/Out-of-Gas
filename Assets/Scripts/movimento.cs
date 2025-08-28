using UnityEngine;
public class movimento : MonoBehaviour
{
    Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MoveAnimationLogic(movement);

    }

    void MoveAnimationLogic(Vector2 moveSpeed)
    {
        if (moveSpeed.y < 0)
        {
            animator.Play("replace");
            return;
        }

        if (moveSpeed.y > 0)
        {
            animator.Play("replace");
            return;
        }

        if (moveSpeed.x < 0)
        {
            animator.Play("replace");
            return;
        }

        if (moveSpeed.x > 0)
        {
            animator.Play("replace");
            return;
        }
        animator.Play("replace");
    }
}