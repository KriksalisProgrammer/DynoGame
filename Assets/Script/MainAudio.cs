using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudio : MonoBehaviour
{
    private AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void GameOver()
    {
        source.Stop();
    }
}
