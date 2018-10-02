using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progression : MonoBehaviour {

public Image LoadBar;


[SerializeField]
private float AddTime;


 

[SerializeField]
private float keyStrokes;

    [SerializeField]
    private float TimeToFinish;

    [SerializeField]
    private float MaxTimeToFinish;


    [SerializeField]
    private float ActiveTime;

	[SerializeField]
	private float MinSpeedToFinish;

	[SerializeField]
	private float SpeedToFinish; //Make sure it is incredibly small.

	[SerializeField]
	private float MaxSpeedToFinish;




    // Use this for initialization
    void Start () {
		//AddTime = SpeedToFinish;
		MinSpeedToFinish = SpeedToFinish;
	}

	// Update is called once per frame
	void Update () {
		ActiveTime += Time.deltaTime / SpeedToFinish;
                var percent = ActiveTime / TimeToFinish;
                LoadBar.fillAmount = Mathf.Lerp(0, 1, percent);

          


		if(Input.anyKeyDown)
			{
	 	        KeyPressed();

            //TimeToFinish += AddTime;
            //ActiveTime -= AddTime;
			SpeedToFinish += AddTime;

			}

		if (SpeedToFinish >= MinSpeedToFinish) {
			SpeedToFinish -= Time.deltaTime / SpeedToFinish;

		}
		if (SpeedToFinish >= MaxTimeToFinish) {
			SpeedToFinish = MaxTimeToFinish;
		}


	 }




    public void KeyPressed() { keyStrokes++;

    }










}


