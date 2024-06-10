using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomCar : MonoBehaviour
{
    [SerializeField] private GameObject[] cars;
    private int carNumber;
    [SerializeField] private float maxPos = 2.12f;
    [SerializeField] private float delayTimer = 1f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = delayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Vector3 carPos = new Vector3(Random.Range(-maxPos, maxPos), transform.position.y, transform.position.z);
            carNumber = Random.Range(0, 5);
            Instantiate(cars[carNumber], carPos, transform.rotation);
            timer = delayTimer;
            
        }
        
        
    }
}
