using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Saves the highscore to the different difficulty levels (easy, medium, hard)
/// </summary>
public class HighScore : MonoBehaviour {

    /// <summary>
    /// The Best score on Easy-Difficulty
    /// </summary>
    public int highscoreEasy;

    /// <summary>
    /// The best score on Medium-Difficutly
    /// </summary>
    public int highscoreMedium;

    /// <summary>
    /// The best score for hard-difficulty
    /// </summary>
    public int highscoreHard;

    /// <summary>
    /// The Current Score-Label
    /// </summary>
    public Text highscoreText;

    /// <summary>
    /// A Reference to the difficultybuttons
    /// </summary>
    public DifficultyButtons difficultyButtons; 
    	
	private void Start () {
        if (PlayerPrefs.HasKey("HighscoreEasy")) {
            highscoreEasy = PlayerPrefs.GetInt("HighscoreEasy");
        } else {
            highscoreEasy = 999;
        }

		if (PlayerPrefs.HasKey("HighscoreMedium")) {
            highscoreMedium = PlayerPrefs.GetInt("HighscoreMedium");
		} else {
			highscoreMedium = 999;
		}

		if (PlayerPrefs.HasKey("HighscoreHard")) {
            highscoreHard = PlayerPrefs.GetInt("HighscoreHard");
		} else {
			highscoreHard = 999;
		}
	}

    /// <summary>
    /// Updates the current Score-Text
    /// </summary>
    void FixedUpdate () {
        if (difficultyButtons.currentDifficulty == "easy") {
            highscoreText.text = highscoreEasy.ToString();
        }

        if (difficultyButtons.currentDifficulty == "medium") {
            highscoreText.text = highscoreMedium.ToString();
        }

        if (difficultyButtons.currentDifficulty == "hard") {
            highscoreText.text = highscoreHard.ToString();
        }
    }

    /// <summary>
    /// Updates the Highscore with the current score
    /// </summary>
    /// <param name="score">The current Score</param>
	public void UpdateHighscore (int score) {
        if (this.difficultyButtons.currentDifficulty == "easy") {
            if (score < highscoreEasy) {
                highscoreEasy = score;
                PlayerPrefs.SetInt("HighscoreEasy", score);
            }
        }

        if (this.difficultyButtons.currentDifficulty == "medium") {
            if (score < highscoreMedium) {
                highscoreMedium = score;
                PlayerPrefs.SetInt("HighscoreMedium", score);
            }
        }

        if (this.difficultyButtons.currentDifficulty == "hard") {
            if (score < highscoreHard) {
                highscoreHard = score;
                PlayerPrefs.SetInt("HighscoreHard", score);
            }
        }

        PlayerPrefs.Save();
    }

    /// <summary>
    /// Resets the Highscore.
    /// Sets all Highscores to 999
    /// </summary>
    public void ResetHighscore () {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        highscoreEasy = 999;
        highscoreMedium = 999;
        highscoreHard = 999;
    }


}
