using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGameButton : MonoBehaviour {

    public Sprite happyFace;
    public Sprite neutralFace;
    public Sprite sadFace;

    public Button resetButton;

    public void SetHappy() {
        this.resetButton.image.sprite = this.happyFace;
    }

	public void SetNeutral() { 
		this.resetButton.image.sprite = this.neutralFace;
	}

	public void SetSad() { 
        this.resetButton.image.sprite = this.sadFace;
	}
}
