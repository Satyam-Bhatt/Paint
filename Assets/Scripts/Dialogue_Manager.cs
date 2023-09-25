using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue_Manager : MonoBehaviour
{
    [HideInInspector]
    public bool knight_Call = false;
    [HideInInspector]
    public bool guitarGirl_Call = false;
    [HideInInspector]
    public bool gunMan_Call = false;


    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;

    [SerializeField] private Vector3 position;
    
    private Queue<string> sentences;

    private void Start()
    {
        panel.SetActive(false);
        sentences = new Queue<string>();
    }

    private void Update()
    {
        //panel.transform.position = position;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        panel.SetActive(true);

        if (knight_Call)
        {
            panel.transform.position = new Vector3(-121.14f, -26.7f, 0f);
        }
        if(guitarGirl_Call)
        {
            panel.transform.position = new Vector3(118.47f, 31.35f, 0f);
        }

        if (gunMan_Call)
        {
            panel.transform.position = new Vector3(12.51f, -15.31f, 0);
        }

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        else
        {
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;

            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    void EndDialogue()
    {
        knight_Call = false;
        guitarGirl_Call = false;
        gunMan_Call = false;
        panel.SetActive(false);
    }
}
