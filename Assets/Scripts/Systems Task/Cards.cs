using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cards : MonoBehaviour
{
    private int card = 0;
    GameObject cardObject;
    bool hovered;

    public List<GameObject> cards = new List<GameObject>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact(InputAction.CallbackContext context)

    {

        if (context.performed)
        {
            SpawnCard();
            Debug.Log("interacted");
        }

    }

    public void Show()
    {
        hovered = true;

    }

    public void Unshow()
    {
        hovered = false;
    }

    public void SpawnCard()
    {
        Destroy(cardObject);

        card = Random.Range(0, cards.Count);

         cardObject = Instantiate(cards[card], transform.position, transform.rotation);

    }
    public void Delete()
    {
        Destroy(cardObject);
    }

}
