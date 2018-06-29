using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {
	public SpriteRenderer head;
	//private SpriteRenderer sr;
	public Sprite eyeOpen;
	public Sprite eyeClosed;


	public void SFX_ShortBlink() {
	
		StartCoroutine(doShortBlink());
	}
	public void SFX_LongBlink() {

		StartCoroutine(doLongBlink());
	}

	public void SFX_RandomBlink() {

		StartCoroutine(doRandomBlink());
	}


	IEnumerator doRandomBlink() { 
		head.sprite = eyeClosed;
		yield return new WaitForSeconds(Random.Range(.05f,1.2f)); 
		head.sprite = eyeOpen;
	}
	IEnumerator doShortBlink() { 
		head.sprite = eyeClosed;
		yield return new WaitForSeconds(.05f); 
		head.sprite = eyeOpen;
	}

	IEnumerator doLongBlink() { 
		head.sprite = eyeClosed;
		yield return new WaitForSeconds(.1f); 
		head.sprite = eyeOpen;
	}

}
