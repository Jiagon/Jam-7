using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//PLAYER SCORE DOES NOT STOP ON PLAYER DEATH. NEED ACCESS TO GITHUB PROJECT CODE TO IMPLEMENT.


public class ScoreManager : MonoBehaviour
{

    public GameObject enemyObj;
    public Text scoreText;
	public Text highScoreText;

	public float scoreCount;
	public float highScoreCount;

	public float pointsPerSecond;

	public bool scoreIncreasing;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("Highscore")) 
		{
			highScoreCount = PlayerPrefs.GetFloat ("Highscore");
		}
        //GameObject g = GameObject.Find("Enemy");
        //enemy eScript = g.GetComponent<enemy>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        foreach(Transform child in enemyObj.transform)
        {
            if (child.gameObject.GetComponent<enemy>().isEnemyDead)
            {
                scoreCount += 10;
                child.gameObject.GetComponent<enemy>().Infinte();
            }
        }

		if (scoreCount > highScoreCount) 
		{
			highScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("Highscore", highScoreCount);
		}

		scoreText.text = "Score: " + scoreCount;
		highScoreText.text = "Highscore: " + Mathf.Round (highScoreCount);
	}
}
