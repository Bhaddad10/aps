using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlataforma : MonoBehaviour
{
    public float velocidade = 2.0f; // velocidade da plataforma
    public float direcao = 1.0f; // come�a positiva
    public float positiveRange = 1f, negativeRange = -1f; // vari�veis para in�cio/fim do movimento

    void Update()
    {
        // nova posicao de plataforma
        float mov = velocidade * Time.deltaTime * direcao;

        // nova posicao de plataforma no eixo especifico
        float nova_pos = transform.position.x + mov;

        if (nova_pos >= positiveRange ||
            nova_pos <= negativeRange)
        {
            direcao *= -1; // invertemos a dire��o do movimento
        }
        else
        {
            transform.position += new Vector3(mov, 0, 0); // plataforma vai para nova posi��o
        }
    }
}
