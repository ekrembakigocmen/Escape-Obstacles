
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public static bool Coll = false;
    bool isContunie;
    private void FixedUpdate()
    {
        isContunie = SpawnPointsManager.IsContinue;
        if (transform.position.y < -3f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        SphereCollider Sc = collision.collider.GetComponent<SphereCollider>();

        if (Sc != null)
        {
            Coll = true;

            Destroy(this.gameObject);

        }

    }
}
