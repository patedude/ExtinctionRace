using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public int startingHealth = 100;                           
    public int currentHealth;                                
    public Slider healthSlider;

    void Awake()
    {
        currentHealth = startingHealth;
    }
}