using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    public Rigidbody2D target;
    public SpriteRenderer targetSpriteRenderer;
    public float lookAheadOffsetX;

    [Range(0f, 1f)]
    public float lerpValue = 0.5f;

    
    void FixedUpdate()
    {
        bool isFacingLeft = targetSpriteRenderer.flipX == true;
        float offsetX = isFacingLeft 
            ? -lookAheadOffsetX 
            : +lookAheadOffsetX;
     
        
        Vector3 targetPosition = target.position;
        targetPosition.z = this.transform.position.z;

        targetPosition.x += offsetX;

        Vector3 newPosition = Vector3.Lerp(this.transform.position, targetPosition, lerpValue);
        this.transform.position = newPosition;
    }
}
