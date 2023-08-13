using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarGirl_Dialogues : MonoBehaviour
{
    [SerializeField] private Dialogue sentences;

    private void Awake()
    {
        FindAnyObjectByType<Dialogue_Manager>().guitarGirl_Call = true;
    }

    private void Start()
    {
        FindAnyObjectByType<Dialogue_Manager>().StartDialogue(sentences);
    }
}
