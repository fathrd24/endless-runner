using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveController : MonoBehaviour
{
    [Header("position")]
    public Transform player;
    public float horizontaloffset;

    private void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = player.position.x + horizontaloffset;
        transform.position = newPosition;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
}
    // Update is called once per frame
    