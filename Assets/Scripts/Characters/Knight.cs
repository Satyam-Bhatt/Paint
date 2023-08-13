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
}
