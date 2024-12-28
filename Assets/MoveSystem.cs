using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private GameObject[] fearObjs;

    private float winDist;

    [SerializeField] private TextMeshProUGUI phaseOrder;
    // Start is called before the first frame update
    void Start()
    {
        state = LevelState.START;
        phaseOrder.text = state.ToString();
        grid = GetComponent<GridManager>();
        dog = GameObject.FindGameObjectWithTag("Dog");
        bed = GameObject.FindGameObjectWithTag("Bed");
        fearObjs = GameObject.FindGameObjectsWithTag("Fear");
        StartCoroutine(PlayerTurn());
        
        fearList = grid.getObjects();
        if (fearList != null)
        {
            fear = fearList.Find(obj => obj.tag == "Fear");
        }
    }

    public void EndPlayerTurn()
    {
        state = LevelState.FEARTURN;
        phaseOrder.text = state.ToString();
        Invoke("FearTurn", 2f);
        StartCoroutine(FearTurn(0.6f));
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
        gm.actionsPerTurn += 1;
        state = LevelState.PLAYERTURN;
        phaseOrder.text = state.ToString();

        for (int i = 0; i < gm.avilableSlots.Length; i++)
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
    }

    private void LoadWinScreen()
    {
        SceneManager.LoadScene("Win Screen");
    }

    private void LoadLoseScreen()
    {
        SceneManager.LoadScene("Lose Screen");
    }
}
