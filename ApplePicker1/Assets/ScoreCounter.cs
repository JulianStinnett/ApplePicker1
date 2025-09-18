using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;

    private TextMeshProUGUI uiText; // Use TextMeshProUGUI instead of Text

    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>(); // Get TMP component from GameObject
    }

    void Update()
    {
        uiText.text = score.ToString("#,0"); // Format number with commas
    }
}
