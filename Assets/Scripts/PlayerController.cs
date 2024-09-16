using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float velocidade = 5f;
    private Rigidbody2D rb;
    [SerializeField] private GameObject tiro;
    private int HP;
    private float controladorTiro = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
		controladorTiro -= 0.1f;
        if (Input.GetKey(KeyCode.Space) )
        {
			if (controladorTiro <= 0f)
			{
				atirar();
			}
		}	
        
        
        destruirTiro();
	}

    void atirar()
    {
            Instantiate(tiro, new Vector3(transform.position.x, transform.position.y + 0.85f, transform.position.z), Quaternion.identity);
		controladorTiro = 5f;
	}

	void destruirTiro()
	{
		if (tiro.transform.position.y > 5.2f)
		{
			Debug.Log("teste");
			Destroy(tiro);
		}
	}
}
