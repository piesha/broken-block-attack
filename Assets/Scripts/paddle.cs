using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{ 
    //configuration parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float minX = 1f; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float cursorXPosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

        paddlePos.x = Mathf.Clamp(cursorXPosInUnits, minX,maxX);
        transform.position = paddlePos;


    }
}
