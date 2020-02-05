using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    public int moveSpeed;
    public float minX;
    public float maxX;
    public bool isLeftCar;
    private Vector2 direction;
    private Vector3 currentPos;
    private int angleDirection;
    private bool isMoving;
    private Touch touch;
    float CalX(float x)
    {
        int Base = 1;
        if (x > 0)
            Base = -1;
        return -15*(x + (2.7F * Base)) * (x + (2.7F * Base))+27.3375f;
    }


    // Start is called before the first frame update
    void Start()
    {
        if (isLeftCar)
        {
            direction = Vector2.left;
            angleDirection = 1;
        }
        else
        {
            direction = Vector2.right;
            angleDirection = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isMoving && Input.GetMouseButtonDown(0))
        if (!isMoving && Input.touchCount > 0)
        {
            //if (Input.mousePosition.x < Screen.width / 2)
            touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                if (isLeftCar) isMoving = true;
            }
            else
                if (!isLeftCar) isMoving = true;


            if (isMoving)
            {
                if (direction == Vector2.right)
                {
                    direction = Vector2.left;
                }
                else if (direction == Vector2.left)
                    direction = Vector2.right;
                angleDirection *= -1;
            }
        }
        if (isMoving)
        {
            transform.Translate(moveSpeed * Time.deltaTime * direction, Space.World);
            if (transform.position.x <= minX || transform.position.x >= maxX)
                isMoving = false;
            currentPos = transform.position;
            currentPos.x = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = currentPos;
            transform.eulerAngles = Vector3.forward * (CalX(transform.position.x)) * (angleDirection);
        }
        // 4.05 - 1.35
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("O"))
        {
            FindObjectOfType<GameController>().AddScore();
            FindObjectOfType<GameController>().CalcSpeed();
            FindObjectOfType<GameController>().CalcSpawn();
            Destroy(collision.gameObject);
            
        }
        else if (collision.CompareTag("X"))
        {
            FindObjectOfType<GameController>().DesScore();
            Destroy(collision.gameObject);
        }
    }
}
