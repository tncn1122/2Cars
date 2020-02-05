using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCollider : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("O"))
        {
            FindObjectOfType<GameController>().DesScore();
        }
        else if (collision.CompareTag("X"))
        {
            Destroy(collision.gameObject);
        }
    }
}
