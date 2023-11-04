using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 180.0f;
    public GameObject projetilPrefab;
    public GameObject text;
    public Transform pontoDeDisparo;
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private bool canInteract = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!canInteract)
        {
            return;
        }

        float moveInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        Vector2 moveVelocity = transform.up * moveInput * moveSpeed;
        rb.velocity = moveVelocity;

        float rotationAmount = -rotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, rotationAmount);

        DispararProjeteis();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(collision.gameObject);

            spriteRenderer.enabled = false;

            GetComponent<Collider2D>().enabled = false;

            //Reiniciar o jogo após 5 segundos
            Invoke("RestartGame", 5f);

            text.SetActive(true);
        }
    }

    public void SetCanInteract(bool value)
    {
        canInteract = value;
    }
    private void RestartGame()
    {
        // Reiniciar a cena atual
        SceneManager.LoadScene(0);
    }

    void DispararProjeteis()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projetilPrefab, pontoDeDisparo.position, transform.rotation);
        }
    }
}
