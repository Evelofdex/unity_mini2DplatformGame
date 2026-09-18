using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class basicMovement : MonoBehaviour
{
    //from wall mechanic
    private wallClimb_skill onWallStatus;

    //dash mechanic
    private dash_skill dashStatus;


    private Rigidbody2D rb;
   

    private float spd = 6f;
    //jump mechanics
    private float jumpForce = 8f;
    private bool isGrounded = true;
    private float fallMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        //wall mechanic thinsg
        onWallStatus = GetComponent<wallClimb_skill>();

        //dashing things
        dashStatus = GetComponent<dash_skill>();

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2.5f;

        fallMultiplier = 1f; //basically default, for now
        //
    }


    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);

        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.A)) direction += Vector2.left;
        if (Input.GetKey(KeyCode.D)) direction += Vector2.right;
        Vector2 moveDirection = new Vector2(direction.x * spd, rb.velocity.y);
        //fall Multiplier
        if (!isGrounded && rb.velocity.y < 0)
        {
            rb.velocity = moveDirection + (Vector2.up *  (fallMultiplier * -1)); 
        } 
        else if (dashStatus.isDashing || onWallStatus.isJumpFromWall)
        {
            rb.velocity = rb.velocity; // default
        } 
        else
        {
            rb.velocity = moveDirection; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        //wall ability exclusive
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            // Debug.Log("Ground Collision");
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            // Debug.Log("Ground Exit");
            isGrounded = false;
        }
    }
}
