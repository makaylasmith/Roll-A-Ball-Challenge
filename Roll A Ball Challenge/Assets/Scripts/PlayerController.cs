using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText; 
    public Text winText;
    public Text scoreText;
    public Text livesText; 
    public Text GameOver;

    private Rigidbody rb;
    private int count;
    private int score;
    private int lives; 
    private int gotYellow;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gotYellow = 0;
        count = 0;
        score = 0;
        lives = 3; 
        SetCountText(); 
        winText.text = "";
        GameOver.text = "";
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            gotYellow = gotYellow + 1;
            count = count + 1;
            score = score + 1;
            SetCountText(); 
        }
        else if (other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score - 1;
            lives = lives - 1;
            SetCountText(); 
        }
        
        if (lives == 0)
        {
            Destroy(this);
            Destroy(gameObject);
            GameOver.text = "GAME OVER";
        }

        if ( gotYellow == 12) // only transfers to new field if all yellow cubes picked up
        {
            transform.position = new Vector3(69.17f,0.5f, 3.0f);
        }
    }

    void SetCountText()  
    {
        countText.text = "Count: " + count.ToString();
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
        if (gotYellow >= 20) // can still win if all yellow cubes are picked up, even if red also picked up
        {
            winText.text = "You Win!";
            Destroy(this); //deactivates the player so they can't then get a game over
        }
    }
}
