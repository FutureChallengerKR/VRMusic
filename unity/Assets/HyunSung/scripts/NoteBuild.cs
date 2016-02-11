using UnityEngine;
using System.Collections;

public class NoteBuild : MonoBehaviour {
	public GameObject Note;

	public GameObject Spawn;
	public GameObject SpawnNote1;
	public GameObject SpawnNote2;
	public GameObject SpawnNote3;
	public GameObject SpawnNote4;
	public GameObject SpawnNote5;
	public GameObject SpawnNote6;
	public GameObject SpawnNote7;
	public GameObject SpawnNote8;
	public GameObject SpawnNote9;

	private float curTime;
	public float limitTime;

	// Use this for initialization
	void Start () {
		limitTime = 2.0f;
		Spawn = SpawnNote1;
		//CreatNote ();

	}

	// Update is called once per frame
	void LateUpdate () {
		
		curTime += Time.deltaTime;
		if(curTime > limitTime){
			curTime = 0;
			CreatNote (); // curTime 이 limitTime 보다 커지면 CreaNote()
		}

	
	}
	void SpawnNoteChange(){
		SpawnNote1 = new GameObject();
	}
	void CreatNote(){
		int spNum = Random.Range (1,9); // 메소드 호출 시 마다 spNum 을 1~9 로 달리하여 spawn지역을 바꿈.
		switch (spNum) {
		case 1: 
			Spawn = SpawnNote1;
			break;
		case 2: 
			Spawn = SpawnNote2;
			break;
		case 3: 
			Spawn = SpawnNote3;
			break;
		case 4: 
			Spawn = SpawnNote4;
			break;
		case 5: 
			Spawn = SpawnNote5;
			break;
		case 6: 
			Spawn = SpawnNote6;
			break;
		case 7: 
			Spawn = SpawnNote7;
			break;
		case 8: 
			Spawn = SpawnNote8;
			break;
		case 9: 
			Spawn = SpawnNote9;
			break;
		}
		Instantiate (Note, Spawn.transform.position, Note.transform.rotation);


	}
}
