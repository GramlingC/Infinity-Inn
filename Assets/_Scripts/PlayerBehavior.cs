using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float groundRaycastDist;

    public LayerMask groundLayer;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 moveVelocity = Vector2.zero;

        //Left, right, and jump
	    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity = moveSpeed * Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity = moveSpeed * Vector2.right;
        }

        moveVelocity.y = rb.velocity.y;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, groundRaycastDist, groundLayer))
            {
                //Raycast towards ground
                moveVelocity.y += jumpSpeed;
            }
        }

        //Debug.Log(moveVelocity);
        rb.velocity = moveVelocity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Lethal"))
        {
            Debug.Log("Dead");
        }
    }
}
