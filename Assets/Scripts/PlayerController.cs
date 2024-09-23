using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntidadeController
{
    private float minimoY = -4.3f;
    private float maximoY = 4.3f;
    private float minimoX = -8.22f;
    private float maximoX = 8.22f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HP = 2;
        controladorTiro = 0.5f;
        velocidade = 5f;
    }

    // Update is called once per frame
    void Update()
    {

		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
        Vector2 minhaVelocidade = new Vector2(horizontal, vertical);
        minhaVelocidade.Normalize();
		rb.velocity =  minhaVelocidade * velocidade;

        // instanciando o tiro e controlando o intervalo de tempo entre os tiros
        if (controladorTiro > 0f)
        {
			controladorTiro -= 1f * Time.deltaTime;
		}
        if (Input.GetKey(KeyCode.Space))
        {
			atirar(tiro, 0.5f, +0.85f);	
		}

        controlarLimites();
        destruirTiro();
	}


	void destruirTiro()
	{
		if (tiro.transform.position.y > 5.2f)
		{
			Debug.Log("teste");
			Destroy(tiro);
		}
	}

    void controlarLimites()
    {
        if (transform.position.y > maximoY)
        {
            transform.position = new Vector3(transform.position.x, maximoY, transform.position.z);
        } else if(transform.position.y < minimoY) {
			transform.position = new Vector3(transform.position.x, minimoY, transform.position.z);
		}
         
        if (transform.position.x > maximoX)
        {
			transform.position = new Vector3(maximoX, transform.position.y, transform.position.z);
		} else if (transform.position.x < minimoX)
        {
			transform.position = new Vector3(minimoX, transform.position.y, transform.position.z);
		}
    }

    

    

}
