using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance; // Toisista scripteistä pääsee controlleriin

    public Text scoreText;

    public GameObject StartGame; // Pelin alussa on teksti
    public GameObject JumpButton;
    public static int value; // Palkin arvo
    public Slider progressSlider; // Palkki

    public GameObject SpeedButton;

    void Awake()
    {
        value = 0; // Lähtöarvo palkille on 0
        Time.timeScale = 0f; // Peli ei ala heti
        if (instance == null)
        { 
            instance = this;
        }
        else if (instance != this)
        { 
            Destroy(gameObject);
        }
    }

    void Update()
    {
        progressSlider.value = value; // Palkkiin (slideriin) arvo

        if (Input.touchCount > 0) //Kun täppää jostain, peli alkaa /*if (Input.GetMouseButtonDown(0))*/
        {
            Touch touch = Input.GetTouch(0);

            StartGame.SetActive(false); // Aloitusteksti menee pois näkyvistä
            JumpButton.SetActive(true); // Jump-button näkyviin
            Time.timeScale = 1f;
        }
        // Kun kaikki omenat kerätty
        if (value >= 10)
        {
            Sprint();
        }
    }

    public void Sprint()
    {
        SpeedButton.SetActive(true);
    }

    public void DinoScored()
    {
        // Arvo päivittyy
        value = value + 1;
    }

    public void SpeedPoint()
    {
        value= value - 1;
    }
}