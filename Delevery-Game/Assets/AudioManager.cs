using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update 
    public AudioSource pickupSound;
    public AudioSource dropdownsound; 

    public void PlayPickUP()
    {
        pickupSound.Play();
    }

    public void playdropdown()
    {
        dropdownsound.Play();   
    }


}
