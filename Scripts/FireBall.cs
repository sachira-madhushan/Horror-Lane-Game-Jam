using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float oldPositon;
    [SerializeField]private SpriteRenderer sr;
    void Start()
    {
        oldPositon = transform.position.x;
    }
    private void FixedUpdate()
    {
        
        transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y);

        
        if (transform.position.x > oldPositon+10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Spell")
        {
            Destroy(collision.gameObject);
            }
    }
}
