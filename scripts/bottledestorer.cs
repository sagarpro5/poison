using UnityEngine;

public class bottledestorer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
