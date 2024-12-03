using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum LevelState {START, PLAYERTURN, FEARTURN, WON, LOST }
public class MoveSystem : MonoBehaviour
{
    [SerializeField] private LevelState state;
    [SerializeField] private GridManager grid;
    [SerializeField] private GameManager gm;

    private bool isFound = false;
    
    private GameObject dog;
    private GameObject bed;
    private Tile fear;
    private List<Tile> fearList; // = new List<Tile>();
    private float winDist;
    // Start is called before the first frame update
    void Start()
    {
        state = LevelState.START;
        grid = GetComponent<GridManager>();
        dog = GameObject.FindGameObjectWithTag("Dog");
        bed = GameObject.FindGameObjectWithTag("Bed");
        StartCoroutine(PlayerTurn());
        fearList = grid.getObjects();
        if (fearList != null)
        {
            fear = fearList.Find(obj => obj.tag == "Fear");
        }
    }

    IEnumerator Wipe()
    {
        grid.GenerateGrid();

        yield return new WaitForSeconds(1f);
        state = LevelState.PLAYERTURN;
        StartCoroutine(PlayerTurn());
    }

    IEnumerator PlayerTurn()
    {
       
        int handSize = 4;
        for (int i = 0; i < handSize; i++)
        {
            gm.DrawCard();
        }
        winDist = Vector3.Distance(dog.transform.position, bed.transform.position);
        //add in play card logic here

        yield return new WaitForSeconds(1f);
        if (winDist <= 0.5f) 
        {
            state = LevelState.WON;
            StartCoroutine(EndScreen());
        }
        state = LevelState.FEARTURN;
        StartCoroutine(FearTurn());
    }

    IEnumerator FearTurn()
    {
        //Fear behaviour AI thing goes here
        float fearDist = Vector3.Distance(fear.transform.position, dog.transform.position);
        
        if (fearDist <= 0.5f)
        {
            isFound = true;
        }

        if (isFound)
        {
            state = LevelState.LOST;
            StartCoroutine (EndScreen());
        }
        yield return new WaitForSeconds(2f);
    }

    IEnumerator EndScreen()
    {
        if (state == LevelState.LOST)
        {
            LoadLoseScreen();
        }
        else if (state == LevelState.WON)
        {
            LoadWinScreen();
        }
        yield return new WaitForSeconds(3f);
    }

    private void LoadWinScreen()
    {
        SceneManager.LoadScene("Win Screen");
    }

    private void LoadLoseScreen()
    {
        //add in lose screen here
    }
}
