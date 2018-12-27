using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;

	public bool flashActive;
	public float flashDuration;
	private float flashCounter;

	private SpriteRenderer playerSprite;

	// Use this for initialization
	void Start () {
		playerCurrentHealth = playerMaxHealth;
		playerSprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) {
			playerCurrentHealth = 0;
			gameObject.SetActive(false);

		}
		if (flashActive) {
			if(flashCounter > flashDuration * 0.66f) {
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			}
			else if (flashCounter > flashDuration * 0.33f) {
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
			}
			else if (flashCounter > 0f) {
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			}
			else {
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
				flashActive = false;
			}
			flashCounter -= Time.deltaTime;
		}
	}

	public void HurtPlayer(int damageToGive) {
		playerCurrentHealth -= damageToGive;

		flashActive = true;
		flashCounter = flashDuration;

	}

	public void SetMaxHealth() {
		playerCurrentHealth = playerMaxHealth;
	}
}
