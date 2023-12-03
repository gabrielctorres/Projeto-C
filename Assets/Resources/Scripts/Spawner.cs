using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timer;
    [SerializeField] private float controlTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.fixedDeltaTime;
        if(timer > controlTime) 
        {
            
        }
    }

    private void ChooseEnemy() 
    {
        int x = Random.Range(0, 3);
    }
}
