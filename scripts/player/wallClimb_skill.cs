using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallClimb_skill : MonoBehaviour
{
    public bool isJumpFromWall;

    private bool isOnWall;
    private bool onRightWall;
    private bool onLeftWall;

    //jump stuff
    [SerializeField] private float jumpForceX;
    [SerializeField] private float jumpForceY;
    [SerializeField] private float jumpWallDuration;

    private GameObject wall;   
    private BoxCollider2D wallCollider;
    private PhysicsMaterial2D phys;

    private float wallFriction = 0.148f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        wall = GameObject.FindGameObjectWithTag("Wall");
        wallCollider = wall.GetComponent<BoxCollider2D>();
        phys = wallCollider.sharedMaterial;
        
        isOnWall = false;
        onRightWall = false;
        onLeftWall = false;
        isJumpFromWall = false;

        //
        jumpWallDuration = 0.3f;
        jumpForceX = 8f;
        jumpForceY = 8f;
    }

    void Update()
    {
        onRightWall = (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Space) && isOnWall) ? true : false;
        onLeftWall = (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Space) && isOnWall) ? true : false;

        if (onRightWall)
        {
            isJumpFromWall = true;
            StartCoroutine(wallJump(-1, jumpForceX, jumpForceY, jumpWallDuration));
            // Debug.Log("jump on right side");
        }

        if (onLeftWall)
        {
            isJumpFromWall = true;
            StartCoroutine(wallJump(1, jumpForceX, jumpForceY, jumpWallDuration));
            // Debug.Log("jump on left side");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            phys.friction = wallFriction;
            wallCollider.sharedMaterial = phys;
            isOnWall = true;
            // Debug.Log("holding wall");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            phys.friction = 0f;
            wallCollider.sharedMaterial = phys;
            isOnWall = false;
            // Debug.Log("released wall");
        }
    }

    IEnumerator wallJump(float direction, float forceX, float forceY, float duration)
    {
        rb.AddForce(new Vector2(direction * forceX, forceY), ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        isJumpFromWall = false;
    }
}
