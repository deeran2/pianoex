using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseRegiment : MonoBehaviour {
	public Image[] notes;
	public Sprite check;
	public Sprite ex;
	public Image response;
	public Text score;
	public Slider exp;
	public Image fillExp;

	Sprite display;
	int currentNote;
	int currentScore = 9;
	int currentLevel = 1;
	bool correct = false;
	public Color gold ;
	public Color green;

	void Start () {
		newNote ();


	}
	
	void Update () {
		// Keep track of score
		score.text = currentScore + " /10";

		//Completing a set increases exp and resets score
		if (currentScore == 10) {
			currentScore = 0;
			exp.value += 1;
		}

		//Filling up exp bar increases strength
		if (exp.value == exp.maxValue) {
			LevelUp ();
			StartCoroutine (Fade ());
		}
		fillExp.color = Color.Lerp (green, gold, exp.value / exp.maxValue);
	}

	//Picks a note to display on music staff
	void newNote (){

		currentNote = Random.Range (0, 7);
		notes [currentNote].gameObject.SetActive (true);
	}

	//Player hits piano key, answer triggers image validation
	public void SelectKey(int pressedkey){
		
		if (currentNote == pressedkey) {
			currentScore++;
			display = check;
			notes [currentNote].gameObject.SetActive (false);

			correct = true;
		} else {
			display = ex;
			correct = false;
		}
		StartCoroutine (Pause ());

	}

	//image validation appears then disappears
	IEnumerator Pause(){

		response.sprite = display;
		response.gameObject.SetActive (true);
		yield return new WaitForSeconds (.4f);
		response.gameObject.SetActive (false);
		if (correct == true) {
			newNote ();
		}

	}

	//Resets exp slider
	void LevelUp(){
		exp.value = 0;
		exp.maxValue += currentLevel * 2;



	}

	//Popup text for leveling up
	IEnumerator Fade() {
		for (float f = 1f; f >= -.011f; f -= 0.02f) {
			Color cf = GetComponentInChildren<Text>().color;
			cf.a = f;
			GetComponentInChildren<Text>().color = cf;
			yield return null;
		}
	}
}
