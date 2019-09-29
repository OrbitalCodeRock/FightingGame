using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Selection : MonoBehaviour {

    public AudioSource soundSource;

    public GameObject gameManager;
    public GameObject selectSquare;
    public GameObject selectSquarePlaceholder;

    public Transform selectSquarePlaceholders;

    public GameObject[] placeHolders = new GameObject[8];
    public Sprite[] fighterSprites = new Sprite[8];

    public int fighterIndex = 1;
    public int mapIndex = 0;

    public bool fighterSelect = true;
    public bool mapSelect = false;
    private bool done = false;
    // Use this for initialization
    void Start()
    {

        for (int r = 0; r < 2; r++) 
        {
            for (int c = 0; c < 4; c++)
            {
                GameObject b = Instantiate(selectSquarePlaceholder, selectSquarePlaceholders);
                b.GetComponent<Transform>().position = new Vector3(-2.27f + c * 2f, -3.23f + r * -1.8f, -1);
                placeHolders[c + (r * 4)] = b;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (fighterSelect)
        {
            this.GetComponent<SpriteRenderer>().sprite = fighterSprites[fighterIndex];
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (fighterIndex == 7) fighterIndex = 0;
                else fighterIndex += 1;
                soundSource.Play();
                selectSquare.GetComponent<Transform>().position = placeHolders[fighterIndex].GetComponent<Transform>().position;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (fighterIndex == 0) fighterIndex = 7;
                else fighterIndex -= 1;
                soundSource.Play();
                selectSquare.GetComponent<Transform>().position = placeHolders[fighterIndex].GetComponent<Transform>().position;

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (fighterIndex >= 4) fighterIndex -= 4;
                else fighterIndex += 4;
                soundSource.Play();
                selectSquare.GetComponent<Transform>().position = placeHolders[fighterIndex].GetComponent<Transform>().position;

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (fighterIndex <= 3) fighterIndex += 4;
                else fighterIndex -= 4;
                soundSource.Play();
                selectSquare.GetComponent<Transform>().position = placeHolders[fighterIndex].GetComponent<Transform>().position;

            }
            if(Input.GetKeyDown(KeyCode.L))fighterSelect = false;
        }
        else if (mapSelect){
            
            if (!done)
            {
                mapIndex = 0;
                GameObject x = Instantiate(gameManager.GetComponent<Manager>().maps[mapIndex], new Vector3(0.02f, -3.15f, -2.2f), Quaternion.identity);
                done = true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                mapIndex++;
                soundSource.Play();
                if (mapIndex >= gameManager.GetComponent<Manager>().maps.Length) mapIndex = 0;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                mapIndex--;
                soundSource.Play();
                if (mapIndex < 0) mapIndex = gameManager.GetComponent<Manager>().maps.Length - 1;
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                gameManager.GetComponent<Manager>().p2Map = mapIndex;
                mapSelect = false;
            }

        }

    }
}

