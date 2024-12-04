/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    private Vector2 direccion;
    private Vector2 direccionInicial;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direccionInicial=transform.position;

        do
        {
            direccion.x = Random.Range(-1, 2);

        } while (direccion.x == 0);


        direccion.y = Random.Range(-1, 2);



    }

    // Update is called once per frame
    public void ResetPosition()
    {

        transform.position = direccionInicial;


    }


    private void FixedUpdate()
    {
        rb.velocity = direccion * speed;

    }

   private void OnCollisionEnter(Collision collision)
    {
        // cada vez que ocurra una colision, reboto


        if(collision.gameObject.GetComponent<PalaMovement>()) {
            direccion.x *= -1;
            direccion.y = Random.Range(-1, 2);
        }
        else {

            //Solo se puede con techo o suelo

            direccion.y *= -1;

        }
      
        


    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private Vector2 direccion;
    private Vector2 direccionInicial;
    public AudioClip pongAudioClip;

    // Velocidad mínima en el eje Y para evitar botes pequeños
    public float minYVelocity = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direccionInicial = transform.position;

        // Inicializa la dirección al principio
        ResetDirection();
    }

    // Reinicia la posición y la dirección de la pelota
    public void ResetPosition()
    {
        transform.position = direccionInicial;
        ResetDirection();
    }

    private void FixedUpdate()
    {
        // Aplica la velocidad en la dirección actual
        rb.velocity = direccion * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detecta colisiones con las palas
        if (collision.gameObject.GetComponent<PalaMovement>())
        {
            // Invierte la dirección en X (rebote horizontal)
            direccion.x *= -1;

            // Cambia la dirección en Y con un valor mínimo
            direccion.y = Random.Range(-1f, 1f);
            if (Mathf.Abs(direccion.y) < minYVelocity)
            {
                direccion.y = minYVelocity * Mathf.Sign(direccion.y);
            }
        }
        else
        {
            // Colisión con techo o suelo: invierte la dirección en Y (rebote vertical)
            direccion.y *= -1;
        }

        AudioManager.instance.PlayAudio(pongAudioClip,"PongEffect", 0.3f);

        // Normaliza la dirección para mantener la velocidad constante
        direccion = direccion.normalized;
    }

    private void ResetDirection()
    {
        // Genera una dirección inicial aleatoria para la pelota
        do
        {
            direccion.x = Random.Range(-1, 2);
        } while (direccion.x == 0);

        direccion.y = Random.Range(-1f, 1f);

        // Si la dirección en Y es demasiado pequeña, ajusta al mínimo
        if (Mathf.Abs(direccion.y) < minYVelocity)
        {
            direccion.y = minYVelocity * Mathf.Sign(direccion.y);
        }

        direccion = direccion.normalized; // Asegura que la dirección tenga magnitud 1
    }
}
