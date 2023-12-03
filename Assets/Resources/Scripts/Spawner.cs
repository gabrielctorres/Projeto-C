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
            //ChooseEnemy();
        }
    }
    private void ChooseEnemy() 
    {
        switch(Random.Range(0, 3)) 
        {
            case 1:
                // coxinha
                break;
            case 2:
                // pastel
                break;
            case 3:
                // bolinha de queijo
                break;
        }
    }
}
