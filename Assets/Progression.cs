using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using System;


public class Progression : MonoBehaviour {
    //import System.IO;

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
    private GameObject message6;
    [SerializeField]
    private GameObject message7;
    [SerializeField]
    private GameObject message8;
    [SerializeField]
    private GameObject message9;
    [SerializeField]
    private GameObject message10;
    [SerializeField]
    private GameObject message11;
    [SerializeField]
    private GameObject message12;
    [SerializeField]
    private GameObject message13;
    [SerializeField]
    private GameObject message14;
    [SerializeField]
    private GameObject message15;
    [SerializeField]
    private GameObject message16;
    [SerializeField]
    private GameObject message17;
    [SerializeField]
    private GameObject message18;
    [SerializeField]
    private GameObject message19;
    [SerializeField]
    private GameObject message20;
    [SerializeField]
	private int randomSpawn;

	public GameObject[] messages;

	public bool TimeToSpawn;

	public bool FirstTime;

    [SerializeField]
    private float NormalTime;

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

    [SerializeField]
    private float layerNumber;

    public string PrintKey;

    [SerializeField]
    private int FileNum;

    [SerializeField]
    private int CurrentFileNum;

    [SerializeField]
    private string SaveSlot;


    public InputField HereName;
    [SerializeField]
    private GameObject FieldRemove;


    public string ConvName;
    [SerializeField]
    private bool NameNotNull;

    private float MinTimeToFinish;

    [SerializeField]
    private float MaxKeys;

[SerializeField]
private int Scoring;


    [SerializeField]
    private int HalfwayKey;

    private float TimeToReachHalf;

    private bool HalfTimed;

    public GameObject background;
    public GameObject background1;
    public GameObject loadingText;
    public GameObject titleText;
    private bool DnF;



    // Use this for initialization
    void Start () {
		//AddTime = SpeedToFinish;
		MinSpeedToFinish = SpeedToFinish;
		DefaultWaitSeconds = WaitSeconds;

		HalfTime = TimeToFinish / 2;
		TimeToSpawn = true;

        FileNum = PlayerPrefs.GetInt(SaveSlot);

        CurrentFileNum = FileNum;
        keyStrokes = 0;

        MinTimeToFinish = MaxTimeToFinish - 0.0001f;


	}

	// Update is called once per frame
	void Update () {
		messages = GameObject.FindGameObjectsWithTag("message");
QuitCode();
        if (NameNotNull == true)
        {

            ActiveTime += Time.deltaTime / SpeedToFinish;
            var percent = ActiveTime / TimeToFinish;
            LoadBar.fillAmount = Mathf.Lerp(0, 1, percent);
            background.SetActive(false);
            titleText.SetActive(false);
            background1.SetActive(true);
            loadingText.SetActive(true);


            if (ActiveTime >= MaxTimeToFinish)
            {
                if(FileNum == CurrentFileNum){
                    PlayerPrefs.SetFloat("TimeSet", NormalTime);
                    PlayerPrefs.SetFloat("Scoring", keyStrokes);
                    Write2File();
                    SceneManager.LoadScene("Win Screen");

                }

                //LoadScene for end screen here. Bad End
            }

            if (ActiveTime >= HalfTime ){
                if(HalfTimed == false){

                    TimeToReachHalf = NormalTime;
                    HalfTimed = true;
                }
            }

            if (Input.anyKeyDown)
            {
                KeyPressed();

                //TimeToFinish += AddTime;
                //ActiveTime -= AddTime;
                SpeedToFinish += AddTime;

            }



            if (SpeedToFinish >= MinSpeedToFinish)
            {
                SpeedToFinish -= Time.deltaTime / 64;

            }
            if (SpeedToFinish >= MaxSpeedToFinish)
            {
                SpeedToFinish = MaxSpeedToFinish;
            }


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

        if(NameNotNull == true){
            NormalTime += Time.fixedDeltaTime;
            if(NormalTime >= 900) {
              PlayerPrefs.SetFloat("TimeSet", NormalTime);
              PlayerPrefs.SetFloat("Scoring", keyStrokes);
              PlayerPrefs.SetFloat("MaxScore", MaxKeys);

              Write2File();
              SceneManager.LoadScene("Lose Screen");
            }
        }

	}


    public void KeyPressed() {
		keyStrokes++;
        //Write2File();
        layerNumber = -1;

		if(FirstTime == false){
		RestartTime = 0;
			TimeToSpawn = false;}

		if (TimeToSpawn == true) {
			SpeedToFinish += IncBy;
		}

        if(ActiveTime >= HalfTime){
            HalfwayKey++;
        }
		foreach(GameObject message in messages)
		{
			Destroy(message);
			NumberOfBox = 0;
		}

    if(keyStrokes == MaxKeys){
      DnF = true;
      keyStrokes += 1;
      PlayerPrefs.SetFloat("TimeSet", NormalTime);
      PlayerPrefs.SetFloat("Scoring", keyStrokes);
      PlayerPrefs.SetFloat("MaxScore", MaxKeys);

      Write2File();
      SceneManager.LoadScene("Lose Screen");
    }



    }

    public void NameEntered(){

        if (HereName.text == "")
        {
            return;
        } else
        {
            ConvName = HereName.text;

            PlayerPrefs.SetString("Name", ConvName);

            NameNotNull = true;

            FieldRemove.SetActive(false);
        }

    }

    public void QuitCode(){

      DnF = false;
      if(Input.GetKey(KeyCode.Keypad0)){
        if(Input.GetKey(KeyCode.Keypad6)){
          if( Input.GetKey(KeyCode.Keypad8)){
            keyStrokes -= 2;
            DnF = true;
            PlayerPrefs.SetFloat("TimeSet", NormalTime);
            PlayerPrefs.SetFloat("Scoring", keyStrokes);

            Write2File();
            SceneManager.LoadScene("Lose Screen");
          }
        }
      }
    }


     public void Write2File(){



        FileNum++;





        var lines = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}", ConvName, keyStrokes, NormalTime, FileNum, HalfwayKey, TimeToReachHalf, DnF);
        var lineSetup = string.Format( "Name, Key Strokes, Time Spent, Index, Stage 2 Keystrokes, Time to reach halfway, Did Not Finish");
        using (StreamWriter sw = new StreamWriter("database.csv", append: true)){






            if (File.Exists("data.csv"))
            {
                File.AppendAllText("data.csv", lines + Environment.NewLine);
                Debug.Log("File already exists");
            }

            else{
                File.AppendAllText("data.csv", lineSetup + Environment.NewLine);
                File.AppendAllText("data.csv", lines + Environment.NewLine);
            }




       }
        PlayerPrefs.SetInt(SaveSlot, FileNum);
    }

	IEnumerator SpawnMessage()
	{

		randomSpawn = UnityEngine.Random.Range(1, 21);
		float spawnY = UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y+2, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y-2);
		float spawnX = UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x+1.75f, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x-1.75f);
		Vector3 spawnPosition = new Vector3(spawnX, spawnY, layerNumber);

		if (TimeToSpawn == true) {
			switch (randomSpawn) {
			case 1:
				Instantiate (message1, spawnPosition, Quaternion.Euler (new Vector3 (0, 0, UnityEngine.Random.Range (-75, 75))));
				NumberOfBox += 1;
                break;
			case 2:
				Instantiate (message2, spawnPosition, Quaternion.Euler (new Vector3 (0, 0, UnityEngine.Random.Range (-75, 75))));
				NumberOfBox += 1;
				break;
			case 3:
				Instantiate (message3, spawnPosition, Quaternion.Euler (new Vector3 (0, 0, UnityEngine.Random.Range (-75, 75))));
				NumberOfBox += 1;
				break;
			case 4:
				Instantiate (message4, spawnPosition, Quaternion.Euler (new Vector3 (0, 0, UnityEngine.Random.Range (-75, 75))));
				NumberOfBox += 1;
				break;
			case 5:
				Instantiate (message5, spawnPosition, Quaternion.Euler (new Vector3 (0, 0, UnityEngine.Random.Range (-75, 75))));
				NumberOfBox += 1;
				break;
            case 6:
                Instantiate(message6, spawnPosition, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-75, 75))));
                NumberOfBox += 1;
                break;
            case 7:
                Instantiate(message7, spawnPosition, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-75, 75))));
                NumberOfBox += 1;
                break;
            case 8:
                Instantiate(message8, spawnPosition, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-75, 75))));
                NumberOfBox += 1;
                break;
            case 9:
                Instantiate(message9, spawnPosition, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-75, 75))));
                NumberOfBox += 1;
                break;
            case 10:
                Instantiate(message10, spawnPosition, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-75, 75))));
                NumberOfBox += 1;
                break;
            case 11:
                Instantiate(message11, spawnPosition, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-75, 75))));
                NumberOfBox += 1;
                break;
            case 12:
                Instantiate(message12, spawnPosition, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-75, 75))));
                NumberOfBox += 1;
                break;
            case 13:
                Instantiate(message13, spawnPosition, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-75, 75))));
                NumberOfBox += 1;
                break;
            case 14:
                Instantiate(message14, spawnPosition, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-75, 75))));
                NumberOfBox += 1;
                break;
            case 15:
                Instantiate(message15, spawnPosition, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-75, 75))));
                NumberOfBox += 1;
                break;
            case 16:
                Instantiate(message16, spawnPosition, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-75, 75))));
                NumberOfBox += 1;
                break;
            case 17:
                Instantiate(message17, spawnPosition, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-75, 75))));
                NumberOfBox += 1;
                break;
            case 18:
                Instantiate(message18, spawnPosition, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-75, 75))));
                NumberOfBox += 1;
                break;
            case 19:
                Instantiate(message19, spawnPosition, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-75, 75))));
                NumberOfBox += 1;
                break;
            case 20:
                Instantiate(message20, spawnPosition, Quaternion.Euler(new Vector3(0, 0, UnityEngine.Random.Range(-75, 75))));
                NumberOfBox += 1;
                break;
            }
		}

        if (NumberOfBox == 5) {
            WaitSeconds -= 0.25f;
        } else if (NumberOfBox == 8) {
            WaitSeconds -= 0.25f;
        } else if (NumberOfBox == 10)
        {
            WaitSeconds -= 0.25f;
        }
        else if (NumberOfBox == 12)
        {
            WaitSeconds -= 0.25f;
        }
        else if (NumberOfBox == 15)
        {
            WaitSeconds -= 0.25f;
        }
        else if (NumberOfBox == 20)
        {
            WaitSeconds -= 0.2f;
        }
        else if (NumberOfBox == 30)
        {
            WaitSeconds -= 0.15f;
        }
        else if (NumberOfBox == 45)
        {
            WaitSeconds -= 0.15f;
        }
        else if (NumberOfBox == 70)
        {
            WaitSeconds -= 0.1f;
        }
        else if (NumberOfBox == 100)
        {
            WaitSeconds -= 0.1f;
        }
        else if (NumberOfBox == 0) {
			WaitSeconds = DefaultWaitSeconds;
		}

        layerNumber -= 0.1f;

		yield return new WaitForSeconds(WaitSeconds);
		StartCoroutine(SpawnMessage());


	}




}
