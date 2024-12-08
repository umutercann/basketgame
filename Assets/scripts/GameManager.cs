using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject sepet;
    public GameObject elma;
    public GameObject kup;
    public int score = 0;
    public int lives = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public bool gamePaused = false;
        private void Awake()
    {
        if(instance==null){
            instance = this;
        } 
        else{
            Destroy(gameObject);
        }
    }    
    private void Start()
    {
        gameOverText.enabled=false;
        UpdateUI();
    }
    private void UpdateUI(){
        scoreText.text = "Score: "+ score;
        livesText.text ="Lives: "+lives;
    }

    private void GameOver(){
        Debug.Log("Game Over!");
        gameOverText.enabled=true;
        gamePaused = true;
    }
    private void ContinuePlaying() {
        gamePaused = false;
    }
    public void AddScore(int amount){
        score+=amount;
        UpdateUI();
    }
    public void LoseLife(int amount){
        lives -= amount;
        UpdateUI();
        if(lives<=0)
        {
            GameOver();
        }
    }
    public void SpawnNewBasket()
    {
        float randomX = Random.Range(-2f,2f);
        float randomZ = Random.Range(-2f,2f);
        Vector3 newPosition = new Vector3(randomX,0.5f,randomZ);
        Instantiate(sepet,newPosition,Quaternion.identity);
    }
    public void SpawnApple(){
        Instantiate(elma,kup.transform.position,Quaternion.identity);
    }
}
