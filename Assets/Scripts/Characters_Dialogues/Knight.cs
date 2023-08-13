using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public Dialogue dialogue;

    private void Awake()
    {
        FindObjectOfType<Dialogue_Manager>().knight_Call = true;
    }

    private void Start()
    {
        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Killed You");   
        }
    }
}
