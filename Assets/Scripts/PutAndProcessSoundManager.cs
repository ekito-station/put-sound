using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PutAndProcessSoundManager : MonoBehaviour
{
    public GameObject arCamera;
    public float front;
    public GameObject sphereWithEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 GetPos()
    {
        Transform camTran = arCamera.transform;
        Vector3 curPos = camTran.position + front * camTran.forward;
        return curPos;
    }

    public void OnHighPassButtonClicked()
    {
        GameObject sphere = Instantiate(sphereWithEffectPrefab, GetPos(), Quaternion.identity);
        AudioHighPassFilter highPassFilter = sphere.GetComponent<AudioHighPassFilter>();
        highPassFilter.enabled = true;
    }

    public void OnLowPassButtonClicked()
    {
        GameObject sphere = Instantiate(sphereWithEffectPrefab, GetPos(), Quaternion.identity);
        AudioLowPassFilter lowPassFilter = sphere.GetComponent<AudioLowPassFilter>();
        lowPassFilter.enabled = true;
    }

    public void OnEchoButtonClicked()
    {
        GameObject sphere = Instantiate(sphereWithEffectPrefab, GetPos(), Quaternion.identity);
        AudioEchoFilter echoFilter = sphere.GetComponent<AudioEchoFilter>();
        echoFilter.enabled = true;
    }

    public void OnDistortionButtonClicked()
    {
        GameObject sphere = Instantiate(sphereWithEffectPrefab, GetPos(), Quaternion.identity);
        AudioDistortionFilter distortionFilter = sphere.GetComponent<AudioDistortionFilter>();
        distortionFilter.enabled = true;
    }

    public void OnReverbButtonClicked()
    {
        GameObject sphere = Instantiate(sphereWithEffectPrefab, GetPos(), Quaternion.identity);
        AudioReverbFilter reverbFilter = sphere.GetComponent<AudioReverbFilter>();
        reverbFilter.enabled = true;
    }

    public void OnChorusButtonClicked()
    {
        GameObject sphere = Instantiate(sphereWithEffectPrefab, GetPos(), Quaternion.identity);
        AudioChorusFilter chorusFilter = sphere.GetComponent<AudioChorusFilter>();
        chorusFilter.enabled = true;
    }

    public void OnTrashButtonClicked()
    {
        Debug.Log("Clicked Trash Button.");
        SceneManager.LoadScene("PutAndProcessSound");
    }

    public void OnToRecordAndPutSoundButtonClicked()
    {
        SceneManager.LoadScene("RecordAndPutSound");
    }

    public void OnToWalkingRecordAndPutSoundButtonClicked()
    {
        SceneManager.LoadScene("WalkingRecordAndPutSound");
    }
}
