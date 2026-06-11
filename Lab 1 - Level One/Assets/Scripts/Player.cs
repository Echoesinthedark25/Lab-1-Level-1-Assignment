using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public CapsuleCollider2D capsuleCollider;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float moveSpeed = 10f;

    public WateringCanCollectable wateringCan;
    public LevelExit levelExit;
    public GameObject ExitFlag;

    public float jumpSpeed = 10f;
    public float maxJumpTime = 0.300f;

    public LayerMask groundLayer;

    public float raycastDistance = 0.05f;
    
    public float maxCoyoteTime = 0.100f;
    public float fallGravity = -10;

    private float coyoteTimeRemaining;
    private float jumpTimeRemaining;
    private bool isJumping;

    Vector2 edgeClipTopOrigin;
    Vector2 edgeClipBotOrigin;
    Vector2 edgeClipRayDistance;


    void Awake()
    {
        
    }



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {

        

        //Horizontal Movement

        float moveX = Input.GetAxis("Horizontal");
        bool isMovingHorizontally = (Mathf.Abs(moveX) > 0.1f);
        if (isMovingHorizontally)
        {
            bool isFacingLeft = moveX < 0;
            spriteRenderer.flipX = isFacingLeft;


            Vector2 centre = transform.position;
            Vector2 extents = capsuleCollider.bounds.extents;
            float extentsX = isFacingLeft ? -extents.x : +extents.x;
            edgeClipTopOrigin = centre + new Vector2(extentsX, extents.y);
            edgeClipBotOrigin = centre + new Vector2(extentsX, -extents.y);
            Vector2 direction = new Vector2(extentsX, 0).normalized;
            edgeClipRayDistance = direction * raycastDistance;
            bool hitTop = Physics2D.Raycast(edgeClipTopOrigin, direction, raycastDistance, groundLayer);
            bool hitBot = Physics2D.Raycast(edgeClipBotOrigin, direction, raycastDistance, groundLayer);
            if (hitTop == false && hitBot is false)
            {
                rb2d.linearVelocityX = moveX * moveSpeed;
            }
            Debug.DrawLine(edgeClipTopOrigin, edgeClipTopOrigin + edgeClipRayDistance, hitTop ? Color.red : Color.green);
            Debug.DrawLine(edgeClipBotOrigin, edgeClipBotOrigin + edgeClipRayDistance, hitBot ? Color.red : Color.green);


            rb2d.linearVelocityX = moveX * moveSpeed;
        }
        animator.SetFloat("moveSpeedX", Mathf.Abs(moveX));


        //Jump Function

        if (rb2d.linearVelocityY < 0)
        {
            rb2d.AddForceY(fallGravity);
        }

        coyoteTimeRemaining -= Time.deltaTime;

        Vector2 rayOrigin = this.transform.position;
        Vector2 rayDirection = Vector2.down;
        float distance = 1.05f;
        bool isGrounded = Physics2D.Raycast(rayOrigin, rayDirection, distance, groundLayer);
        if (isGrounded)
        {

            coyoteTimeRemaining = maxCoyoteTime;
            
        }

        if (isGrounded == true || coyoteTimeRemaining > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                coyoteTimeRemaining = 0;
                isJumping = true;
                jumpTimeRemaining = maxJumpTime;
            }
        }

        if (jumpTimeRemaining > 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb2d.linearVelocityY = jumpSpeed;
            }
            else
            {
                jumpTimeRemaining = 0;
            }

            jumpTimeRemaining -= Time.deltaTime;
            
        }

        animator.SetBool("isGrounded", isGrounded);

        if (wateringCan.NumberCollected >= 1)
        {
            ExitFlag.SetActive(true);
        }
    }


    private void OnValidate()
    {
        if (rb2d == null)
            rb2d = GetComponent<Rigidbody2D>();

        if (capsuleCollider == null)
            capsuleCollider = GetComponent<CapsuleCollider2D>();

        if (animator == null)
            animator = GetComponent<Animator>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Reset()
    {

    }
}
