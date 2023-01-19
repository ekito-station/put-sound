using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WalkingRecordAndPutSoundManager : MonoBehaviour
{
    Coroutine walkingRecord;
    public float waitSec;

    AudioClip audioClip;
    AudioSource audioSource;
    string micName = "null";
    const int samplingFreq = 44100; // サンプリング周波数
    const int maxTime = 300;    // 最大録音時間[s]

    public GameObject recordButton;
    public GameObject recordStopButton;

    public GameObject arCamera;
    Vector3 curPos;
    public float back;
    public GameObject soundSpherePrefab;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        foreach (string device in Microphone.devices)
        {
            Debug.Log("Device Name: " + device);
            micName = device;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRecordButtonClicked()
    {
        walkingRecord = StartCoroutine("WalkingRecord");
        recordStopButton.SetActive(true);
        recordButton.SetActive(false);
    }

    public void OnRecordStopButtonClicked()
    {
        StopCoroutine(walkingRecord);
        recordButton.SetActive(true);
        recordStopButton.SetActive(false);
    }

    private IEnumerator WalkingRecord()
    {
        while (true)
        {
            StartRecording();
            yield return new WaitForSeconds(waitSec);
            StopRecording();
        }
    }

    public void StartRecording()
    {
        Debug.Log("Start recording.");
        audioClip = Microphone.Start(deviceName: micName, loop: false, lengthSec: maxTime, frequency: samplingFreq);
    }

    public void StopRecording()
    {
        if (Microphone.IsRecording(deviceName: micName) == true)
        {
            Debug.Log("Stop recording.");
            Microphone.End(deviceName: micName);

            Transform camTran = arCamera.transform;
            curPos = camTran.position - back * camTran.forward;
            GameObject soundSphere = Instantiate(soundSpherePrefab, curPos, Quaternion.identity);
            Debug.Log("Placed SoundSphere.");

            audioSource = soundSphere.GetComponent<AudioSource>();
            audioSource.clip = audioClip;
        }
        else
        {
            Debug.Log("Not recording.");
        }
    }

    public void OnChangeSceneButtonClicked()
    {
        SceneManager.LoadScene("RecordAndPutSound");
    }
}
