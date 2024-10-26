using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour {
    public int lives = 3;
    public int bricks = 20;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject paddle;
    private GameObject clonePaddle;

    public TMP_Text theLivesText;
    public TMP_Text theYouWon;
    public TMP_Text theGameOver;
    public GameObject thePaddle;

    void Awake() {
        Setup();
    }
    public void Setup() {
        clonePaddle = Instantiate(paddle, transform.position,
        Quaternion.identity);
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }
    void CheckGameOver() {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
    }
    void Reset() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoseLife() {
        lives--;
        livesText.text = "Lives: " + lives;
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }
    void SetupPaddle() {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
    }
    public void DestroyBrick() {
        bricks--;
        CheckGameOver();
    }
}

