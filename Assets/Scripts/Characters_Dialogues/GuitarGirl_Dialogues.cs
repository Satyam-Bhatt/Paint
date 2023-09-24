using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarGirl_Dialogues : MonoBehaviour
{
    [SerializeField] private Dialogue sentences;
    [SerializeField] private GameObject panel;

    private void Awake()
    {
        panel.SetActive(false);
        FindAnyObjectByType<Dialogue_Manager>().guitarGirl_Call = true;
    }

    private void Start()
    {
        FindAnyObjectByType<Dialogue_Manager>().StartDialogue(sentences);
    }
}
