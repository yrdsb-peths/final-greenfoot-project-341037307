using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
  [SerializeField] public float speed = -1f;
  [SerializeField] public float jumpPower = -1f;

  float maxJumpHold = 2f;
  float currentJump = 0f;
  bool jumpCD = false;

  private bool isGrounded = false;
  public Transform feetPosition;
  public float checkRadius;
  public LayerMask whatIsGround;

  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    float xMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    //float yMovement = Input.GetAxis("Vertical") * jumpPower * Time.deltaTime;
    gameObject.transform.Translate(xMovement,0, 0);

    // Check if grounded
    isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);
    //Debug.Log(isGrounded);
    if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
    {
      Debug.Log("Jump");
      if (currentJump < maxJumpHold)
      {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpPower;
        //currentJump += 1f * Time.deltaTime;
      }
    }
    
  }
}
