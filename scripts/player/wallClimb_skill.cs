using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallClimb_skill : MonoBehaviour
{
    public bool isOnWall;

    private GameObject wall;   
    private BoxCollider2D wallCollider;
    private PhysicsMaterial2D phys;

    [SerializeField] private float wallFriction;

    void Start()
    {
        wall = GameObject.FindGameObjectWithTag("Wall");
        wallCollider = wall.GetComponent<BoxCollider2D>();
        phys = wallCollider.sharedMaterial;
        isOnWall = false;

        //
        wallFriction = 0.148f;
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
}
