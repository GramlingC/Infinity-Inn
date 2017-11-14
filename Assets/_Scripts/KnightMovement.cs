using UnityEngine;

public class KnightMovement : MonoBehaviour {

    public float moveSpeed; //Set movespeed, how many pixels every update

    public bool isWalking; //checks to see if currently walking

    public float waitTime; //Adjustable amount of time spent waiting
    private float waitCounter; //counter that goes down until waitTime is over

    public float walkTime; //Adjustable amount of time spent walking
    private float walkCounter; //counter that goes down until walkTime is over

    private int direction; //Integer representing left or right for a direction

    private Rigidbody2D myRigidBody; //to get component

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime; //start counters at set time
        walkCounter = walkTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime; //decrements counter over time

            switch(direction) //looks at direction, and then chooses where to go
            {
                case 0:
                    myRigidBody.velocity = new Vector2(-moveSpeed, 0);
                    break;

                case 1:
                    myRigidBody.velocity = new Vector2(moveSpeed, 0);
                    break;
            }

            if (walkCounter < 0) //once walkcounter is over, stop walking and start waiting
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else //when not walking
        {
            waitCounter -= Time.deltaTime; //decrement wait time

            if (waitCounter < 0) //once done waiting, choose a new(or same, random) direction
            {
                ChooseDirection();
            }
        }
		
	}

    void ChooseDirection() //function to choose direction, start walking and start a new timer
    {
        direction = Random.Range(0, 2);
        isWalking = true;
        walkCounter = walkTime;

    }
}
