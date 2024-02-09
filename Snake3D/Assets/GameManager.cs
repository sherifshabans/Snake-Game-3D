using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

public GameObject snake;
public GameObject food;
public Text  Score ;
public Text  Timer ;
public Text  GameOver ;
public Text  Success ;

int starting_count = 5;
List<Vector3> postitions = new List<Vector3>();
List<GameObject> allSnake = new List<GameObject>();

	public int score = 0;
	public int timer = 15;

Vector3 direction = new Vector3(1, 0, 0);
	 
bool is_locked = false;

 public bool game_over = false;
 public bool success = false;

	void Start()
	{
		GameOver.enabled = false;
		Success.enabled = false;

		for (int i = 0; i < starting_count; i++)
		{
			postitions.Add(new Vector3(i - starting_count, 0, 0));
			GameObject new_snake = Instantiate(snake);
			new_snake.transform.position = postitions[i];
			allSnake.Add(new_snake);
		}
		for (int i = 0; i < 10; i++)
		{
			bool flag = false;
			int a, b;

			do
			{
				flag = true;
				a = Random.Range(-4, 4);
				b = Random.Range(-6, 6);
				Debug.Log(a);
				Debug.Log(b);
				for (int j = 0; j < postitions.Count; j++)
				{
					if (postitions[j].x == a && postitions[j].z == b)
					{
						flag = false;
						break;
					}
				}
			} while (flag == false);

			GameObject new_food = Instantiate(food);
			new_food.transform.position = new Vector3(a, 0, b);

		}
        StartCoroutine(MoveSnake());
        StartCoroutine(TimeFood());


    }
    // Update is called once per frame
    void Update () {
				if (Input.GetKeyUp(KeyCode.UpArrow) && direction.z == 0) { direction = new Vector3(0, 0, 1);  }
				else if (Input.GetKeyUp(KeyCode.DownArrow) && direction.z == 0) { direction = new Vector3(0, 0, -1);  }
				else if (Input.GetKeyUp(KeyCode.LeftArrow) && direction.x == 0) { direction = new Vector3(-1, 0, 0);  }
				else if (Input.GetKeyUp(KeyCode.RightArrow) && direction.x == 0) { direction = new Vector3(1, 0, 0);  }

			
			}
	IEnumerator MoveSnake()
	{

		yield return  new WaitForSeconds(0.25f);

		if(game_over||success )yield break;
		
		
	    postitions.RemoveAt(0);
		postitions.Add(postitions[postitions.Count - 1] + direction);

		for(int i = 0; i < postitions.Count; i++)
		{
			allSnake[i].transform.position = postitions[i];
		}
		is_locked = false;  
        StartCoroutine(MoveSnake());
    }

	IEnumerator TimeFood()
	{
		yield return new WaitForSeconds(1f);

		if (timer == 0)
		{
			GameOver.enabled = true;
			game_over = true;
			yield break;
		}
		if (success) { yield break; }
		timer--;
		Timer.text = "Timer: " + timer.ToString();


        
		StartCoroutine(TimeFood());

    }
}
