using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public GameObject playerobj;
    public GameObject gameover;
    public LayerMask WhatIsGround;
    float speed = 7f;
    float jumpforce = 7f;
    public int score = 0;
    public int coins = 0;
    public int highscore = 0;
    bool isgrounded = false;
    Rigidbody2D rb2d;
    public int milesecond;
    public int second;
    public int minites;
    public int hours;
    public TextMeshProUGUI mtext,stext,mitext,htext;


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
        milesecond++;
        mtext.text = milesecond.ToString();
        if(milesecond == 60)
        {
            second++;
            milesecond = 0;
            stext.text = second.ToString();
        }
        if (second == 60)
        {
            minites++;
            second = 0;
            mitext.text = minites.ToString();
        }
        if (minites == 60)
        {
            hours++;
            minites = 0;
            htext.text = hours.ToString();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag ("cure"))
        {
            score++;
            if (score >= highscore)
            {
                highscore = score;
                highscoresaver();
                highscoreloader();
            }
        }

        if (collision.collider.CompareTag("poison"))
        {
            Destroy(playerobj);
            highscoresaver();
            highscoreloader();
            gameover.SetActive(true);

        }
    }

    public void playagain()
    {
       string currentscene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentscene);
    }

    public void highscoresaver()
    { 
            savesystem.saveplayer(this);
    }

    public void highscoreloader()
    {
            playerdata data = savesystem.loadplayer();
            highscore = data.highscore;
            coins = data.score;
    }


}
