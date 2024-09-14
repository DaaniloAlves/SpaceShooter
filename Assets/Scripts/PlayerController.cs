using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float velocidade = 5f;
    private Rigidbody2D rb;
    [SerializeField] private GameObject tiro;
    private int HP;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		//if (Input.GetKey(KeyCode.W))
		//{
		//    transform.position = new Vector3(transform.position.x,transform.position.y * velocidade * Time.deltaTime, transform.position.z);
		//}

		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
        Vector2 minhaVelocidade = new Vector2(horizontal, vertical);
        minhaVelocidade.Normalize();
		rb.velocity =  minhaVelocidade * velocidade;
        atirar();
        destruirTiro();
	}

    void atirar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(tiro, new Vector3(transform.position.x, transform.position.y + 0.85f, transform.position.z), Quaternion.identity);
        }
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
