using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public float xOffset = 1f;
    public Transform target;
    private SpriteRenderer playerRender;

    private void Start()
    {
        
        playerRender =target.GetComponent<SpriteRenderer>();
    }
    void LateUpdate()
    {
        if (playerRender.flipX == true)
        {
            Vector3 newPos = new Vector3(target.position.x - xOffset, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
        
    }
}