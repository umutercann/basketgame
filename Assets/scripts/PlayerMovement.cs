using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    void Update(){
        if(GameManager.instance.gamePaused) {
            GameManager.instance.gameOverText.text="Game Over!";
            return;
        }

        float horizantal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizantal,0,vertical)* moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        if(Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up*moveSpeed*Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.down*moveSpeed*Time.deltaTime);
        }    
        if(Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.SpawnApple();
        }
    }
}
