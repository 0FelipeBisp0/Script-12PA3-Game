using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController2D : MonoBehaviour
{
    public float velocidadePatrulha = 2f;
    public float velocidadePerseguicao = 5f;
    public float intervaloOlhar = 2f;
    public float duracaoOlhar = 1f;
    public float distanciaDetecao = 5f;
    public float distanciaCaptura = 1f;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource trilhaSonora;
    public AudioSource somAviso;
    public AudioSource somCaptura;

    private Transform player;
    private Animator animator;
    private Vector2 direcaoOlhar;
    private float timerOlhar;
    private bool perseguindoPlayer = false;
    private bool colidindoComObstaculo = false;
    private float timerAudio;

    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        direcaoOlhar = RandomDirection();
        timerOlhar = intervaloOlhar;
        timerAudio = 5f;

        if (audioSource1 == null) audioSource1 = GetComponent<AudioSource>();
        if (audioSource2 == null) audioSource2 = GetComponent<AudioSource>();
    }

    void Update()
    {
        float distanciaJogador = Vector2.Distance(transform.position, player.position);

        if (!perseguindoPlayer)
        {
            if (distanciaJogador <= distanciaDetecao)
            {
                Debug.Log("Inimigo avistou o jogador! Iniciando perseguição.");
                perseguindoPlayer = true;
                somAviso.Play();
                trilhaSonora.Pause();
            }
            else
            {
                Patrulhar();
            }
        }
        else
        {
            Vector2 direcaoParaPlayer = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direcaoParaPlayer * velocidadePerseguicao * Time.deltaTime);

            if (distanciaJogador > distanciaDetecao)
            {
                Debug.Log("Você escapou por enquanto!");
                perseguindoPlayer = false;
                somAviso.Stop();
                trilhaSonora.UnPause();
            }

            if (distanciaJogador <= distanciaCaptura)
            {
                Debug.Log("Jogador capturado pelo inimigo! Game Over.");
                somCaptura.Play();
                Invoke("RestartGame", 2f);
            }
        }

        timerAudio -= Time.deltaTime;
        if (timerAudio <= 0f)
        {
            if (Random.Range(0, 2) == 0)
                audioSource1.Play();
            else
                audioSource2.Play();

            timerAudio = 5f;
        }
    }

    void Patrulhar()
    {
        if (!colidindoComObstaculo)
        {
            timerOlhar -= Time.deltaTime;
            if (timerOlhar <= 0f)
            {
                direcaoOlhar = RandomDirection();
                timerOlhar = duracaoOlhar;
                animator.SetBool("Movendo", false);
            }
            else
            {
                rb.MovePosition(rb.position + direcaoOlhar * velocidadePatrulha * Time.deltaTime);
                animator.SetBool("Movendo", true);
            }
        }
    }

    Vector2 RandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        return new Vector2(randomX, randomY).normalized;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            colidindoComObstaculo = true;
            velocidadePatrulha = 0f;
            animator.SetBool("Movendo", false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            colidindoComObstaculo = false;
            velocidadePatrulha = 2f;
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
