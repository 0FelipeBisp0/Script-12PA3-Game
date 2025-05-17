using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    [SerializeField] GameObject maca;
    [SerializeField] GameObject galinha;
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
            default: return null;
        }

    }
}
