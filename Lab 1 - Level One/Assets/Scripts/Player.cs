using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator animator;
    public float speedX = 1f;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        if (Mathf.Abs(moveX) > 0.1f)
        {
            float force = moveX * speedX;
            rb2d.AddForceX(force, ForceMode2D.Force);
        }
        animator.SetFloat("moveSpeedX", Mathf.Abs(moveX));
    }
}
