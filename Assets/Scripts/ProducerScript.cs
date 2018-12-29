using UnityEngine;

public class ProducerScript : MonoBehaviour
{
    public bool Generate;
    public int GeneratePerXFrames = 100;
    public GameObject ObjectToGenerate;

    private void Update()
    {
        if (Generate)
        {
            if (Time.frameCount % GeneratePerXFrames == 0)
            {
                Vector3 playerPos = gameObject.transform.position;
                float playerSize = GetComponent<Collider>().bounds.size.z;
                Vector3 playerDirection = gameObject.transform.forward;
                Quaternion playerRotation = gameObject.transform.rotation;

                Vector3 spawnPos = transform.Find("ProducePoint").transform.position;
                spawnPos.y = ObjectToGenerate.GetComponent<Collider>().bounds.size.y / 2;

                GameObject generated = Instantiate(ObjectToGenerate, spawnPos, playerRotation);
                generated.transform.parent = gameObject.transform;
            }
        }
    }
}