using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamera : MonoBehaviour
{
    // Objeto a ser seguido
    public Transform target;
    // Variavel para auxiliar a mudan�a de posi��o da c�mera para melhorar o �ngulo
    public Vector3 offset;

    void Update()
    { 
        // Atualiza a posi��o da c�mera com base no objeto referenciado
        transform.position = target.position + offset;
    }  
}
