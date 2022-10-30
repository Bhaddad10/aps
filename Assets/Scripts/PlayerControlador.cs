using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlador: MonoBehaviour
{
    Rigidbody _rigidbody;

    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask ground;

    public float speed = 10f; // velocidade do player
    public float jumpForce = 5f; // for�a do pulo
    Vector3 posicaoInicial; // posi��o inicial do player
    
    public int coins = 0; // vari�vel p�blica para poder inspecionar no unity
    public Text finishText; // elemento de texto de vit�ria
    public Text coinsText; // elemento de texto de moedas coletadas

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        // armazena posi��o inicial para poss�vel reset
        posicaoInicial = transform.position;
    }

    private void Update()
    {
        // Movimenta��o do Player
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _rigidbody.velocity = new Vector3(horizontal * speed, _rigidbody.velocity.y, speed);

        // Pulo do player
        // Se est� pressionando bot�o de pulo, e n�o est� no ch�o
        if ((Input.GetButtonDown("Jump") || vertical == 1) && isGrounded())
        {
            jump();
        }
    }

    // M�todo que realiza o pulo do player
    void jump()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, jumpForce, _rigidbody.velocity.z);
    }

    // M�todo retorna se player est� no ch�o
    bool isGrounded()
    {
        return Physics.CheckSphere(groundChecker.position, 0.1f, ground);
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Ao colidir com um objeto
        GameObject other = collision.gameObject;
;

        // Se for um espinho, reseta o jogador para posi��o inicial
        if (other.CompareTag("Spike"))
        {
            ResetLevel();
        }

        // Se for uma moeda, coleta-a
        if (other.CompareTag("Coin"))
        {
            GetCoin(other);
        }

        // Se for a linha de chegada, exibe texto de finaliza��o da fase
        if (other.CompareTag("Finish"))
        {
            coinsText.text = coinsText.text.Replace("{coins}", coins.ToString());
            coinsText.gameObject.SetActive(true);
            finishText.gameObject.SetActive(true);
        }
    }

    private void ResetLevel()
    {
        transform.position = posicaoInicial;
    }

    // destr�i a moeda e adiciona ao contador de moedas do player
    private void GetCoin(GameObject other)
    {
        Destroy(other);
        coins++;
    }
}
