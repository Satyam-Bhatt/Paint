using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public Dialogue dialogue;

    [SerializeField] private GameObject panel;

    private Menu_Handler menuHandler;

    private void Awake()
    {
        panel.SetActive(false);
        FindObjectOfType<Dialogue_Manager>().knight_Call = true;
        menuHandler = FindObjectOfType<Menu_Handler>();
    }

    private void Start()
    {
        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            menuHandler.playerDied = true;  
        }
    }
}
