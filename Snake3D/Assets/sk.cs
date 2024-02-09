using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sk : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }
 
    

   private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.tag == "Wall" || other.tag == "Player")
        {
            GameObject.FindObjectOfType<GameManager>().game_over = true;

            GameObject.FindObjectOfType<GameManager>().GameOver.enabled = true;

        }
        if (other.tag == "Food")
        {

          int value=  ++GameObject.FindObjectOfType<GameManager>().score;

            GameObject.FindObjectOfType<GameManager>().Score.text = "Score : "+value.ToString();

            if (value == 10)
            {
                GameObject.FindObjectOfType<GameManager>().success = true;
                GameObject.FindObjectOfType<GameManager>().Success.enabled = true;
            }


            Destroy(other.gameObject);
        }

    }
}
