using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private float directionX = 0f;

    //dash variable for trail renderer
    private TrailRenderer _trailRenderer;


    //dashing variables
    [Header("Dashing")]
    [SerializeField] private float _dashingVelocity = 19f;
    [SerializeField] private float _dashingTime = 0.5f;
    private Vector2 _dashingDir;
    private bool _isDashing;
    private bool _canDash;

    //end of dashing
    //movement vaiables 
    private BoxCollider2D coll;
    [SerializeField] private float moveSpeed = 9f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private float runForce = 16f;

    //dashing trail renders
    [SerializeField] private TrailRenderer tr;

    //run variables
    private bool run = false;

    [SerializeField]
    private LayerMask jumpableGround;
    //movement states
    private enum MovemnetState { idle, running, jumping, falling }

    //jump sound effect
    [SerializeField] private AudioSource jumpSoundEffect;
   
    
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        // Get the players input on the horizontal axis
        directionX = Input.GetAxisRaw("Horizontal");

        //dash button
        var dashInput = Input.GetButtonDown("Dash");

        // add velocity to the player times movoement speed so that the player can move left and right
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
        
        //jump add velocity to the player using a vector 2D 
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }
        //run if run button is held down run variable is true
        if(Input.GetButtonDown("Fire1"))
        {
            run = true;
        }
        //if run button is left the run variable is false
        if(Input.GetButtonUp("Fire1"))
        {
            run = false;
        }
        //if run is true. run variable is changed to a higher speed
        if(run == true)
        {
            moveSpeed = runForce;
            
        }
        // if run vaiable is false it is set back to its normal speed
        else if(run == false)
        {
            moveSpeed = 9f;
        }
        

        //start of dashing code
        if (dashInput && _canDash)
        {
            _isDashing = true;
            _canDash = false;
            _trailRenderer.emitting = true;
            //_dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if(_dashingDir == Vector2.zero)
            {
                _dashingDir = new Vector2(transform.localScale.x, 0);
            }
            StartCoroutine(stopDashing());
        }

        
        //check if the player is dashing. add velocity to the player
        if(_isDashing)
        {
            rb.velocity = _dashingDir.normalized * _dashingVelocity;
            return;
        }
        //chack if the player is touching the ground
        if(IsGrounded())
        {
            _canDash = true;
        }
        
       

       UpdateAnimationState();
    }

    
    //Check player movement states. If veloticity is add to the player in a direction the animations should face that direction
    private void UpdateAnimationState()
    {
        
        MovemnetState state;
        
        //check players moving direction and flip the sprite is it changes.
         if (directionX > 0f)
        {
            state = MovemnetState.running;
            sprite.flipX = false;
        }
        else if(directionX < 0f)
        {
            state = MovemnetState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovemnetState.idle;
        }
        //check if player is jumping by looking at is velocity and change animation to jumping
        if (rb.velocity.y > .1f)
        {
            state = MovemnetState.jumping;
        }
        //if jumping velocity goes to less than .1f speed change animation to falling
        else if (rb.velocity.y < -.1f)
        {
            state = MovemnetState.falling;
        }

        anim.SetInteger("state", (int)state);

        
    }

    //Check if the player is touching the ground. So that player can not jump if not touching the ground
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

private IEnumerator stopDashing()
    {
        //ends the dash and stops the trail render
        yield return new WaitForSeconds(_dashingTime);
        _trailRenderer.emitting = false;
        _isDashing = false;
    }
    
}
