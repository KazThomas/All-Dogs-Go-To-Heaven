using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum LevelState {START, PLAYERTURN, FEARTURN, WON, LOST }
public class MoveSystem : MonoBehaviour
{
    [SerializeField] private LevelState state;
    [SerializeField] private GameManager gm;

    private bool isFound = false;
    
    private GameObject dog;
    private GameObject bed;

    private GameObject[] fearObjs;

    [SerializeField] private TextMeshProUGUI phaseOrder;
    // Start is called before the first frame update
    void Start()
    {
        state = LevelState.START;
        phaseOrder.text = state.ToString();
        //grid = GetComponent<GridManager>();
        dog = GameObject.FindGameObjectWithTag("Dog");
        bed = GameObject.FindGameObjectWithTag("Bed");
        fearObjs = GameObject.FindGameObjectsWithTag("Fear");

        if (dog == null)
        {
            Debug.LogError("Dog object is null");
        }

        if (bed == null)
        {
            Debug.LogError("Bed object is null");
        }

        StartCoroutine(PlayerTurn());
    }

    public void EndPlayerTurn()
    {
        state = LevelState.FEARTURN;
        phaseOrder.text = state.ToString();
        StartCoroutine(FearTurn(0.6f));
    }

    IEnumerator PlayerTurn()
    {
        while (!isFound)
        {
            gm.actionsPerTurn += 1;
            state = LevelState.PLAYERTURN;
            phaseOrder.text = state.ToString();
            dog = GameObject.FindGameObjectWithTag("Dog");

            for (int i = 0; i < gm.avilableSlots.Length; i++)
            {
                gm.DrawCard();
            }

           
            float winDist = Vector3.Distance(dog.transform.position, bed.transform.position);

            yield return new WaitForSeconds(1f);
            if (winDist <= 0.5f)
            {
                state = LevelState.WON;
                StartCoroutine(EndScreen());
            }

            foreach (GameObject hoover in fearObjs)
            {
                float loseDist = Vector3.Distance(hoover.transform.position, dog.transform.position);
                if (loseDist < 0.5)
                {
                    isFound = true;
                }
            }
        }

        if (isFound)
        {
            Debug.Log("IS FOUND!");
            state = LevelState.LOST;
            yield return new WaitForSeconds(0.6f);
            StartCoroutine(EndScreen());
        }
    }

    IEnumerator FearTurn(float delay)
    {
        state = LevelState.FEARTURN;
        phaseOrder.text = state.ToString();

        if (delay != 0f) 
        {
            yield return new WaitForSeconds(delay);

            
            foreach (GameObject hoover in fearObjs)
            {
                int dir = Random.Range(1, 5);

                Vector3 direction;
                switch (dir) //fear behavioud 'AI'
                {
                    case 1:
                        direction = new Vector3(0, 1, 0);
                        break;
                    case 2:
                        direction = new Vector3(1, 0, 0);
                        break;
                    case 3:
                        direction = new Vector3(0, -1, 0);
                        break;
                    case 4:
                        direction = new Vector3(-1, 0, 0);
                        break;
                    default:
                        direction = Vector3.zero;
                        break;
                }

                hoover.GetComponent<FearMovement>().MovePoint(direction);
                float fearDist = Vector3.Distance(hoover.transform.position, dog.transform.position);

                if (fearDist <= 0.5f)
                {
                    isFound = true;
                    Debug.Log("Is Found!");
                }
            }
            if (isFound)
            {
                state = LevelState.LOST;
                StartCoroutine(EndScreen());
            }
            else
            {
                yield return new WaitForSeconds(2f);
                StartCoroutine(PlayerTurn());

            }
        }
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
        ResetLevel();
    }

    private void LoadWinScreen()
    {
        SceneManager.LoadScene("Win Screen");
    }

    private void LoadLoseScreen()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene("Gameplay Loop");
    }
}
