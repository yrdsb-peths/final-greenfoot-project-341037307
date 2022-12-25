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

  private bool isGrounded = false;
  public Transform feetPosition;
  public float checkRadius;
  public LayerMask whatIsGround;
  Rigidbody2D rb;


  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    float xMovement = Input.GetAxis("Horizontal") * speed;
    rb.velocity = new Vector2(xMovement, rb.velocity.y);

    // Flip character
    if (xMovement > 0)
    {
      transform.eulerAngles = new Vector3(0,0,0);
    } 
    else if (xMovement < 0){
      transform.eulerAngles = new Vector3(0,180,0);
    }

    // Check if grounded
    isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);
    //Debug.Log(isGrounded);

    if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
    {
      rb.velocity = new Vector2 (rb.velocity.x, jumpPower);
      isJumping = true;
      jumpTimeCounter = jumpTimeMax;
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
    
  }
}
