using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class basicMovement : MonoBehaviour
{

    private Rigidbody2D rb;
   

    [SerializeField] private float spd = 6f;
    //jump mechanics
    [SerializeField] private float jumpForce;
    private bool isGrounded = true;
    [SerializeField] private float fallMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //
        jumpForce = 5f;
        fallMultiplier = 2f;
    }


    void FixedUpdate()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.A)) direction += Vector2.left;
        if (Input.GetKey(KeyCode.D)) direction += Vector2.right;
        Vector2 moveDirection = new Vector2(direction.x * spd, rb.velocity.y);
        //fall Multiplier
        if (!isGrounded && rb.velocity.y < 0)
        {
            rb.velocity = moveDirection + (Vector2.up *  (fallMultiplier * -1)); 
        }
        else
        {
            rb.velocity = moveDirection; 
        }
        Debug.Log(rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
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
