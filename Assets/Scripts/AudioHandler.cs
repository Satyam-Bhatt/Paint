using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioClip guitarGirl;

    private AudioSource audioSource;

    private bool playSIMP = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSIMP)
        {
            audioSource.clip = guitarGirl;
            audioSource.Play();
            playSIMP = false;
        }
    }
}
