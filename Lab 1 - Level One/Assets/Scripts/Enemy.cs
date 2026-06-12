using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public Rigidbody2D rb2d;
    public LayerMask layerMask;
    public float distanceWallCheck = 1;
    public float distanceWallCheckOffSetY = -0.5f;
    public float distanceCheckLedge = 1;
    public SpriteRenderer spriteRenderer;
    public float patrolSpeedX = 3;
    public float chaseSpeedX = 7;
    public bool moveRight = true;
    public Transform EnemyEye;

    public string sceneToLoad;

    public Player player;
    public float playerChaseRadius = 4;

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(this.transform.position, player.transform.position);
        if (distanceToPlayer <= playerChaseRadius)
        {
            Chase();
        }
        else
        {
            Patrol();
        }
        
        spriteRenderer.flipX = !moveRight;

        //Vector3 pos = EnemyEye.localPosition;
        //pos.x = -pos.x;
        //EnemyEye.localPosition = pos;

    }

    void Chase()
    {
        moveRight = player.transform.position.x > this.transform.position.x;

        float linearVelocityX = moveRight ? +chaseSpeedX : -chaseSpeedX;
        rb2d.linearVelocityX = linearVelocityX;
    }

    void Patrol()
    {
        Vector2 wallDetectedOrigin = transform.position;
        wallDetectedOrigin.y += distanceWallCheckOffSetY;
        Vector2 wallDetectedDir = moveRight ? Vector2.right : Vector2.left;

        bool willHitWall = Physics2D.Raycast(wallDetectedOrigin, wallDetectedDir, distanceWallCheck, layerMask);
        Debug.DrawLine(wallDetectedOrigin, wallDetectedOrigin + wallDetectedDir * distanceWallCheck);

        Vector2 ledgeDetectOffsetDir = moveRight ? Vector2.right : Vector2.left;
        Vector2 ledgeDetectOrigin = (Vector2)transform.position + ledgeDetectOffsetDir;

        Vector2 ledgeDetectDir = Vector2.down;
        
        bool willWalkOffLedge = Physics2D.Raycast(ledgeDetectOrigin, ledgeDetectDir, distanceCheckLedge, layerMask);
        Debug.DrawLine(ledgeDetectOrigin, ledgeDetectOrigin + ledgeDetectDir * distanceCheckLedge);
        if (willHitWall == true ||  willWalkOffLedge == true)
        {
            moveRight = !moveRight;
            
        }

        float linearVelocityX = moveRight ? +patrolSpeedX : -patrolSpeedX;
        rb2d.linearVelocityX = linearVelocityX;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
