using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class dash_skill : MonoBehaviour
{
    public bool isDashing;
    private float dashDuration = 0.3f;
    private float dashCooldownDuration = 3f;
    private bool isCooldown_dash;

    private Rigidbody2D rb;

    float dashForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isCooldown_dash = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.A) && !isCooldown_dash)
        {
            StartCoroutine(dashLeft(dashDuration));
            StartCoroutine(dashCooldown(dashCooldownDuration));
        }
        if(Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.D) && !isCooldown_dash)
        {
           StartCoroutine(dashRight(dashDuration));
           StartCoroutine(dashCooldown(dashCooldownDuration));
        }
    }

    IEnumerator dashLeft(float duration)
    {
        rb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
        // Debug.Log("dashing");
        isDashing = true;   
        yield return new WaitForSeconds(duration);
        isDashing = false;  
        isCooldown_dash = true;
    }
    IEnumerator dashRight(float duration)
    {
        rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
        // Debug.Log("dashing");
        isDashing = true;
        yield return new WaitForSeconds(duration);
        isDashing = false;
        isCooldown_dash = true;
    }

    IEnumerator dashCooldown(float cooldown)
    {
        Debug.Log("dash cooldown");
        yield return new WaitForSeconds(cooldown);
        isCooldown_dash = false;
        Debug.Log("dash cooldown ended");
    }
}
