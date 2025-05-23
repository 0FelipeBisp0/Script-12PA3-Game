using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidade do jogador
    public SpriteRenderer spriteRenderer;
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    private Vector2 movement;
    public Animator animator;
    private bool isFrozen = false; // Variável para controlar se o jogador está congelado

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtém o Animator do jogador
    }
    // Update is called once per frame
    void Update()
    {
        if (isFrozen) return; // Se o jogador estiver congelado, não processa a entrada
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;

        // Enviar os valores para o Animator
        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
    }

    public void SetFrozen(bool state) {
        isFrozen = state; // Define o estado de congelamento do jogador

    }
}
