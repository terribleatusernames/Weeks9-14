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

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Interact(InputAction.CallbackContext context)

    {

        if (context.performed)
        {
            SpawnIcon();
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

    public void SpawnIcon()
    {
        Destroy(iconObject);

        icon = Random.Range(0, icons.Count);

        iconObject = Instantiate(icons[icon], transform.position, transform.rotation);

        startingPosition = transform.position;

        StartCoroutine(Showcase());

    }

    public void Delete()
    {
        Destroy(iconObject);
    }

    private IEnumerator Showcase()
    {

        while (true)
        {
            if (iconObject != null)
            {
                transform.position = iconObject.transform.position;
            }

            Vector3 showcasePosition = new Vector3(0f, 0.44f, 0f);

            float time = 0f;

            time += Time.deltaTime *4;

            float progress = Mathf.Clamp(time, 0, 1);

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
