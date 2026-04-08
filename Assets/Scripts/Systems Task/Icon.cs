using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.GPUSort;

public class Icon : MonoBehaviour
{

    public List<GameObject> icons = new List<GameObject>();
    GameObject iconObject;
    private int icon = 0;
    public bool hovered;
    Vector3 startingPosition;
    void Start()
    {
       startingPosition = transform.position;

    }

    // TO PREFACE

    // I wrote the code like this because I didn't know we were allowed to use UI. In hind sight I don't know how I mixed that up, but, I was in too deep by the time I realized.
    void Update()
    {
       
    }

    public void Interact(InputAction.CallbackContext context)

    {
        //card spawner. (.performed makes it a held action)
        if (context.performed)
        {
            SpawnIcon();
            Debug.Log("interacted");
        }

    }

    //show and unshow called inside of inspector for unity events
    public void Show()
    {
        hovered = true;

    }

    public void Unshow()
    {
        hovered = false;
    }

    public void SpawnIcon()
    {
        //destroy any cards that are already spawned before spawning a new one
        Destroy(iconObject);

        icon = Random.Range(0, icons.Count);

        iconObject = Instantiate(icons[icon], transform.position, transform.rotation);

        //set the starting position as the spawn position
        iconObject.transform.position = startingPosition;

        //start the hover coroutine
        StartCoroutine(Showcase());

    }

    public void Delete()
    {
        //delete the spawned card
        Destroy(iconObject);
    }

    private IEnumerator Showcase()
    {
        //loop that plays the animation which moves the hovered card to the centre of the screen
        while (true)
        {
            if (iconObject != null)
            {
                transform.position = iconObject.transform.position;
            }

            Vector3 showcasePosition = new Vector3(0f, 1.2f, -1f);

            float time = 0f;

            time += Time.deltaTime * 10 ;

            float progress = Mathf.Clamp(time, 0, 1);

            //if hovered, move to the centre of the screen, if not, move back to the starting position
            if (hovered == true)
            {
                iconObject.transform.position = Vector3.Lerp(iconObject.transform.position, showcasePosition, progress);
            }
            else
            {
                iconObject.transform.position = Vector3.Lerp(iconObject.transform.position, startingPosition, progress);
            }

            yield return null;
        }

    }


}
