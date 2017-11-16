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

    private INormalForm normalForm = new INormalForm();
    private IGhostForm ghostForm = new IGhostForm();

    private IPlayerForms currForm;

	// Use this for initialization
	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        currForm = normalForm;

        normalForm.Init(gameObject, rb, this);
        ghostForm.Init(gameObject, rb, this);        
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*Vector2 moveVelocity = Vector2.zero;

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
        rb.velocity = moveVelocity;*/
        currForm.PlayerMovement();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //May depend on what form the player is in
        if (other.gameObject.tag.Equals("Lethal"))
        {
            Debug.Log("Dead");
        }
    }

    //Method that sets certain variables and components of player based on the player's form
    public void SetForm(int formNum)
    {
        //0 = normal form
        //1 = ghost form
        switch (formNum)
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                rb.gravityScale = 1;
                currForm = normalForm;
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
                currForm = ghostForm;
                break;
        }
    }
}
