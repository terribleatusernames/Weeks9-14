using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour

{
    private Coroutine cookieCoroutine;
    public Transform cookieSpawnPoint;
    public AnimationCurve growCurve;
    public GameObject cookiePrefab;
    public float cookieGrowDuration = 2f;
    public float maxSpawnDistance = 2f;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CookieGrowerUpdate()
    {
        Vector3 spawnPosition = cookieSpawnPoint.position;
        spawnPosition += (Vector3)UnityEngine.Random.insideUnitCircle * maxSpawnDistance;

        GameObject spawnedCookie = Instantiate(cookiePrefab, spawnPosition, Quaternion.identity);
        spawnedCookie .transform.localScale = Vector3.zero;
        float progress = 0f;

        Button myButton = .GetComponent<Button>();

        while (progress < cookieGrowDuration)
        {
           

            progress += Time.deltaTime;
            spawnedCookie.transform.localScale = Vector3.one * growCurve.Evaluate(progress / cookieGrowDuration) * 1;
            yield return null;
        }


        
    }

    public void SpawnCookie()
    {
        cookieCoroutine = StartCoroutine(CookieGrowerUpdate());

        
    }

}
