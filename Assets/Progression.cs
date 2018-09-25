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






    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {
                ActiveTime += Time.deltaTime;
                var percent = ActiveTime / TimeToFinish;
                LoadBar.fillAmount = Mathf.Lerp(0, 1, percent);

        if(TimeToFinish >= MaxTimeToFinish)
        {
            TimeToFinish = MaxTimeToFinish;
        }
          


		if(Input.anyKeyDown)
			{
	 	        KeyPressed();

            TimeToFinish += AddTime;
            //ActiveTime -= AddTime;

			}

	 }




    public void KeyPressed() { keyStrokes++;

    }










}


