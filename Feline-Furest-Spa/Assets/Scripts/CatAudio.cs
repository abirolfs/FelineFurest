using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAudio : MonoBehaviour
{

    AudioSource meow;

    // Start is called before the first frame update
    void Start()
    {
        meow = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playMeow()
    {
        meow.Play();
    }
}
