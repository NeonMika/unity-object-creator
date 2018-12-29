using System.Linq;
using UnityEngine;

public class MoverScript : MonoBehaviour
{
    public bool Move;
    public float SeeRadius = 4.0f;
    public float Speed = 0.02f;

    private void Update()
    {
        if (Move)
        {
            var seenObjects = Physics.OverlapSphere(transform.position, GetComponent<Collider>().bounds.size.x * SeeRadius);

            var seenEnemyObjects =
                from seen in seenObjects
                where seen.gameObject.CompareTag(gameObject.tag)
                where seen.gameObject.transform.parent != transform.parent
                select seen;

            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            if (!seenEnemyObjects.Any())
            {
                transform.Translate(0, 0, Speed, Space.Self);
            }
            else
            {
                // Kill physics stuff
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                foreach (Collider seenEnemyObject in seenEnemyObjects)
                {
                    Debug.DrawLine(transform.position, seenEnemyObject.ClosestPoint(transform.position));
                }
            }
        }
    }
}