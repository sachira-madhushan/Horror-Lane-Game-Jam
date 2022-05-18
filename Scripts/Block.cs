using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{

    [SerializeField] private Image _healthBar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spell")
        {
            print("spell collided block");
            Destroy(collision.gameObject);
            _healthBar.fillAmount += 0.05f;
        }
    }
}
