using UnityEngine;
using System.Collections;

public class NoteCtrl : MonoBehaviour {
	public GameObject Note;
	private float gazedTime = 0.0f;
	private bool isCaptured = false;

	// Use this for initialization
	public float speed = 400.0f;

	void Start () {
		SetGazedAt(false);
		//GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * speed);

		if (isCaptured) {
			Destroy(Note,3.0f);
			gazedTime += Time.deltaTime;
		} else {
			gazedTime = 0.0f;
		}

		if (gazedTime > 0.1f && isCaptured) {
			gazedTime = 0.0f;

			isCaptured = false;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0.0f,0.0f,-0.1f);   // 생성된 곳으로 부터 z만 달리하여 카메라 방향으로 전진.
		
	
	}
	void LateUpdate() {
		Cardboard.SDK.UpdateState();
		if (Cardboard.SDK.BackButtonPressed) {
			Application.Quit();
		}
	}

	public void SetGazedAt(bool gazedAt) {
		GetComponent<Renderer>().material.color = gazedAt ? Color.black : Color.gray;

		isCaptured = gazedAt;
	}
}
