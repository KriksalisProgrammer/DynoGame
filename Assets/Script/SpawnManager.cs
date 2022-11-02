using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Todo List<objects> cactus and other obstacles
    public GameObject enemyPrefab;
    private Vector3 spawnPosition = new Vector3(5, 2.9f, 0);

    private float startDelay = 2;
    private float repeatRate = 2;
   

    private PlayerControl _playerControl;

    private void Start()
    {
        
        InvokeRepeating(nameof(SpawnLandscape), startDelay, repeatRate);
        _playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
    }
    
    private void SpawnLandscape()
    {
        if (_playerControl._Dead == false)
            Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
    }
    

}
