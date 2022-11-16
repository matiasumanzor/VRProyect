using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFController : MonoBehaviour
{
    CharacterController characterController;
    public float velocidad_caminar=6.0f;
    public float velocidad_correr=10.0f;
    public float velocidad_salto=8.0f;
    public float gravedad =70.0f;
    private Vector3 movimiento = Vector3.zero;
    public float vida;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        vida = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(characterController.isGrounded){
            movimiento= new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            if(Input.GetKey(KeyCode.LeftShift)){
                movimiento = transform.TransformDirection(movimiento)* velocidad_correr; 
            }
            else{
                movimiento = transform.TransformDirection(movimiento)* velocidad_caminar;
            }
            if(Input.GetKey(KeyCode.Space)){
                movimiento.y = velocidad_salto;
            }
            
        }
        movimiento.y -= gravedad * Time.deltaTime;
        characterController.Move(movimiento*Time.deltaTime);
    }


    void OnTriggerEnter(Collider obj){
        if (obj.tag=="Vida"){
            vida += 5.0f;
            Destroy (obj.gameObject);
        }
        if (obj.tag=="Malo"){
            vida -= 5.0f;
            Destroy (obj.gameObject);
        }
    }

    void OnTriggerStay(Collider obj){
        if (obj.tag=="Mantener"){
            vida -= 1.0f;
        }
    }

    void OnTriggerExit(Collider obj){
        if (obj.tag=="Desaparecer"){
            vida -= 1.0f;
        }
    }
    
}
