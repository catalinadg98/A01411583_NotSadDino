using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Members : MonoBehaviour {

//	public AudioClip bloom;
	public Sprite[] hitSprites;
	public static int collected = 0;

	private int timesHit;
	private LevelManager levelManager;
	private bool isThere;

	// Use this for initialization
	void Start () {
		isThere = (this.tag == "there");

		if (isThere) {
			collected++;
		}

		timesHit = 0;

		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnCollisionEnter2D (Collision2D collision){
//		AudioSource.PlayClipAtPoint (bloom,transform.position, 0.8f);
		if (isThere) {
			HandleHits ();
		}
	}

	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			collected--;
//			AudioSource.PlayClipAtPoint (bloom, transform.position, 0.8f);
			levelManager.MemberCollected ();
			Destroy (gameObject);
		} 
	}

	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex] != null) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError ("Member sprite missing");
		}
	}
}