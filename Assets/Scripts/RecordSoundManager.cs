using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordSoundManager : MonoBehaviour
{
    AudioClip audioClip;
    AudioSource audioSource;
    string micName = "null";
    const int samplingFreq = 44100; // サンプリング周波数
    const int maxTime = 300;    // 最大録音時間[s]

    public GameObject recordButton;
    public GameObject recordStopButton;
    public GameObject playButton;
    public GameObject playStopButton;

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
        Debug.Log("Start recording.");
        audioClip = Microphone.Start(deviceName: micName, loop: false, lengthSec: maxTime, frequency: samplingFreq);
        recordStopButton.SetActive(true);
        recordButton.SetActive(false);
    }

    public void OnRecordStopButtonClicked()
    {
        if (Microphone.IsRecording(deviceName: micName) == true)
        {
            Debug.Log("Stop recording.");
            Microphone.End(deviceName: micName);
            recordButton.SetActive(true);
            recordStopButton.SetActive(false);
        }
        else
        {
            Debug.Log("Not recording.");
        }
    }

    public void OnPlayButtonClicked()
    {
        Debug.Log("Start playing.");
        audioSource.clip = audioClip;
        audioSource.Play();
        // playStopButton.SetActive(true);
        // playButton.SetActive(false);
    }

    // public void OnPlayStopButtonClicked()
    // {
    //     if (audioSource.isPlaying)
    //     {
    //         Debug.Log("Stop playing.");
    //         audioSource.Stop();
    //     }
    // }
}
