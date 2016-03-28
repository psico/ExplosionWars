using UnityEngine;
using System.Collections;

public class Colisao : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        // Debug-draw all contact points and normals
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.otherCollider.gameObject.tag == "block" && contact.thisCollider.tag == "explosion")
            {
                Destroy(contact.otherCollider.gameObject);
            }
            if (contact.otherCollider.gameObject.tag == "Player" && contact.thisCollider.tag == "explosion")
            {

                //contact.otherCollider.gameObject.transform.position = SpawnPoint.transform.position;
                //this.transform.position = contact.otherCollider.gameObject.transform.position;
                
               // GameObject gameObjectAux = contact.otherCollider.gameObject;
                //Destroy(contact.otherCollider.gameObject);
                //Instantiate(gameObjectAux, new Vector3(86, 0, 128), Quaternion.Euler(new Vector3(0, 0, 0)));
                //Destroy(contact.thisCollider);

            }
        }

    }
}
