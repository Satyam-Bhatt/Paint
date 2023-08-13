using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogue);
    }
}
