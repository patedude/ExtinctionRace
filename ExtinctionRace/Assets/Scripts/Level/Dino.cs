using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Dino : MonoBehaviour
{
    private Animator anim; // Animaatio
    private Rigidbody2D rb2d; // Fysiikat

    public float jumpForce = 200f;
    private float dirX;
    public float runSpeed;

    private Vector3 localScale;

    // Panelit
    public GameObject gameFinished;
    public GameObject gameOver;

    public bool gameIsFinished = false;
    public bool gameIsOver = false;

    // Buttonit
    public GameObject SpeedButton;
    public GameObject JumpButton;

    void Start()
    {
        /* Komponentit */
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        localScale = transform.localScale;
        runSpeed = 5f;
    }

    private void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * runSpeed;

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            if (rb2d.velocity.y == 0) // Jos hahmo on maassa
            { 
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
            }
        }

        if (CrossPlatformInputManager.GetButtonDown("Run"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            GameController.instance.SpeedPoint();
        }
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        // Omenoiden keräys
        if (Collider.gameObject.CompareTag("Apple"))
        {
            Collider.gameObject.SetActive(false); // Jos omenaan osutaan, se poistetaan näkyvistä eli se ei ole sitten aktiivinen, eli se ei enää näy pelissä
            GameController.instance.DinoScored(); // Mitä tapahtuu kun omenaan osutaan, määritetään toisessa scriptissä
        }
        // Maalin pääsy
        else if (Collider.gameObject.CompareTag("Goal"))
        {
            gameFinished.SetActive(true);
            gameIsFinished = true;
            Buttons(); // Kutsutaan buttonien funktiota
        }
        // Esteet
        else if (Collider.gameObject.CompareTag("Spike"))
        {
            if (gameIsFinished == false) // Game over tulee vain jos peli ei ole jo loppunut
            {
                gameOver.SetActive(true);
                gameIsOver = true;
                Time.timeScale = 0f;
                Buttons();
            }
        }
    }

    public void Buttons()
    {
        if (gameFinished == true)
        {
            SpeedButton.SetActive(false);
            JumpButton.SetActive(false);
        }
        else if (gameIsOver == true)
        {
            SpeedButton.SetActive(false);
            JumpButton.SetActive(false);
        }
    }
}
