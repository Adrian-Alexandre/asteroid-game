using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsController : MonoBehaviour
{
    public float moveSpeed = 3f; //Velocidade de movimento do asteroide
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //Definir uma velocidade aleatória para o asteroide
        float randomRotation = Random.Range(-1f, 1f);
        GetComponent<Rigidbody2D>().angularVelocity = randomRotation * moveSpeed;
    }

    private void Update()
    {
      //Mover asteroid para frente
      GetComponent<Rigidbody2D>().velocity = transform.up * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.score += 10;
        Destroy(gameObject);
    }
}
