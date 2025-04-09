using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }   

    // Update is called once per frame
    public void GoToLevel()
    {
        Debug.Log("Botão clicado!");
        SceneManager.LoadScene("SampleScene");
    }
}
