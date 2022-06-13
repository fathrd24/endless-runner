using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMoveController : MonoBehaviour
{
    [Header("movement")]
    public float moveAccel;

    public float MaxSpeed;



    private Rigidbody2D rig;
    [Header("jump")]

    public float jumpAccel;
    private bool isjumping;
    private bool isOnGround;

    [Header("Ground Raycast")]

    public float groundRaycastDistance;
    public LayerMask groundLayerMask;
    private void FixedUpdate()
    {
        Vector2 velocityVector = rig.velocity;
        velocityVector.x = Mathf.Clamp(velocityVector.x + moveAccel * Time.deltaTime,
           0.0f, MaxSpeed);
        rig.velocity = velocityVector;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundRaycastDistance, groundLayerMask);

        if(hit)
        {
            if(!isOnGround && rig.velocity.y <= 0)
            {
                isOnGround = true;
            }
        }
        else
        {
            isOnGround = false;
        }
       Vector2 veloCityVector = rig.velocity;
        if(isjumping)
        { velocityVector.y += jumpAccel;
            isjumping = false;
        }
        velocityVector.x = Mathf.Clamp(velocityVector.x + moveAccel * Time.deltaTime,
            0.0f, MaxSpeed);
        rig.velocity = velocityVector;
    }

    private Animator anim;
    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position + (Vector3.down * groundRaycastDistance), Color.white);
    }



    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(isOnGround)
            {
                isjumping = true;
            }
        }
        anim.SetBool("isOnGround", isOnGround);
        
    }
}
