using UnityEngine;

public class Collectible : MonoBehaviour
{
     [SerializeField] private GameObject collectEffect;
    private void OnCollisionEnter(Collision collision)
{
    if (collision.transform.CompareTag("Player"))
    {
        FindAnyObjectByType<GameManager>().AddCollectible();

        GameObject effect = Instantiate(
            collectEffect,
            transform.position,
            Quaternion.identity
        );

        Destroy(effect, 2f);
        Destroy(gameObject);
    }
}




}
