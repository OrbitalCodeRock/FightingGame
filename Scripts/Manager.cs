using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
    public GameObject p1;
    public GameObject p2;
    public GameObject[] Characters;
    public GameObject p1MapBox;
    public GameObject p2MapBox;
    public Text p1Text;
    public Text p2Text;
    public GameObject[] maps;

    public int p1Index;
    public int p2Index;


    public bool done = false;
    int x = 0;
    

    public int p1Map = -1;
    public int p2Map = -1;

    //these gameobjects are deleted in the update function
    public GameObject p1Box;
    public GameObject p2Box;
    public GameObject playerIcons;
    public GameObject iconOutline;
    public GameObject iconPlaceholders;

    private Color[] textColors = new Color[8];

    private Color p1Color;
    private Color p2Color;

    // Use this for initialization 
    public void loadLevel(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void Start()
    {
        textColors[0] = Color.red; textColors[1] = Color.blue; textColors[2] = new Color(0.905f, 0.109f, 0.85f); textColors[3] = Color.white; textColors[4] = Color.green; textColors[5] = Color.yellow; textColors[6] = new Color(0.458f, 0.129f, 0.768f); textColors[7] = new Color(0.109f, 0.905f, 0.509f);

    }

    public void Update()
    {

        if (SceneManager.GetActiveScene().name.Equals("CharacterSelect"))
        {
            if(!done)
            {
                if (((p1.GetComponent<P1Selection>() != null && (!p1.GetComponent<P1Selection>().fighterSelect && !p2.GetComponent<P2Selection>().fighterSelect)) && done == false))
                {
                    p1Color = textColors[p1.GetComponent<P1Selection>().fighterIndex];
                    p2Color = textColors[p2.GetComponent<P2Selection>().fighterIndex];
                    Instantiate(p1MapBox); Instantiate(p2MapBox);
                    Destroy(p1Box); Destroy(p2Box); Destroy(playerIcons); Destroy(iconOutline); Destroy(iconPlaceholders);
                    p1.GetComponent<P1Selection>().mapSelect = true;
                    p2.GetComponent<P2Selection>().mapSelect = true;
                    p1Index = p1.GetComponent<P1Selection>().fighterIndex;
                    p2Index = p2.GetComponent<P2Selection>().fighterIndex;
                    done = true;

                }
                else { p1Text.color = textColors[p1.GetComponent<P1Selection>().fighterIndex]; p2Text.color = textColors[p2.GetComponent<P2Selection>().fighterIndex]; }
            }
                if (p1Map != -1 && p2Map != -1)
                {
                    int x = Random.RandomRange(0, 2);
                    if (x == 0)
                    {
                        
                        DontDestroyOnLoad(this.gameObject);
                        SceneManager.LoadScene("Map" + p1Map);
                    }
                    else
                    {
                        
                        DontDestroyOnLoad(this.gameObject);
                        SceneManager.LoadScene("Map" + p2Map);
                    }
                }
        }
        else if (!SceneManager.GetActiveScene().name.Equals("MainMenu"))
        { 
            while (x == 0) {
                p1 = Instantiate(Characters[p1Index]);
                p1.tag = "Player1";
                p2 = Instantiate(Characters[p2Index], new Vector3(6.98f, -3.57f, -1f), Quaternion.Euler(0,180,0));
                p2.tag = "Player2";
                x++;
            }
        }
    }
}
