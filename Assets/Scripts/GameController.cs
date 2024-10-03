using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textHP;
	[SerializeField] private TextMeshProUGUI textScore;
	[SerializeField] private TextMeshProUGUI textLevel;
	private PlayerController player;
    private int HP;
    [SerializeField]private int score = 0;
    [SerializeField]private int level = 1;
    [SerializeField]private float tempoEspera = 3f;
    [SerializeField] private GameObject[] inimigos;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
		HP = player.GetComponent<PlayerController>().getHP();
	}

    // Update is called once per frame
    void Update()
    {
        controlarTexto();
        criarInimigos();
    }

    void controlarTexto()
    {
		if (player)
		{
			HP = player.GetComponent<PlayerController>().getHP();
			textHP.text = "HP: " + HP;
            textLevel.text = level.ToString();
            textScore.text = "Score: " + score.ToString();
		}
	}

    void criarInimigos()
    {
        tempoEspera -= Time.deltaTime;
        Vector3 posicao;
        if (tempoEspera <= 0)
        {
            for (int i = 0; i < level + 2; i++)
            {
                posicao = new Vector3(Random.Range(-8, 8), Random.Range(6, 15f), transform.position.z);
				int controladorInimigos = Random.Range(0, level);
                if (controladorInimigos >= 2)
                {
					Instantiate(inimigos[1], posicao, transform.rotation);
				} else
                {
					Instantiate(inimigos[0], posicao, transform.rotation);
				}
			}
			tempoEspera = 5f;
		}
    }

    public void aumentarScore(int score)
    {
        this.score += score;
        if (this.score > level + 50)
        {
            level++;
        }
    }



}
