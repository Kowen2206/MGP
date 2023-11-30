using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class BlondAi : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Sprite[] NPCPEmoji;
    private bool isPlayerInRange = false;

    [Header("DialogueNPC")]
    [SerializeField, TextArea(4, 6)] private string dialogueLines;
    [SerializeField] private float typingTime = 0.05f;

    [Header("Answer System")]
    [SerializeField] private GameObject playerPort;
    [SerializeField] private GameObject NPCPort;
    [SerializeField] private GameObject answerPanel;
    [SerializeField] private TMP_Text[] asnwerText;
    [SerializeField, TextArea(4, 6)] private string[] answerLines;

    private bool didDialogueStart;
    private bool canAnswer;
    [SerializeField] private Image emoji;
    private bool isFacingRight = true;
    private void Start()
    {
        dialoguePanel.SetActive(false);
        answerPanel.SetActive(false);
        playerPort.SetActive(false);
        canAnswer = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
            dialoguePanel.SetActive(false);
            answerPanel.SetActive(false);
        }
    }
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.G))
        {
            if (!didDialogueStart)
            {
                bool isPlayerRight = transform.position.x < player.transform.position.x;
                Flip(isPlayerRight);
                StartDialogue();
            }
        }
        if (canAnswer)
        {
            playerPort.SetActive(true);
            answerPanel.SetActive(true);
            for (int i = 0; i < answerLines.Length; i++)
            {
                asnwerText[i].text = answerLines[i];
            }
        }
    }
    private void StartDialogue()
    {
        emoji.sprite = NPCPEmoji[3];
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);

        StartCoroutine(ShowLine());
    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines)
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
        canAnswer = true;
    }
   public void Answer1()
    {
        Debug.Log("Consejo");
        dialogueLines = "Solo puedo decirte que, si bajas llegaras al nivel final ";
        emoji.sprite = NPCPEmoji[0];
        StartCoroutine(ShowLine());
    }
    public void Answer2()
    {
        Debug.Log("Mision");
        dialogueLines = "Elimina al jefe final para que todo se termine";
        emoji.sprite = NPCPEmoji[1];
        StartCoroutine(ShowLine());
    }
    public void Answer3()
    {
        Debug.Log("Nada");
        dialogueLines = "Todos necesitan algo";
        emoji.sprite = NPCPEmoji[2];
        StartCoroutine(ShowLine());
    }
    public void Back()
    {
        dialogueLines = "Necesitas algo mas?";
        dialoguePanel.SetActive(false);
        dialogueMark.SetActive(false);
        didDialogueStart = false;
    }
    private void Flip(bool isPlayerRight)
    {
        if ((isFacingRight && !isPlayerRight || (isFacingRight && isPlayerRight)))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}

