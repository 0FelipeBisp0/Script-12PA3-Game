using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telhado : MonoBehaviour
{
    public Material roofMaterial;
    public float fadeSpeed = 2f;
    private bool isInside = false;

    void Update()
    {
        float targetAlpha = isInside ? 0f : 1f;
        float currentAlpha = roofMaterial.GetFloat("_Alpha");
        float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, Time.deltaTime * fadeSpeed);
        roofMaterial.SetFloat("_Alpha", newAlpha);
    }

    void OnTriggerEnter2D(Collider2D other) // Alterado para 2D
    {
        if (other.CompareTag("Player")) isInside = true;
    }

    void OnTriggerExit2D(Collider2D other) // Alterado para 2D
    {
        if (other.CompareTag("Player")) isInside = false;
    }
}
