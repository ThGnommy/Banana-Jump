using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D myBody;
    private bool initialPush;
    private int pushCount;
    private bool isDead;

    public float movementSpeed = 2f;
    public float normalPush = 10f;
    public float extraPush = 14f;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
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

            GameManager.instance.RestartGame();
        }
    }
}
