using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinesLeft : MonoBehaviour {

    Minefield minefield;

    public Text minesLeftText;

	// Use this for initialization
	void Start () {
        this.minefield = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();
	}

    private void FixedUpdate () {
        this.minesLeftText.text = this.minefield.minesLeft.ToString();
    }
}
