using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PalaMovement : MonoBehaviour
{

    public bool PalaIzquierda;
    public float speed;
    private Rigidbody2D rb;
    private float y;
    private Camera _cam;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();    
        _cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_STANDALONE || UNITY_EDITOR


        //Para PC
        if (PalaIzquierda)
        {
            y = Input.GetAxisRaw("Vertical");

        }

        else
        {
            y = Input.GetAxisRaw("Vertical2");
        }
        
        
        transform.Translate(new Vector2(0, y) * speed * Time.deltaTime);

#elif UNITY_ANDROID || UNITY_IOS 


        //Para MOVIL:
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Moved)
            {
                //touch.position
                Vector2 screenCoords = touch.position;
                Vector3 worldCoords = _cam.ScreenToWorldPoint(screenCoords);
                transform.position = new Vector3(transform.position.x, worldCoords.y, transform.position.z);
            }
            else if(touch.phase == TouchPhase.Ended){

                GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);

            }
        }



#endif



    }

    private void FixedUpdate()
    {
       
       // rb.velocity = new Vector2(0,y)*speed;
       

    }

}
