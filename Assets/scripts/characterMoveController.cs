using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMoveController : MonoBehaviour
{
    [Header("movement")]
    public float moveAccel;

    public float MaxSpeed;

    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector2 velocityVector = rig.velocity;
        velocityVector.x = Mathf.Clamp(velocityVector.x + moveAccel * Time.deltaTime,
           0.0f, MaxSpeed);
        rig.velocity = velocityVector;
    }
    

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
