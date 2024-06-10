using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    [SerializeField] private float maxPos = 2.12f;
    [SerializeField] private  float carSpeed;
    private Vector3 position;
    [SerializeField] private uiManager ui;
    [SerializeField] private AudioManager audioObject;
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        
      audioObject.getCarSound().Play();
      position = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
       //position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
       //position.x = Mathf.Clamp(position.x, -maxPos, maxPos);
       //transform.position = position;
       accelometer();
       move();
       position = transform.position;
       position.x = Mathf.Clamp(position.x, -maxPos, maxPos);
       transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "EnemyCar")
        {
            gameObject.SetActive(false);
            ui.gameOverCheck();
            audioObject.getCarSound().Stop();
        }
    }
    
    private void accelometer()
    {
        float x = Input.acceleration.x;

        if (x<-0.1f)
        {
            moveLeft();
        }
        else if (x>0.1f)
        {
            moveRight();
        }
        else
        {
            resetVelocity();
        }
    }

    private void move()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float screenMiddle = Screen.width / 2;

            if (touch.position.x < screenMiddle && touch.phase == TouchPhase.Began)
            {
                moveLeft();
            }
            else if (touch.position.x > screenMiddle && touch.phase == TouchPhase.Began)
            {
                moveRight();
            }
            else
            {
                resetVelocity();
            }
            

        }
    }

    public void moveLeft()
    {
        rigidBody.velocity = new Vector2(-carSpeed, 0);
    }
    
    public void moveRight()
    {
        rigidBody.velocity = new Vector2(carSpeed, 0);
    }
    
    public void resetVelocity()
    {
        rigidBody.velocity = Vector2.zero;
    }
}
 