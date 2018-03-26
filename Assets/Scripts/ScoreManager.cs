using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//PLAYER SCORE DOES NOT STOP ON PLAYER DEATH. NEED ACCESS TO GITHUB PROJECT CODE TO IMPLEMENT.


public class ScoreManager : MonoBehaviour {

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
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreIncreasing) 
		{
			scoreCount += pointsPerSecond * Time.deltaTime;
		}

		if (scoreCount > highScoreCount) 
		{
			highScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("Highscore", highScoreCount);
		}

		scoreText.text = "Score: " + Mathf.Round (scoreCount);
		highScoreText.text = "Highscore: " + Mathf.Round (highScoreCount);
	}
}
