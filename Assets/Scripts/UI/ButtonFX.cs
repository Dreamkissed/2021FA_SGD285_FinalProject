using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip hoverFX;
    public AudioClip selectFX;

    public void Hover()
    {
        myFX.PlayOneShot(hoverFX);
    }

    public void Click()
    {
        myFX.PlayOneShot(selectFX);
    }
}
