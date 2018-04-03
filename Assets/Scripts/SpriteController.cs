using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour {

    public Sprite defaultSprite;
    public Sprite mineSprite;
    public Sprite securedTileSprite;
    public Sprite deadlyMineSprite;
    public Sprite securedMineSprite;
    public Sprite[] emptyTileSprites;

   
    public void SetEmptyTileSprite (int amountNeighbouredMines) {
        GetComponent<SpriteRenderer>().sprite = emptyTileSprites[amountNeighbouredMines];
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SetMineSprite() {
        GetComponent<SpriteRenderer>().sprite = this.mineSprite;
        GetComponent<BoxCollider2D>().enabled = false;
    }

	public void SetSecuredTileSprite() {
		GetComponent<SpriteRenderer>().sprite = this.securedTileSprite;
	}

	public void SetDeadlyMineSprite() {
		GetComponent<SpriteRenderer>().sprite = this.deadlyMineSprite;
		GetComponent<BoxCollider2D>().enabled = false;
	}

	public void SetSecuredMineSprite() {
		GetComponent<SpriteRenderer>().sprite = this.securedMineSprite;
		GetComponent<BoxCollider2D>().enabled = false;
	}

    public void SetDefaultTileSprite() { 
        GetComponent<SpriteRenderer>().sprite = this.defaultSprite;
	}
}
