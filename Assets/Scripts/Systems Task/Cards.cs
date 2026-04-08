using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cards : MonoBehaviour
{
    private int card = 0;
    GameObject cardObject;
    bool hovered;
    Vector3 startingPosition;

    public List<GameObject> cards = new List<GameObject>();

    void Start()
    {
        startingPosition = transform.position;
    }

    // EXACTLY THE SAME AS ICON JUST WITH CARD INSTEAD
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

        cardObject.transform.position = startingPosition;

        StartCoroutine(Showcase());

    }
    public void Delete()
    {
        Destroy(cardObject);
    }

    public void CardShow()
    {
        hovered = true;

    }

    public void CardUnshow()
    {
        hovered = false;
    }

    private IEnumerator Showcase()
    {

        while (true)
        {
            if (cardObject != null)
            {
                transform.position = cardObject.transform.position;
            }

            Vector3 showcasePosition = new Vector3(0f, 0.44f, 0f);

            float time = 0f;

            time += Time.deltaTime * 10;

            float progress = Mathf.Clamp(time, 0, 1);

            if (hovered == true)
            {
                cardObject.transform.position = Vector3.Lerp(cardObject.transform.position, showcasePosition, progress);
            }
            else
            {
                cardObject.transform.position = Vector3.Lerp(cardObject.transform.position, startingPosition, progress);
            }

            yield return null;
        }

    }

}
