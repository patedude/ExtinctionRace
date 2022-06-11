using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    void Start()
    {
        Button b = GetComponent<Button>();
        AudioSource audio = GetComponent<AudioSource>();
    }
}
