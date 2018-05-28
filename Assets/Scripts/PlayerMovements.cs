using UnityEngine;
using System.Collections;

public class PlayerMovements : MonoBehaviour {

    public float playerSpeed, jumpSpeed;
    GameObject planet;
    RotationScript rotationScript;
    Rigidbody2D rb2d;
    bool canJump;

    void Start()
    {
        canJump = true;
        //playerSpeed = 5f;
        //jumpSpeed = 25f;
        planet = ((Gravity) this.GetComponent("Gravity")).planet;
        rotationScript = (RotationScript) planet.GetComponent("RotationScript");
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //////Horizontal movement////
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");
        rotationScript.speed = moveHorizontal == 0 ? 0 : rotationScript.speed + moveHorizontal * playerSpeed;
        //rotationScript.speed += moveHorizontal * playerSpeed;

        ////Vertical Movement////
        //Store the current vertical input in the float moveVertical.
        //float moveVertical = Input.GetAxis("Vertical");
        //Use the two store floats to create a new Vector2 variable movement.
        //Vector2 movement = new Vector2(0f, moveVertical * 10f);
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        //rb2d.AddForce(movement * playerSpeed * 9.8f);

        bool jump = Input.GetButtonDown("Jump");
        if (canJump && jump)
        {
            canJump = false;
            rb2d.AddForce(Vector2.up * jumpSpeed * 9.8f);
        }
        

    }

    void Update()
    {
        //Vector3 playerPosition = transform.position;
        //this.transform.position = new Vector3(0f, playerPosition.y, playerPosition.z);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider == planet.GetComponent<Collider2D>())
            canJump = true;
    }
        
}
