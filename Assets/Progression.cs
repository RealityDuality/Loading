using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progression : MonoBehaviour {

public Image LoadBar;
	[SerializeField]
	private GameObject message1;
	[SerializeField]
	private GameObject message2;
	[SerializeField]
	private GameObject message3;
	[SerializeField]
	private GameObject message4;
	[SerializeField]
	private GameObject message5;
	[SerializeField]
	private int randomSpawn;

	public GameObject[] messages;

	public bool TimeToSpawn;

	public bool FirstTime;

[SerializeField]
private float AddTime;

	public float keyStrokes;

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

	[SerializeField]
	private float HalfTime;

	[SerializeField]
	private float WaitSeconds;

	private float DefaultWaitSeconds;

	[SerializeField]
	private float RestartTime;

	[SerializeField]
	private float MaxRestartTime;

	[SerializeField]
	private float IncBy;

	[SerializeField]
	private int NumberOfBox;

    // Use this for initialization
    void Start () {
		//AddTime = SpeedToFinish;
		MinSpeedToFinish = SpeedToFinish;
		DefaultWaitSeconds = WaitSeconds;

		HalfTime = TimeToFinish / 2;
		TimeToSpawn = true;
	}

	// Update is called once per frame
	void Update () {
		messages = GameObject.FindGameObjectsWithTag("message");


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
			SpeedToFinish -= Time.deltaTime / 64;

		}
		if (SpeedToFinish >= MaxSpeedToFinish) {
			SpeedToFinish = MaxSpeedToFinish;
		}



	 }




	void FixedUpdate(){
	


		if (ActiveTime >= HalfTime) {
			//TimeToSpawn = true;
			if (FirstTime == true) {
				StartCoroutine (SpawnMessage ());
				FirstTime = false;

			}
			RestartTime += Time.fixedDeltaTime;
		}

		if (RestartTime >= MaxRestartTime) {
			TimeToSpawn = true;
		}

	}


    public void KeyPressed() { 
		keyStrokes++;



		if(FirstTime == false){
		RestartTime = 0;
			TimeToSpawn = false;}

		if (TimeToSpawn == true) {
			SpeedToFinish += IncBy;
		}

		foreach(GameObject message in messages)
		{
			Destroy(message);
			NumberOfBox = 0;
		}

    }





	IEnumerator SpawnMessage()
	{

		randomSpawn = Random.Range(1, 6);
		float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
		float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
		Vector2 spawnPosition = new Vector2(spawnX, spawnY);

		if (TimeToSpawn == true) {
			switch (randomSpawn) {
			case 1:
				Instantiate (message1, spawnPosition, Quaternion.Euler (new Vector3 (0, 0, Random.Range (0, 360))));
				NumberOfBox += 1;
				break;
			case 2:
				Instantiate (message2, spawnPosition, Quaternion.Euler (new Vector3 (0, 0, Random.Range (0, 360))));
				NumberOfBox += 1;
				break;
			case 3:
				Instantiate (message3, spawnPosition, Quaternion.Euler (new Vector3 (0, 0, Random.Range (0, 360))));
				NumberOfBox += 1;
				break;
			case 4:
				Instantiate (message4, spawnPosition, Quaternion.Euler (new Vector3 (0, 0, Random.Range (0, 360))));
				NumberOfBox += 1;
				break;
			case 5:
				Instantiate (message5, spawnPosition, Quaternion.Euler (new Vector3 (0, 0, Random.Range (0, 360))));
				NumberOfBox += 1;
				break;
			}
		}

		if (NumberOfBox == 20) {
			WaitSeconds -= 0.2f;
		} else if (NumberOfBox == 50) {
			WaitSeconds -= 0.2f;
		} else if (NumberOfBox == 0) {
			WaitSeconds = DefaultWaitSeconds;
		}

		yield return new WaitForSeconds(WaitSeconds);
		StartCoroutine(SpawnMessage());


	}




}


