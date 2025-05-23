using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    [SerializeField] GameObject maca;
    [SerializeField] GameObject galinha;
    [SerializeField] GameObject livro;
    public GameObject getItem(ItemType item)
    {
        switch (item)
        {
            case ItemType.maca:
                {
                    return maca;
                }
            case ItemType.galinha:
                {                   
                    return galinha;
                }
            case ItemType.livro:
                {                   
                    return livro;
                }
            default: return null;
        }

    }
}
