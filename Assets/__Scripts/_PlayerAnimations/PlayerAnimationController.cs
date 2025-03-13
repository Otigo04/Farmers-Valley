using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sprenderer;
    void Start()
    {
        animator = GetComponent<Animator>();
        sprenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);

        animator.SetFloat("Horizontal", moveX);
        if (moveX < 0) {
              sprenderer.flipX = true;
        }
        else if (moveX > 0){
            sprenderer.flipX = false;
        }
        animator.SetFloat("Vertical", moveY);

        animator.SetFloat("Speed", movement.sqrMagnitude);


    }
}
