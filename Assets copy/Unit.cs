using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Sprite[] spritesArray;

    int[] DNA;

    SpriteRenderer sprRenderer;
    public void Init(int[] dna)
    {
        DNA = new int[dna.Length];
        Array.Copy(dna, DNA, DNA.Length);
        GetComponent<Unit>().enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();

        int dnaCount = calcDNA();
        sprRenderer.sprite = spritesArray[dnaCount > 9 ? 9 : dnaCount];
        if (dnaCount > 9)
            sprRenderer.color = Color.black;

    }

    public int calcDNA()
    {
        int count = 0;
        for (int i = 0; i < DNA.Length; i++)
        {
            count += DNA[i];
        }
        return count;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
