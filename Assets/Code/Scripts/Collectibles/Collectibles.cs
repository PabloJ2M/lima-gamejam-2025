using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private int collectibleID; //Aca pones la ID del collectible, depende de la cantidad de espacios que tiene el array de booleanos, osea si quieres mas de 3 pues cambias el CManager para que el arreglo sean mas de 3 booleanos y listo

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            CManager.instance.collectCollectible(collectibleID);

            Destroy(gameObject);
        }
    }
}
