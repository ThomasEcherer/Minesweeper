using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButtons : MonoBehaviour {

    public Minefield minefield;
    public string currentDifficulty = "easy";
        
    void Start () {
        this.minefield = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();
        this.SetEasy();
    }

    /// <summary>
    /// Sets the Difficulty to easy.
    /// Sets the Minefield to 10x10 with 10 mines
    /// </summary>
    public void SetEasy () {
        this.minefield.CreateMineField(10, 10, 10);
        this.currentDifficulty = "easy";
    }

    /// <summary>
    /// Sets the difficulty to medium
    /// Sets the Minefield to 20x20 with 40 mines
    /// </summary>
    public void SetMedium () {
	    this.minefield.CreateMineField(20, 20, 40);
	    this.currentDifficulty = "medium";
    }

    /// <summary>
    /// Sets the difficutly to hard
    /// Sets thte Minefield to 30x20 with 60 mines
    /// </summary>
    public void SetHard () {
	    this.minefield.CreateMineField(30, 20, 60);
	    this.currentDifficulty = "hard";
    }

    /// <summary>
    /// Resets the game.
    /// Takes the same difficulty and creates the minefield new
    /// </summary>
    public void ResetGame () {
        if (this.currentDifficulty == "easy") {
            SetEasy();
        } else if (this.currentDifficulty == "medium") {
            SetMedium();
        } else if(this.currentDifficulty == "hard") {
            SetHard();
        }
    }

}
