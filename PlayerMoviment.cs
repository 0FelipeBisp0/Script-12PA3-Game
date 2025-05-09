using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float speed = 5f; // Velocidade do jogador
    public SpriteRenderer spriteRenderer;
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    private Vector2 movement;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtém o Animator do jogador
    }
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;

        // Enviar os valores para o Animator
        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
    }

  
}
