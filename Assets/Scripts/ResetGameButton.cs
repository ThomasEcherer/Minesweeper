using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Statusface / Reset-Game Button
/// </summary>
public class ResetGameButton : MonoBehaviour {

    /// <summary>
    /// The face for a happy face. When the player won the game
    /// </summary>
    public Sprite happyFace;

    /// <summary>
    /// The face for a neutral face. When the game is running or waiting to start
    /// </summary>
    public Sprite neutralFace;

    /// <summary>
    /// The face for a sad fae. When the player lost the game
    /// </summary>
    public Sprite sadFace;

    /// <summary>
    /// The Status-Face.
    /// </summary>
    public Button resetButton;

    /// <summary>
    /// Sets the status-Face to a happy face.
    /// </summary>
    public void SetHappy () {
        resetButton.image.sprite = happyFace;
    }

    /// <summary>
    /// Sets the status-face to a neutral face
    /// </summary>
	public void SetNeutral () { 
		resetButton.image.sprite = neutralFace;
	}

    /// <summary>
    /// Sets the status-face to a sad face
    /// </summary>
	public void SetSad () { 
        resetButton.image.sprite = sadFace;
	}
}
