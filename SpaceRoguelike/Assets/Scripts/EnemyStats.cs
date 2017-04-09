using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
	// six enemy types: aggressive[0], accurate[1], defensive[2], pushover[3], balanced[4], hard[5]
	public int enemyType; // number 0-5
	private int aggression; // firing rate?
	private int accuracy; // how often target is hit
	private int defense; // use of shield?
	private string weapon;
	private string[] weapons = new string[6];
	private int[] aggressionMin = new int[6];
	private int[] aggressionMax = new int[6];
	private int[] accuracyMin = new int[6];
	private int[] accuracyMax = new int[6];
	private int[] defenseMin = new int[6];
	private int[] defenseMax = new int[6];

	private EnemyStats()
	{
		aggressionMin [0] = 75; // aggressive
		aggressionMax [0] = 98;
		aggressionMin [1] = 25; // accurate
		aggressionMax [1] = 75;
		aggressionMin [2] = 10; // defensive
		aggressionMax [2] = 50;
		aggressionMin [3] = 10; // pushover
		aggressionMax [3] = 40;
		aggressionMin [4] = 40; // balanced
		aggressionMax [4] = 70;
		aggressionMin [5] = 70; // hard
		aggressionMax [5] = 100;
		accuracyMin [0] = 25; // aggressive
		accuracyMax [0] = 75;
		accuracyMin [1] = 75; // accurate
		accuracyMax [1] = 100;
		accuracyMin [2] = 40; // defensive
		accuracyMax [2] = 70;
		accuracyMin [3] = 10; // pushover
		accuracyMax [3] = 40;
		accuracyMin [4] = 40; // balanced
		accuracyMax [4] = 70;
		accuracyMin [5] = 70; // hard
		accuracyMax [5] = 100;
		defenseMin [0] = 10; // aggressive
		defenseMax [0] = 50;
		defenseMin [1] = 40; // accurate
		defenseMax [1] = 60;
		defenseMin [2] = 75; // defensive
		defenseMax [2] = 100;
		defenseMin [3] = 10; // pushover
		defenseMax [3] = 40;
		defenseMin [4] = 40; // balanced
		defenseMax [4] = 70;
		defenseMin [5] = 70; // hard
		defenseMax [5] = 100;
		weapons [0] = "Shotgun";
		weapons [1] = "Pistol";
		weapons [2] = "Fists";
		weapons [3] = "Sniper";
		weapons [4] = "Knife";
		weapons [5] = "Bazooka";
	}

	void Start()
	{
		aggression = Random.Range (aggressionMin [enemyType], aggressionMax [enemyType]);
		accuracy = Random.Range (accuracyMin [enemyType], accuracyMax [enemyType]);
		defense = Random.Range (defenseMin [enemyType], defenseMax [enemyType]);
		weapon = weapons [Random.Range (0, 5)];
	}

	void OnMouseDown()
	{
		Debug.Log("Aggression: " + aggression);
		Debug.Log("Accuracy: " + accuracy);
		Debug.Log("Defense: " + defense);
		Debug.Log ("Weapon: " + weapon);
	}

}





		/* Take square object and apply EnemyStats.cs to square and print to console to ensure that
		 square has required characteristics */
