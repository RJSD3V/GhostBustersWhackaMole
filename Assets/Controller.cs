using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public GameObject MoleContainer;

    public float spawnDuration = 1.5f;
    public float spawnDecrement = 0.1f;
    public float minimumSpawnTime = 0.5f;

    public float spawnTimer = 0f;

    private Mole[] moles;
    // Start is called before the first frame update
    void Start()
    {
        moles = MoleContainer.GetComponentsInChildren<Mole>();

        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            moles[Random.Range(0, moles.Length)].Rise();

            spawnDuration -= spawnDecrement;

            if (spawnDuration < minimumSpawnTime)
            {
                spawnDuration = minimumSpawnTime;
            }

            spawnTimer = spawnDuration;
        }
        
        

        

    }
}
