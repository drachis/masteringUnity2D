using UnityEngine;

public class CharacterMovement : MonoBehaviour 
{
    private Rigidbody2D playerRigidBody2D;
    private float movePlayerVector;
    private float jumpPlayerVector;
    private bool facingRight;
    public float speed = 4.0f;
    void Awake()
    {
        playerRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
    }

    void Update()
    {
        movePlayerVector = Input.GetAxis("Horizontal");
        jumpPlayerVector = Input.GetAxis("Jump");
        playerRigidBody2D.velocity = new Vector2(movePlayerVector * speed, playerRigidBody2D.velocity.y);

        if (movePlayerVector > 0 && !facingRight)
        {
            Flip();
        } else if  (movePlayerVector < 0 && facingRight)
        {
            Flip();
        }
        if (jumpPlayerVector > 0)
        {
            this.playerRigidBody2D.AddForce(new Vector2(0,25));
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
