using UnityEngine;

public class CharacterMovement : MonoBehaviour 
{
    private Rigidbody2D playerRigidBody2D;
    private SpriteRenderer playerSprite;
    private float movePlayerVector;
    private float jumpPlayerVector;
    private bool facingRight;
    public float speed = 4.0f;
    private float jumpTime;
    private bool keepMoving = false;

    void Awake()
    {
        playerRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        playerSprite = (SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }

    void FixedUpdate()
    {
        
        movePlayerVector = Input.GetAxis("Horizontal");
        jumpPlayerVector = Input.GetAxis("Jump");

        if (movePlayerVector != 0.0f)
        {
            playerRigidBody2D.velocity = new Vector2(movePlayerVector * speed, playerRigidBody2D.velocity.y);
        }
        else if (keepMoving)
        {
            movePlayerVector = facingRight ? 1 : -1;
            playerRigidBody2D.velocity = new Vector2(movePlayerVector * speed, playerRigidBody2D.velocity.y);
        }
        
        if (movePlayerVector > 0 && !facingRight)
        {
            Flip();
        } else if (movePlayerVector < 0 && facingRight)
        {
            Flip();
        }
        if (jumpPlayerVector != 0 && jumpTime <= Time.time)
        {
            this.playerRigidBody2D.AddForce(new Vector2(0,5), ForceMode2D.Impulse);
            jumpTime = Time.time + 1.5f;
        }
    }

    public void stopHorizontal(bool stopRight)
    {
        keepMoving = false;
    }

    public void moveHorizontal( bool moveRight)
    {
        playerRigidBody2D.velocity = new Vector2((moveRight ? 1.0f : -1.0f) * speed, playerRigidBody2D.velocity.y);
        if (playerRigidBody2D.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (playerRigidBody2D.velocity.x < 0 && facingRight)
        {
            Flip();
        }
        keepMoving = true;
    }

    public void moveJump()
    {
        if ( jumpTime <= Time.time)
        {
            this.playerRigidBody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            jumpTime = Time.time + 1.5f;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        playerSprite.flipX = facingRight;
    }
}
