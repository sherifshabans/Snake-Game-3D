using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void OnTriggerEnter (Collider other)
	{
		Debug.Log(other.tag);

        if (other.tag == "Wall" || other.tag == "Player")
		{ 
            GameObject.FindObjectOfType<GameManager>().game_over = true;
        }
		if (other.tag == "Food" )
		{
			Debug.Log("HI");
           // GameObject.FindObjectOfType<GameManager>().game_over = true;
			Destroy(other.gameObject);
		}
		
	}
}
