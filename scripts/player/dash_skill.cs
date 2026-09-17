using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class dash_skill : MonoBehaviour
{
    public bool isDashing;
    [SerializeField] private float dashDuration;
    private float dashCooldownDuration = 1f;
    private bool isCooldown_dash;

    private Rigidbody2D rb;

    [SerializeField] float dashForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isCooldown_dash = false;

        //
        dashForce = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.A) && !isCooldown_dash)
        {
            StartCoroutine(dashLeft());
            StartCoroutine(dashCooldown(dashCooldownDuration));
        }
        if(Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.D) && !isCooldown_dash)
        {
           StartCoroutine(dashRight());
           StartCoroutine(dashCooldown(dashCooldownDuration));
        }
    }

    IEnumerator dashLeft()
    {
        rb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
        Debug.Log("dashing");
        isDashing = true;   
        yield return new WaitForSeconds(0.5f);
        isDashing = false;  
        isCooldown_dash = true;
    }
    IEnumerator dashRight()
    {
        rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
        Debug.Log("dashing");
        isDashing = true;
        yield return new WaitForSeconds(0.5f);
        isDashing = false;
        isCooldown_dash = true;
    }

    IEnumerator dashCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        isCooldown_dash = false;
    }
}
