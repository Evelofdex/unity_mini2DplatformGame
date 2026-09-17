using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class dash_skill : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] float dashForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //
        dashForce = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);   
            Debug.Log("dashign");
        }
        if(Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);   
            Debug.Log("dashign");
        }
    }
}
