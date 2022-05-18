using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimation;
    [SerializeField]
    private SpriteRenderer playerRenderer;
    [SerializeField] private GameObject leftFirePosition,rightFirePosition, fireBall, leftFireBall,lostWindow,winGirl,winWindow;
    public GameObject leftBlock,rightBlock;
    [SerializeField] private Image healthBar,pointBar;
    private Rigidbody2D playerRigi;
    private int _jumpCount = 0;

    [SerializeField] private AudioSource attackSound, jumpSound,coinSound;
    float time = 0;
    bool start=false,isBlockEnabled=false;


    void Start()
    {

        playerRigi = GetComponent<Rigidbody2D>();
        lostWindow.SetActive(false);
        pointBar.fillAmount = 0;
        winWindow.SetActive(false);
    }

    void FixedUpdate()
    {
        if (pointBar.fillAmount == 1)
        {
            winGirl.transform.position = new Vector3(121, -3.3f);
        }
        if (start)
        {
            time++;
        }
        if (time > 100)
        {
            ShowLostMenu();
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            if (playerAnimation.GetBool("block"))
            {
                isBlockEnabled = false;
                playerAnimation.SetBool("block", false);
                leftBlock.SetActive(false);
                rightBlock.SetActive(false);    

            }
            if (playerRenderer.flipX == true)
            {
                playerRenderer.flipX = false;
            }
            Walking(3f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (playerAnimation.GetBool("block"))
            {
                isBlockEnabled=false;
                playerAnimation.SetBool("block", false);
                leftBlock.SetActive(false);
                rightBlock.SetActive(false);

            }
            if (playerRenderer.flipX == false)
            {
                playerRenderer.flipX = true;
            }

            Walking(-3f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            isBlockEnabled = true;
            Block();
        }
        if (Input.GetMouseButtonDown(0) && !isBlockEnabled)
        {

            Attack();
        }
        if (Input.GetKeyDown(KeyCode.W) && _jumpCount<2)
        {

            Jump();
            _jumpCount++;
        }
        
        if (healthBar.fillAmount < 0.1)
        {
            playerAnimation.SetBool("die", true);
            start=true;

        }
        
    }

    void Walking(float direction)
    {
        playerAnimation.SetTrigger("walking");
        transform.position = transform.position + (new Vector3(direction*Time.deltaTime, 0));
    }

    void Jump()
    {
        jumpSound.Play();
        playerAnimation.SetTrigger("jump");
        playerRigi.velocity = Vector2.up * 7f;
    }
    void Attack()
    {
        playerAnimation.SetTrigger("attack");
        if (playerRenderer.flipX == true)
        {
            attackSound.Play();
            Instantiate(leftFireBall, leftFirePosition.transform.position, Quaternion.identity);

        }
        else
        {
            attackSound.Play();
            Instantiate(fireBall, rightFirePosition.transform.position, Quaternion.identity);
        }
        
    }
    void Block()
    {
        if (playerRenderer.flipX == true)
        {
            leftBlock.SetActive(true);
            
        }
        else
        {
            rightBlock.SetActive(true);
        }

        playerAnimation.SetBool("block", true);
    }

    public bool checkFlip()
    {
        return playerRenderer.flipX;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Spell")
        {
            Destroy(collision.gameObject);
            healthBar.fillAmount -= 0.05f;
        }
        if(collision.gameObject.tag == "point")
        {
            coinSound.Play();
            pointBar.fillAmount += 0.1f;
            Destroy(collision.gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Win")
        {
            winWindow.SetActive(true);
            Time.timeScale = 0;
        }
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Balcony")
        {
            _jumpCount = 0;
        }
    }



    void ShowLostMenu()
    {
        lostWindow.SetActive(true);
        Time.timeScale = 0;
    }



 
}
