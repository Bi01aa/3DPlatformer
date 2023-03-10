using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    [SerializeField]
    GameObject itemPrefab;
    [SerializeField]
    Sprite icon;
    
    [SerializeField]
    string itemName;
    [SerializeField]
    [TextArea(4, 16)]
    string description;
    
    [SerializeField]
    float weight = 0;
    [SerializeField]
    int quanity = 1;
    [SerializeField]
    int maxStackableQuantity = 1;
    public int pointValue = 1;

    [SerializeField]
    bool isStorable = false;
    [SerializeField]
    bool isConsumable = true;

    [SerializeField]
    bool isPickUpOnCollision = false;

    private void Start()
    {
        if (isPickUpOnCollision)
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (isPickUpOnCollision)
        {


            if (collider.tag == "Player")
            {
                Interact();
            }
        }
    }

    public void Interact()
    {
        Debug.Log("Picked up " + transform.name);

        if (isStorable)
        {
            Store();
        }
        else
        {
            Use();
        }
    }

    void Store()
    {
        Debug.Log("Storing " + transform.name);

        //TODO Inventory system

        Destroy(gameObject);
    }

    void Use()
    {
        
        if (isConsumable)
        {
            GameManager.IncrementScore(pointValue);
            quanity--;
            if(quanity <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}

