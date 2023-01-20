using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PutSoundManager : MonoBehaviour
{
    public GameObject arCamera;
    // public GameObject cubePrefab;
    public GameObject markerPrefab;

    public float front;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPutButtonClicked()
    {
        // Vector3 cameraPosition = arCamera.transform.position; // AR Cameraの座標を取得

        Transform camTran = arCamera.transform;
        Vector3 curPos = camTran.position + front * camTran.forward;

        // GameObject markerObject = Instantiate(markerPrefab, cameraPosition, Quaternion.identity);
        GameObject markerObject = Instantiate(markerPrefab, curPos, Quaternion.identity);
        Debug.Log("Placed a marker.");
    }

    public void OnTrashButtonClicked()
    {
        Debug.Log("Clicked Trash Button.");
        SceneManager.LoadScene("PutSound");
        Debug.Log("Reloaded home.");
    }
}
