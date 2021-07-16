using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public float visibleHeight = 0;
    public float hiddenHeight = -1;
    public float speed = 20.0f;

    public float disappear = 1.5f;
    public float disappearTimer = 0;

    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Awake()
    {

        targetPosition = new Vector3(transform.localPosition.x, hiddenHeight, transform.localPosition.z);

        transform.localPosition = targetPosition;

    }

    // Update is called once per frame
    void Update()
    {
        disappearTimer -= Time.deltaTime;
        if (disappearTimer <= 0f)
        {
            Hide();
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, speed*Time.deltaTime);


        
    }

    public void Rise()
    {

        targetPosition = new Vector3(transform.localPosition.x, visibleHeight, transform.localPosition.z);

        disappearTimer = disappear;

    }

     public void Hide()
    {
        targetPosition = new Vector3(transform.localPosition.x, hiddenHeight, transform.localPosition.z);
    }

    public void hitMole()
    {
        Hide();
    }
}


