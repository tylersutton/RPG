using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Slider XPBar;
	public Text HPText;
	public PlayerHealthManager playerHealth;

	private PlayerStats thePS;
	public Text levelText;

	private static bool UIExists;

	// Use this for initialization
	void Start () {
		if (!UIExists) {
			UIExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		else {
			Destroy(gameObject);
		}

		thePS = GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		XPBar.maxValue = thePS.toLevelUp[thePS.currentLevel] - thePS.toLevelUp[thePS.currentLevel - 1];
		XPBar.value = thePS.currentXP - thePS.toLevelUp[thePS.currentLevel - 1];
		HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
		levelText.text = "Lvl: " + thePS.currentLevel;
	}
}
