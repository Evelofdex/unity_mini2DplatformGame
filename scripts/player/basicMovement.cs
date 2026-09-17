using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMovement : MonoBehaviour
{

    private Rigidbody2D rb;
   

    [SerializeField] private float spd;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //
        spd = 5f;
  
    }


    void FixedUpdate()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.A)) direction += Vector2.left;
        if (Input.GetKey(KeyCode.D)) direction += Vector2.right;
        Vector2 moveDirection = new Vector2(direction.x * spd, rb.velocity.y);
        //fall Multiplier
        

        rb.velocity = moveDirection;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
