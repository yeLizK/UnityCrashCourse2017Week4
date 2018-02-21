using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	float speed=3f;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		float moveVertical=0f;
		float moveHorizontal=0f;
		
		if (Input.GetKey ("right")) {
			moveHorizontal = speed*5f;

		} if (Input.GetKey ("left")) {
			moveHorizontal = -speed*5f;

		} if (Input.GetKey ("up")) {
			moveVertical = speed*5f;

		} if (Input.GetKey ("down")) {
			moveVertical = -speed*5f;
		}

		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.velocity = new Vector3(moveHorizontal, 0.0f,moveVertical);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 10)
		{
			winText.text = "You Win!";
		}
	}
}