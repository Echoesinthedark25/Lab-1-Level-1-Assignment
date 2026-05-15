using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float speedX = 1f;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        bool isMovingHorizontally = (Mathf.Abs(moveX) > 0.1f);
        if (isMovingHorizontally)
        {
            bool isFacingLeft = moveX < 0;
            spriteRenderer.flipX = isFacingLeft;
            
            float force = moveX * speedX;
            rb2d.linearVelocityX = moveX * speedX;
        }
        animator.SetFloat("moveSpeedX", Mathf.Abs(moveX));
    }


    private void OnValidate()
    {
        if (rb2d == null)
            rb2d = GetComponent<Rigidbody2D>();

        if (animator == null)
            animator = GetComponent<Animator>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Reset()
    {

    }
}
