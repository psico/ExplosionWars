using UnityEngine;
using System.Collections;

public class ConfigStart : MonoBehaviour {

    public GameObject player1;

	// Use this for initialization
	void Start () {
        //No caso de um 1 player
        Destroy(GameObject.Find("Linha1").transform.FindChild("Bloco1").gameObject);
        Destroy(GameObject.Find("Linha1").transform.FindChild("Bloco2").gameObject);
        Destroy(GameObject.Find("Linha2").transform.FindChild("Bloco1").gameObject);

        Destroy(GameObject.Find("Player2"));
        Destroy(GameObject.Find("Player3"));
        Destroy(GameObject.Find("Player4"));

        //Instantiate(player1, new Vector3(86,0,128), Quaternion.Euler(new Vector3(0, 0, 0)));

    }
	
}
