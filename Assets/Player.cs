using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Vector2 touchPosition;
    public Camera arCamera;
    public TextMeshPro text;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);

                RaycastHit hitObject;

                if (Physics.Raycast(ray, out hitObject, Mathf.Infinity))
                {
                    GameObject target = hitObject.collider.gameObject;

                    
                    Debug.Log(target.name);
                    Mole mole = target.GetComponent<Mole>();

                    mole.hitMole();
                    score++;
                    text.text = "Score: " + score;

                }

            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            var ray = arCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                GameObject target = hit.collider.gameObject;
                Debug.Log(target.name);
                Mole mole = target.GetComponent<Mole>();

                mole.hitMole();
                score++;
                text.text = "Score: " + score;


            }
        }

    }
}
