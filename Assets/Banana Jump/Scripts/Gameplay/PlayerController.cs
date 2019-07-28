using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D myBody;
    private bool initialPush;
    private int pushCount;
    private bool isDead;

    public float movementSpeed = 2f;
    public float normalPush = 10f;
    public float extraPush = 14f;

    public Button leftButton, rightButton;

    public RestartButton restartButton;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {

    }

    void Move()
    {
        if (isDead)
            return;

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            myBody.velocity = new Vector2(movementSpeed, myBody.velocity.y);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            myBody.velocity = new Vector2(-movementSpeed, myBody.velocity.y);
        }
    }

    public void TouchLeft()
    {
        if (isDead)
            return;

        myBody.velocity = new Vector2(-movementSpeed, myBody.velocity.y);
    }

    public void TouchRight()
    {
        if (isDead)
            return;

        myBody.velocity = new Vector2(movementSpeed, myBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead)
            return;

        if (collision.tag == "ExtraPush")
        {
            if(!initialPush)
            {
                initialPush = true;
                myBody.velocity = new Vector2(myBody.velocity.x, 18f);
                collision.gameObject.SetActive(false);

                // Play Sound

                return;
            }
        }

        if(collision.tag == "NormalPush")
        {
            myBody.velocity = new Vector2(myBody.velocity.x, normalPush);
            collision.gameObject.SetActive(false);

            pushCount++;
            // Play Sound
        }

        if (collision.tag == "ExtraPush")
        {
            myBody.velocity = new Vector2(myBody.velocity.x, extraPush);
            collision.gameObject.SetActive(false);

            pushCount++;

            // Play Sound
        }

        if(pushCount == 2)
        {
            pushCount = 0;
            PlatformSpawner.instance.SpawnPlatforms();
        }

        if(collision.tag == "FallDown" || collision.tag == "Bird")
        {
            isDead = true;

            //Play Sound

            restartButton.ShowRestart();
        }
    }
}
