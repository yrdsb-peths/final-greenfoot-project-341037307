using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
  [SerializeField] public float speed = 10f;
  [SerializeField] public float jumpPower = 20f;

  private float jumpTimeCounter;
  private float jumpTimeMax = 0.4f;
  private bool isJumping;
  private float facing = 1; // pos = right, neg = left

  private bool isGrounded = false;
  public Transform feetPosition;
  public float checkRadius;
  public LayerMask whatIsGround;
  Rigidbody2D rb;
  // Dashing Variables
  private bool canDash = true;
  public bool isDashing;
  private float dashingPower = 16f;
  private float dashingTime = 0.2f;
  private float dashingCD = 2f;
  
  public Animator animator;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {

    // Control Variables
    if (isDashing || gameObject.GetComponent<PlayerCombat>().Stunned)
    {
      return;
    }

    // Get X movement and apply it
    float xMovement = Input.GetAxisRaw("Horizontal") * speed;
    rb.velocity = new Vector2(xMovement, rb.velocity.y);
    animator.SetFloat("Speed", Mathf.Abs(xMovement));

    // Flip character
    if (xMovement > 0)
    {
      transform.eulerAngles = new Vector3(0,0,0);
      facing = 1;
    } 
    else if (xMovement < 0){
      transform.eulerAngles = new Vector3(0,180,0);
      facing = -1;
    }

    // Jumping
    // Check if grounded
    isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);
    //Debug.Log(isGrounded);

    if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
    {
      rb.velocity = new Vector2 (rb.velocity.x, jumpPower);
      isJumping = true;
      jumpTimeCounter = jumpTimeMax;

      animator.SetBool("IsJumping", true);
    }
    else if (isGrounded == true && isJumping == false)
    {
      animator.SetBool("IsJumping", false);
    }

    if (Input.GetKey(KeyCode.Space) && isJumping == true){
      if (jumpTimeCounter > 0)
      {
        rb.velocity = new Vector2 (rb.velocity.x, jumpPower);
        jumpTimeCounter -= Time.deltaTime;
      }
      else
      {
        isJumping = false;
      }
    }
    if (Input.GetKeyUp(KeyCode.Space))
    {
      isJumping = false;
    }
    // Call dash
    if (Input.GetKeyDown(KeyCode.Q) && canDash)
    {
      StartCoroutine(Dash());
    }

  }

  // Causes player to dash based on coroutuine
  private IEnumerator Dash()
  {
    animator.SetBool("IsDashing", true);
    canDash = false;
    isDashing = true;
    float originalGravity  = rb.gravityScale;
    rb.gravityScale = 0f;
    

    rb.velocity = new Vector2(transform.localScale.x * dashingPower * facing, 0f);

    yield return new WaitForSeconds(dashingTime);
    rb.gravityScale = originalGravity;
    isDashing = false;
    animator.SetBool("IsDashing", false);
    yield return new WaitForSeconds(dashingCD);
    canDash = true;
  }
  public void OnLanding()
  {
    animator.SetBool("IsJumping", false);
  }
}

