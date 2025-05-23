using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    public string[] characterNames;
    [TextArea(3, 10)]
    public string[] sentences;
}
// This class represents a dialogue system in Unity.

