/**
 * ... This script is used to allow the movement of the player character. ...
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Animator ac;  //!< The creation of the variables required for animation
    private Rigidbody2D rb;  //!< The creation of variables for movement
    private bool isJumping = false;
    float DirectionMove = 0f;
    float UporDown = 0f;
    private Vector2 m_Velocity = Vector2.zero;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private bool m_FacingRight = true;
    [SerializeField] private LayerMask ground;  //!< Allows the layermasks to be used when checking for ground
    private bool grounded;
    public AnimatorController Walk; //!< The creation of the variables used to change the animation controller
    public AnimatorController Idle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ac = GetComponent<Animator>();
        ground = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        DirectionMove = Input.GetAxisRaw("Horizontal");  //!< Getting the raw axis for movement
        UporDown = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(rb.position,0.2f,ground);  //!< Checking for ground layer objects
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                isJumping = false;
            }
        }

        if (UporDown > 0 && grounded && !isJumping)  //!< Allowing jumping if the player is grounded and not already jumping
        {
            rb.AddForce(new Vector2(0f, 300f));
            isJumping = true;
        }

        Movement();

        if (DirectionMove > 0 && !m_FacingRight)  //!< Flips the player depending on direction of movement
        {
            FlipCharacter();
        }
        else if (DirectionMove < 0 && m_FacingRight)
        {
            FlipCharacter();
        }
    }
    private void FlipCharacter()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Movement()  //!< Changing the animation of movement and actually moving the character using velocity of the rigidbody.
    {
        Vector3 targetVelocity = new Vector2(((DirectionMove * Time.fixedDeltaTime) * 350f), rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        if (DirectionMove != 0f)
        {
            ac.runtimeAnimatorController = Walk;
        }
        else
        {
            ac.runtimeAnimatorController = Idle;
        }
    }
}
