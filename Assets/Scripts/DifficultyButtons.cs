using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functinoality for the DifficultyButtons on the Bottom-Bar 
/// to change the difficulty by setting up a new minefield.
/// Difficutly is 'easy' by default
/// </summary>
public class DifficultyButtons : MonoBehaviour {

    public Minefield minefield; // Maybe its better to do a singleton

    /// <summary>
    /// The current Difficulty
    /// </summary>
    public string currentDifficulty = "easy";
        
    private void Start () {
        minefield = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();
        SetEasy();
    }

    /// <summary>
    /// Sets the Difficulty to easy.
    /// Sets the Minefield to 10x10 with 10 mines
    /// </summary>
    public void SetEasy () {
        minefield.CreateMineField(10, 10, 10);
        currentDifficulty = "easy";
    }

    /// <summary>
    /// Sets the difficulty to medium
    /// Sets the Minefield to 20x20 with 40 mines
    /// </summary>
    public void SetMedium () {
	    minefield.CreateMineField(20, 20, 40);
	    currentDifficulty = "medium";
    }

    /// <summary>
    /// Sets the difficutly to hard
    /// Sets thte Minefield to 30x20 with 60 mines
    /// </summary>
    public void SetHard () {
	    minefield.CreateMineField(30, 20, 60);
	    currentDifficulty = "hard";
    }

    /// <summary>
    /// Resets the game.
    /// Takes the same difficulty and creates the minefield new
    /// </summary>
    public void ResetGame () {
        if (currentDifficulty == "easy") {
            SetEasy();
        }

        if (currentDifficulty == "medium") {
            SetMedium();
        }

        if (currentDifficulty == "hard") {
            SetHard();
        }
    }

}
