using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private List<string> clues = new List<string>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddClue(string name, string description)
    {
        clues.Add(name);
        Debug.Log("Adicionada ao inventário: " + name + "\n" + description);
        // Aqui você pode chamar o HUD do inventário para mostrar a pista
    }

    public List<string> GetClues()
    {
        return clues;
    }
}
