using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Needed for TextMeshProUGUI

public class HighScore : MonoBehaviour
{
    // Static backing fields
    private static TextMeshProUGUI _UI_TEXT;
    private static int _SCORE = 1000;

    // (Optional) instance reference, currently unused
    private TextMeshProUGUI txtCom;

    private void Awake()
    {
        // Cache the TMP component on this GameObject
        _UI_TEXT = GetComponent<TextMeshProUGUI>();

        // If we already have a saved HighScore, load it into SCORE (this also updates UI)
        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            // Initialize PlayerPrefs with default value and update UI
            PlayerPrefs.SetInt("HighScore", _SCORE);
            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + _SCORE.ToString("#,0");
            }
        }
    }

    public static int SCORE
    {
        get => _SCORE;
        private set
        {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);

            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    public static void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        // If scoreToTry is too low, do nothing
        if (scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
    }

    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    private void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000.");

            // Also reflect in runtime field/UI if component exists in editor
            _SCORE = 1000;
            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + _SCORE.ToString("#,0");
            }
        }
    }
}
