using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickTrashButton()
    {
        Debug.Log("Clicked Trash Button.");
        SceneManager.LoadScene("Home");
        Debug.Log("Reloaded home.");
    }
}
