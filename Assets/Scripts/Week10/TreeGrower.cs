using JetBrains.Annotations;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class TreeGrower : MonoBehaviour
{
    public AnimationCurve growCurve;
    public Transform appleSpawnPoint;
    public float maxSpawnDistance = 2f;
    public float duration = 5f;
    public float appleGrowDuration = 2f;
    public GameObject applePrefab;

    private Coroutine treeCoroutine;
    private Coroutine appleCoroutine;
    void Start()
    {

    }


    void Update()
    {


       

    }
    private IEnumerator TreeGrowUpdate()
    {
        float progress = 0f;

        while (progress < duration)
        {
            progress += Time.deltaTime;
            transform.localScale = Vector3.one * growCurve.Evaluate(progress / duration);

            yield return null;
        }

        StartCoroutine(AppleGrowUpdate());
    }

    private IEnumerator AppleGrowUpdate()
    {
        Vector3 spawnPosition = appleSpawnPoint.position;
        spawnPosition += (Vector3)UnityEngine.Random.insideUnitCircle * maxSpawnDistance;

        GameObject spawnedApple = Instantiate(applePrefab, spawnPosition, Quaternion.identity);
    spawnedApple.transform.localScale = Vector3.zero;
        float progress = 0f;

        while(progress<appleGrowDuration)
        {
            progress += Time.deltaTime;
            spawnedApple.transform.localScale = Vector3.one* growCurve.Evaluate(progress / appleGrowDuration) * 1;
            yield return null;
        }

        appleCoroutine = StartCoroutine(AppleGrowUpdate());
        yield return appleCoroutine;

        appleCoroutine = StartCoroutine(AppleGrowUpdate());
        yield return appleCoroutine;

        //yield return new WaitForSeconds(appleGrowDuration);
    }


public void StartGrowing()
    {
       treeCoroutine = StartCoroutine(TreeGrowUpdate());
    }

    public void OnStopPress()
    {
        if (treeCoroutine != null)
        {
            StopCoroutine(treeCoroutine);
        }

        if (appleCoroutine != null)
        {
            StopCoroutine(appleCoroutine);
        }

    }
}
