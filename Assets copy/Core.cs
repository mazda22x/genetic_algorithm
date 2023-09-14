using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Core : MonoBehaviour
{
    public static string TAG = "INDIVID";

    public GameObject prefab;
    public Tilemap tilemap;
    public int CreationSpeed = 100;

    Unit[] population;

    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        StartCoroutine("createIndivid");

    }

    void fitness()
    {
        var individs = GameObject.FindGameObjectsWithTag(TAG);
        var dnaSum = 0;
        foreach (var item in individs)
        {
            dnaSum += item.GetComponent<Unit>().calcDNA();
        }
        Debug.Log($"Individs: {individs.Length}| DNA sum: {dnaSum}| Fitness: {(float)dnaSum / (10 * individs.Length) * 100}%");
    }

    int[] getRandomDNA()
    {
        int[] dna = new int[10];
        for (int i = 0; i < 10; i++)
        {
            dna[i] = Random.Range(0, 2);
        }
        return dna;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator createIndivid()
    {
        while (true)
        {
            var obj = Instantiate(prefab, new Vector3(0, 0), Quaternion.identity);
            obj.GetComponent<Unit>().Init(getRandomDNA());
            obj.tag = TAG;
            tilemap.GetComponent<TileMapCore>().PlaceUnit(obj);

            fitness();
            yield return new WaitForSeconds(CreationSpeed / (float)1000);
        }
    }
}
