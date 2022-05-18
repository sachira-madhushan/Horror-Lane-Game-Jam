using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject  RightSpellPosition, LeftSpellPosition, leftSpell,rightSpell,player,healthBar,point;
    [SerializeField] private SpriteRenderer rendere,healthBarRenderer;
    [SerializeField]private Rigidbody2D rigi;
    [SerializeField] private Animator enemyAnimation;
    [SerializeField] private AudioSource dieSound;
    private float maxTime = 200, distance;
    private float currentTime = 0,health=3,time=0;
    public bool enemyActive=false,start=false;
    void Start()
    {

        healthBarRenderer =healthBar.GetComponent<SpriteRenderer>();

    }

 
    void FixedUpdate()
    {

        if (start)
        {
            time++;
        }
        healthBarRenderer.size = new Vector2((int)health, 0.2f);
        distance = player.transform.position.x - transform.position.x;
        if (distance > 0)
        {
            rendere.flipX = false;
        }
        else
        {
            rendere.flipX = true;
            
        }
        if (Mathf.Abs(distance)<12)
        {
            currentTime++;
            if (currentTime == maxTime)
            {
                Attack();
                currentTime = 0;
            }
            if (currentTime == 100)
            {
                Jump();
                Attack();
            }
            if (currentTime == 150)
            {
                Attack();
            }
        }

        if (healthBarRenderer.size.x == 0)
        {

            enemyAnimation.SetBool("die", true);
            start = true;
        }

        if (time > 90)
        {
            Instantiate(point, transform.position, Quaternion.identity);
            Die();
        }

    }

    void Attack()
    {
        if (rendere.flipX == true)
        {
            enemyAnimation.SetTrigger("attack");
            Instantiate(leftSpell, LeftSpellPosition.transform.position, Quaternion.identity);
        }
        else
        {
            enemyAnimation.SetTrigger("attack");
            Instantiate(rightSpell, RightSpellPosition.transform.position, Quaternion.identity);
        }
        
    }
    void Jump()
    {
        enemyAnimation.SetTrigger("jump");
        rigi.velocity = Vector2.up * 7f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fire")
        {
            health -= 0.2f;
            Destroy(collision.gameObject);
        }
    }

    void Die()
    {
        dieSound.Play();
        Destroy(this.gameObject);
        
    }


}
