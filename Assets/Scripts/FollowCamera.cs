using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    //Variavel para auxiliar a mudan�a de posi��o da c�mera para melhorar o angulo
    public Vector3 offset;

    void Update()
    { 
        //Define a posi��o da c�mera como o objeto que for referenciado
        transform.position = target.position + offset;
    }  
}
