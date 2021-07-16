using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector2 touchPosition = default;
    public Camera arCamera;
    public Text text;
    private int score;
    void Start()
    {
        score = 0;
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

                   if (target.name == "Burger")
                    {
                        Debug.Log(target.name);
                        Destroy(target.transform);
                        score++;
                        text.text = "Score :" + score;
                    }
                    
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
                Debug.Log(target);
                if (target.tag == "Burger")
                {
                    Destroy(target);
                    score++;
                    text.text = "Score : " + score;




                }
                

            }
        }

    }
}
