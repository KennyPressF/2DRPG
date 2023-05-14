using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using TMPro;

public class npcInGameSpeech : MonoBehaviour
{
    public GameObject speechBubble;
    [SerializeField] TextMeshProUGUI bubbleText;

    [SerializeField] string[] textOptions;

    Vector2 spawnPoint;
    [SerializeField] float spawnDistanceFromNPC;

    HelperScripts helpers;

    private void Start()
    {
        speechBubble.SetActive(false);
        helpers = FindAnyObjectByType<HelperScripts>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            bool result = helpers.FlipACoin();
            if (!result) { return; } //If FALSE, end here

            SetBubbleSpawnPoint(collision);
            SetSpeechText();
            speechBubble.transform.position = spawnPoint;
            speechBubble.SetActive(true);
        }
    }

    private void SetSpeechText()
    {
        int textIndex = UnityEngine.Random.Range(0, textOptions.Length);
        bubbleText.text = textOptions[textIndex];
    }

    private void SetBubbleSpawnPoint(Collider2D collision)
    {
        var playerPosX = collision.transform.position.x;
        var playerPosY = collision.transform.position.y;
        Vector2 playerPos = new Vector2(playerPosX, playerPosY);

        Vector2 dirToPlayer = (collision.transform.position - transform.position).normalized;

        spawnPoint = playerPos - dirToPlayer.normalized * spawnDistanceFromNPC;
    }
}
