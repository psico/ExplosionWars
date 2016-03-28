using UnityEngine;
using System.Collections;

public class PlayerMovimento : MonoBehaviour {

    //Velocidade do jogador
    public float velocidade = 10f;

    //Vetor responsavel pelo movimento
    Vector3 movimento;

    //Responsavel pela transicao de movimentacao
    //Animator anim;

    //Responvavel pela fisica do objeto
    Rigidbody playerRigidbody;

    /**
    * Metodo comum do Unity, ele sempre e chamado quando a aplicacao e iniciada
    **/
    void Awake()
    {
        //Atribuir a mascara da camada
        //floorMask = LayerMask.GetMask("Terrain");

        //Atribuir referencias
        //anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        
    }

    /**
    * Metodo comum do Unity, ele e chamado a cada atualizacao de frame
    **/
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        MovimentacaoPlayer(h, v);
        GirarPlayer(h, v);
    }

    /**
    * Metodo responsavel pela movimentacao do player
    **/
    void MovimentacaoPlayer(float h, float v)
    {
        movimento.Set(h,0f,v); //determina o movimento
        movimento = movimento.normalized * velocidade * Time.deltaTime; //normaliza o movimento
        playerRigidbody.MovePosition(transform.position + movimento); //efetua o movimento do personagem
    }
    
    void GirarPlayer(float h, float v)
    {
        Vector3 playerDirecao = new Vector3(h, 0, v); //cria um vector 3 eixos baseados no q o usuario esta apertando, o 0 é pq nao queremos nos mover para cima e para baixo
        Quaternion newRotation = Quaternion.LookRotation(playerDirecao); //criamos um objeto de rotacao usando o vetor de 3 eixos
        playerRigidbody.MoveRotation(newRotation); //aplicamos a rotacao no player usando a rotacao criada
    }
    

}
