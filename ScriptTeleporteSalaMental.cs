using UnityEngine;

public class TeleporteToggle : MonoBehaviour
{
    public Vector2 posicaoTeleporte = new Vector2(1000f, 0f); // Pode ser editado no Inspetor
    private Vector2 posicaoOriginal;
    private bool teleportado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!teleportado)
            {
                posicaoOriginal = transform.position; // Salva posição atual
                transform.position = posicaoTeleporte; // Teleporta
                teleportado = true;
                Debug.Log("Teleportado para " + posicaoTeleporte);
            }
            else
            {
                transform.position = posicaoOriginal; // Retorna
                teleportado = false;
                Debug.Log("Retornado para " + posicaoOriginal);
            }
        }
    }
}
