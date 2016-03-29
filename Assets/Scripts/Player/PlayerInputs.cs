using UnityEngine;
using System.Collections;

public class PlayerInputs : MonoBehaviour {

    public GameObject bomba;
    //public Transform posicaoBomba;
    public GameObject explosion;
    public int qtdBomba = 0;
    public int qtdMaximaBomba = 4;
    public float momentoInstancia;
    public float sizeExplosion = 90f;

    //Metodo padrao do unity que e chamado todo vez que e iniciado a aplicacao	
    void Start()
    {
        //Setamos scale padrado para o tamanho da boma
        bomba.transform.localScale = new Vector3(0.3F, 0.4F, 0.4F);
    }

	// Update is called once per frame
	void Update () {
        //Todo frame e verificado se foi intanciado uma boma
        //instaciarBomba();
        StartCoroutine(instaciarBomba());
    }

    //Instancia uma boma
    IEnumerator instaciarBomba()
    {
        //Pode colocar bomba desde que tenha apertado X no teclado e nao ultrapasse a quantidade maxima de bombas (agora pq o maior e igual tem q ser invertido eu nao sei)
        if (Input.GetKeyDown(KeyCode.X) && qtdMaximaBomba > qtdBomba)
        {
            //Instancia a bomba e incrementa a quantidade permitida
            //var position = posicaoBomba.transform.position;
            var position = this.gameObject.transform.position;            
            var instBomba = Instantiate(bomba, position, Quaternion.Euler(new Vector3(0, 0, 0)));
            qtdBomba = qtdBomba + 1;


            //Explode a bomba e decrementar a quantidade de bombas
            yield return new WaitForSeconds(3);
            Destroy(instBomba);
           
            var instExplosion = (GameObject) Instantiate(explosion, position, Quaternion.Euler(new Vector3(0, 0, 0)));
            defineSizeExplosion(instExplosion, position);

            yield return new WaitForSeconds(1.5f);
            //yield return new WaitForSeconds(0.5f);
            Destroy(instExplosion);
            qtdBomba = qtdBomba - 1;
        }


    }

    void defineSizeExplosion(GameObject explosion, Vector3 position)
    {
        //@TODO arrumar problema do retorno que pode ser false
        GameObject positionBlockX = blocoMaisProximoNaLinhaSegundoPosicao(position);
        Vector3 positionBlockZ = returnBlockColumn(position);

        GameObject explosionRight;
        explosionRight = explosion.transform.FindChild("BombRight").gameObject;
        //float distExplosionRight = (position.y - positionBlockX.y) + 1.5f;
        float scaleExplosionRight = explosionRight.transform.localPosition.y - positionBlockX.transform.localPosition.x;
        Debug.LogWarning(positionBlockX.transform.localPosition.x);
        Debug.LogWarning(explosionRight.transform.localPosition.x);
        explosionRight.transform.localScale = new Vector3(explosionRight.transform.localScale.x, scaleExplosionRight, explosionRight.transform.localScale.z);
        //explosionRight.transform.localPosition = new Vector3(positionBlockX.transform.localPosition.x, explosionRight.transform.localPosition.y, explosionRight.transform.localPosition.z);
        //explosionRight.transform.position = new Vector3(explosionRight.transform.position.x + positionBlockX.transform.position.x, , explosionRight.transform.position.y, explosionRight.transform.position.z);

        /*
        GameObject explosionBottom;
        explosionBottom = explosion.transform.FindChild("BombBottom").gameObject;
        float distExplosionBottom = (position.y - positionBlockZ.y) + 2.5f;
        explosionBottom.transform.localScale = new Vector3(explosionBottom.transform.localScale.x, explosionBottom.transform.localScale.y, distExplosionBottom);
        */
    }

    GameObject blocoMaisProximoNaLinhaSegundoPosicao(Vector3 position)
    {
        
        GameObject feedback = new GameObject();
        
        string result = "undefined";
        if(position.z <= 127.71f && position.z >= 125.70f)
        {
            result = "Linha1";
        }
        if (position.z <= 125.71f && position.z >= 123.70f)
        {
            result = "Linha2";
        }
        if (position.z <= 123.71f && position.z >= 121.70f)
        {
            result = "Linha3";
        }
        if (position.z <= 121.71f && position.z >= 119.70f)
        {
            result = "Linha4";
        }
        if (position.z <= 119.71f && position.z >= 117.70f)
        {
            result = "Linha5";
        }
        if (position.z <= 117.71f && position.z >= 115.70f)
        {
            result = "Linha6";
        }
        if (position.z <= 115.71f && position.z >= 113.70f)
        {
            result = "Linha7";
        }
        if (position.z <= 113.71f && position.z >= 111.70f)
        {
            result = "Linha8";
        }
        if (position.z <= 111.71f && position.z >= 109.70f)
        {
            result = "Linha9";
        }
        if (position.z <= 109.71f && position.z >= 107.70f)
        {
            result = "Linha10";
        }
        if (position.z <= 107.71f && position.z >= 105.70f)
        {
            result = "Linha11";
        }
        if (position.z <= 105.71f && position.z >= 103.70f)
        {
            result = "Linha12";
        }
        if (position.z <= 103.71f && position.z >= 101.70f)
        {
            result = "Linha13";
        }
        if (position.z <= 101.71f && position.z >= 99.70f)
        {
            result = "Linha14";
        }
        if (position.z <= 99.71f && position.z >= 97.7f)
        {
            result = "Linha15";
        }
        
        if (result != "undefined")
        {
            feedback = GameObject.Find(result).transform.GetChild(0).gameObject;
        }
       
        return feedback;
    }

    Vector3 returnBlockColumn(Vector3 position)
    {
        //@TODO arrumar medidas
        string result = "undefined";
        if (position.x >= 86.2f && position.x < 88.2f)
        {
            result = "column1";
        }
        if (position.x >= 88.2f && position.x < 90.2f)
        {
            result = "column2";
        }
        if (position.x >= 90.2f && position.x < 92.2f)
        {
            result = "column3";
        }
        if (position.x >= 92.2f && position.x < 94.2f)
        {
            result = "column4";
        }
        if (position.x >= 94.2f && position.x < 96.2f)
        {
            result = "column5";
        }
        if (position.x >= 96.2f && position.x < 98.2f)
        {
            result = "column6";
        }
        if (position.x >= 98.2f && position.x < 100.2f)
        {
            result = "column7";
        }
        if (position.x >= 100.2f && position.x < 102.2f)
        {
            result = "column8";
        }
        if (position.x >= 102.2f && position.x < 104.2f)
        {
            result = "column9";
        }
        if (position.x >= 104.2f && position.x < 106.2f)
        {
            result = "column10";
        }
        if (position.x >= 106.2f && position.x < 108.2f)
        {
            result = "column11";
        }
        if (position.x >= 108.2f && position.x < 110.2f)
        {
            result = "column12";
        }
        if (position.x >= 110.2f && position.x < 112.2f)
        {
            result = "column13";
        }
        if (position.x >= 112.2f && position.x < 114.2f)
        {
            result = "column14";
        }
        if (position.x >= 114.2f && position.x < 116.2f)
        {
            result = "column15";
        }

        GameObject[] arr = GameObject.FindGameObjectsWithTag(result);
        Vector3 feedback = new Vector3(0,0,0);

        foreach (GameObject value in arr)
        {
            if (value.transform.parent.parent.position.z >= feedback.z)
            {
                feedback = value.transform.parent.parent.position;
                //aux = value.transform.parent.parent.gameObject;
            }
        }

        return feedback;
    }

    /*Vector3 positionByCoordinates()
    {

    }*/
}
