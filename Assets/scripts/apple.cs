using Unity.VisualScripting;
using UnityEngine;

public class apple : MonoBehaviour
{
    public GameObject sepet;
    public float fallSpeed = 2f;
    void Update()
    {
        transform.Translate(Vector3.down*fallSpeed*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Basket")){
            GameManager.instance.AddScore(1);
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameManager.instance.SpawnNewBasket();
        }
        else if(other.CompareTag("Ground")){
            GameManager.instance.LoseLife(1);
            Destroy(gameObject);
        }
    }
}
