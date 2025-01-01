using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ResetLevel", 4f);
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene("Gameplay Loop");
    }
}
