using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamera : MonoBehaviour
{
    // Objeto a ser seguido
    public GameObject targetObject;
    // Variavel para auxiliar a mudan�a de posi��o da c�mera para melhorar o �ngulo
    private Vector3 offset;

    void Start()
    {
        // Salva o offset entre o objeto e a c�mera
        offset = transform.position - targetObject.transform.position;
    }

    // Atualiza a posi��o da c�mera com base no objeto referenciado
    void Update()
    {
        transform.position = targetObject.transform.position + offset;
    }
}
