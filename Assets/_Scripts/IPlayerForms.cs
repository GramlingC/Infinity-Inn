using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerForms
{
    //Kind of like a constructor - passes in some parameters from PlayerBehavior to be used by interface members
    void Init(GameObject player, Rigidbody2D rb, PlayerBehavior pScript);

    //The movement style the player has in given form
    void PlayerMovement();
}

public class INormalForm : IPlayerForms
{
    GameObject player;
    PlayerBehavior pScript;
    Rigidbody2D rb;

    public void Init(GameObject newPlayer, Rigidbody2D newRb, PlayerBehavior newPScript)
    {
        player = newPlayer;
        rb = newRb;
        pScript = newPScript;
    }

    public void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pScript.SetForm(1);
            return;
        }
        
        Vector2 moveVelocity = Vector2.zero;

        //Left, right, and jump
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity += pScript.moveSpeed * Vector2.left;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity += pScript.moveSpeed * Vector2.right;
        }

        //Debug.Log(player);
        moveVelocity.y = rb.velocity.y;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Physics2D.Raycast(player.transform.position, Vector2.down, pScript.groundRaycastDist, pScript.groundLayer))
            {
                //Raycast towards ground
                moveVelocity.y += pScript.jumpSpeed;
            }
        }

        //Debug.Log(moveVelocity);
        rb.velocity = moveVelocity;
    }
}

public class IGhostForm : IPlayerForms
{
    GameObject player;
    PlayerBehavior pScript;
    Rigidbody2D rb;

    public void Init(GameObject newPlayer, Rigidbody2D newRb, PlayerBehavior newPScript)
    {
        player = newPlayer;
        rb = newRb;
        pScript = newPScript;
    }

    public void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pScript.SetForm(0);
            return;
        }
        Vector2 moveVelocity = Vector2.zero;

        //Left, right, and jump
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity += pScript.moveSpeed * Vector2.left;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity += pScript.moveSpeed * Vector2.right;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveVelocity += pScript.moveSpeed * Vector2.up;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveVelocity += pScript.moveSpeed * Vector2.down;
        }

        //Debug.Log(moveVelocity);
        rb.velocity = moveVelocity;
    }
}
