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
    // Start is called before the first frame update
    void Start()
    {
        state = LevelState.START;
        StartCoroutine(PlayerTurn());
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
        yield return new WaitForSeconds(1f);
        state = LevelState.FEARTURN;
        StartCoroutine(FearTurn());
    }

    IEnumerator FearTurn()
    {
        //Fear behaviour AI thing goes here
        
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
