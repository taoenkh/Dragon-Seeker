using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneController : MonoBehaviour {

	// referece of the UI object when game over
	public GameObject loseText;
	public GameObject restartButton;


    //gameOver event variables
    public UnityEvent GameOver;

    // Use this for initialization
    void Start () {
        if (GameOver == null)
        {
            GameOver = new UnityEvent();
        }

        GameOver.AddListener(gameOver);
    }
	
	// Update is called once per frame
	void Update () {
        

    }

	//Function called by gameOver event 
	public void gameOver() {

		loseText.SetActive(true);
		restartButton.SetActive(true);

		//Everything except Update() and button functions will be paused
		Time.timeScale = 0;
	}

    //Function called by restart button
	public void restartGame() {

		SceneManager.LoadScene("MenuStart");
		Time.timeScale = 1;
	}

    public void ToStage2()
    {

        SceneManager.LoadScene("Stage2");
        Time.timeScale = 1;
    }

    public void ToStage3()
    {

        SceneManager.LoadScene("Stage3");
        Time.timeScale = 1;
    }

    public void WinScene()
    {

        SceneManager.LoadScene("Win");
        Time.timeScale = 1;
    }
}
