using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject playerobj;
    public LayerMask WhatIsGround;
    float speed = 7f;
    float jumpforce = 7f;
    public int score = 0;
    public int highscore = 0;
    bool isgrounded = false;
    Rigidbody2D rb2d;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        highscoreloader();
    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics2D.Raycast(transform.position, Vector3.down, 1,WhatIsGround);

        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(Vector2.left * speed, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(Vector2.right * speed, ForceMode2D.Force);
        }
        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpforce);
        }
        if(Input.GetButtonUp("Jump") && rb2d.velocity.y > 0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cure")
        {
            score++;
            if(score >= highscore)
            {
                highscore = score;
                highscoresaver();
                highscoreloader();
            }
        }

        if (collision.gameObject.tag == "poison")
        {
            Destroy(playerobj);
        }


    }

    public void highscoresaver()
    { 
            savesystem.saveplayer(this);
    }

    public void highscoreloader()
    {
            playerdata data = savesystem.loadplayer();
            highscore = data.highscore;
    }


}
