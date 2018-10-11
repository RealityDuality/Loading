using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

public Text Scored;
public float Value;
public float MaxValue = 200;
public float BaseScore;

public Text TimeScored;
public string FormatTime;
public float TimeValue;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Value = PlayerPrefs.GetFloat("Scoring");
			TimeValue = PlayerPrefs.GetFloat("TimeSet");
			MaxValue = PlayerPrefs.GetFloat("MaxScore");
			Value -= 1;
			//MaxValue -= Value;

		//Scored.text = Value.ToString();



		string FormatScore = string.Format("{0} / {1}", 200-Value, 200);



		string FormatTime = string.Format("{0}:{1:00}", (int)TimeValue/60, (int)TimeValue%60);


		TimeScored.text = FormatTime;
		Scored.text = FormatScore;
		//Scored.text = storeValue;

	}

public void GotoLoadingScene() {

    SceneManager.LoadScene("Loading");

}

}
