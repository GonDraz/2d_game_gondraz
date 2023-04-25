using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region Variables
    [Header("Text")]
    [SerializeField]private TextMeshProUGUI nameText, dialogueText;

    [Header("Animator")]
    public Animator animator;

    private Queue<string> sentences;
    #endregion

    #region MonoBehaviour Callbacks
    void Start()
    {
        sentences = new Queue<string>();
    }
    #endregion

    #region Public Methor
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

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
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    #endregion

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }


    #region Private Methor
    private void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
    #endregion
}
