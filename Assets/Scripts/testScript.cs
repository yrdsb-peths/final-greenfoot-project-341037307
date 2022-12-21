using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
  [SerializeField] float speed = -1f;
  [SerializeField] float jumpPower = -1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      float xMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
      float yMovement = Input.GetAxis("Vertical") * jumpPower * Time.deltaTime;
      gameObject.transform.Translate(xMovement,0, 0);
      if (Input.GetKey(KeyCode.Space))
      {
        //gameObject.transform.Translate(0,30f * Time.deltaTime,0);
      }
    }
}
