using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSpawn : MonoBehaviour {

    public GameObject message1;
    public GameObject message2;
    public GameObject message3;
    public GameObject message4;
    public GameObject message5;
    public int randomSpawn;
    public GameObject[] messages;


    // Use this for initialization
    void Start () {

        StartCoroutine(SpawnMessage());

    }
	
	// Update is called once per frame
	void Update () {

        messages = GameObject.FindGameObjectsWithTag("message");

        if (Input.anyKeyDown)
        {
            foreach(GameObject message in messages)
            {
                Destroy(message);
            }

            //StartCoroutine(SpawnMessage());
        }

   	}

    IEnumerator SpawnMessage()
    {

        randomSpawn = Random.Range(1, 6);
        float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        
        switch (randomSpawn)
        {
            case 1:
                Instantiate(message1, spawnPosition, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
                break;
            case 2:
                Instantiate(message2, spawnPosition, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
                break;
            case 3:
                Instantiate(message3, spawnPosition, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
                break;
            case 4:
                Instantiate(message4, spawnPosition, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
                break;
            case 5:
                Instantiate(message5, spawnPosition, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
                break;
        }

        yield return new WaitForSeconds(0.2f);

        StartCoroutine(SpawnMessage());

    }
}
