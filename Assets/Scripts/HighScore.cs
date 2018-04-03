using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public int highscoreEasy;
    public int highscoreMedium;
    public int highscoreHard;

    public Text highscoreText;

    public DifficultyButtons difficultyButtons;
    	
	void Start () {
        if (PlayerPrefs.HasKey("HighscoreEasy")) {
            this.highscoreEasy = PlayerPrefs.GetInt("HighscoreEasy");
        } else {
            this.highscoreEasy = 999;
        }

		if (PlayerPrefs.HasKey("HighscoreMedium")) {
            this.highscoreMedium = PlayerPrefs.GetInt("HighscoreMedium");
		} else {
			this.highscoreMedium = 999;
		}

		if (PlayerPrefs.HasKey("HighscoreHard")) {
            this.highscoreHard = PlayerPrefs.GetInt("HighscoreHard");
		} else {
			this.highscoreHard = 999;
		}
	}

    void FixedUpdate () {
        if (this.difficultyButtons.currentDifficulty == "easy") {
            this.highscoreText.text = this.highscoreEasy.ToString();
        } else if (this.difficultyButtons.currentDifficulty == "medium") {
            this.highscoreText.text = this.highscoreMedium.ToString();
        } else if (this.difficultyButtons.currentDifficulty == "hard") {
            this.highscoreText.text = this.highscoreHard.ToString();
        }
    }

	public void UpdateHighscore (int score) {
        if (this.difficultyButtons.currentDifficulty == "easy") {
            if (score < this.highscoreEasy) {
                this.highscoreEasy = score;
                PlayerPrefs.SetInt("HighscoreEasy", score);
            }
        } else if (this.difficultyButtons.currentDifficulty == "medium") {
            if (score < this.highscoreMedium) {
                this.highscoreMedium = score;
                PlayerPrefs.SetInt("HighscoreMedium", score);
            }
        } else if (this.difficultyButtons.currentDifficulty == "hard") {
            if (score < this.highscoreHard) {
                this.highscoreHard = score;
                PlayerPrefs.SetInt("HighscoreHard", score);
            }
        }
        PlayerPrefs.Save();
    }

    public void ResetHighscore (){
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        this.highscoreEasy = 999;
        this.highscoreMedium = 999;
        this.highscoreHard = 999;
    }


}
