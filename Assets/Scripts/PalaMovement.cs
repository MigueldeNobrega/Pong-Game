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
    
    
    

    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();    
        
        


    }

    // Update is called once per frame
    void Update()
    {

        if (PalaIzquierda)
        {
            y = Input.GetAxisRaw("Vertical");
        }

        else
        {
            y = Input.GetAxisRaw("Vertical2");
        }


        
        transform.Translate(new Vector2(0, y) * speed * Time.deltaTime);
       

    }

    private void FixedUpdate()
    {
       
       // rb.velocity = new Vector2(0,y)*speed;
       

    }

}
