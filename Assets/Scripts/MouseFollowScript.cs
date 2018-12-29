using UnityEngine;

public class MouseFollowScript : MonoBehaviour
{
    public Camera camera;
    public GameObject floor;
    public GameObject followingObject;

    private void Start() { followingObject = Instantiate(followingObject); }

    // Update is called once per frame
    private void Update()
    {
        print(Input.mousePosition);

        /*
        float xx = Input.mousePosition.x;
        float yy = Input.mousePosition.y;
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(xx, yy, followingObject.transform.position.z));
        */


        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (floor.GetComponent<Collider>().Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);

            Vector3 followingObjectPos = new Vector3(hit.point.x, hit.point.y + followingObject.GetComponent<Collider>().bounds.size.y / 2, hit.point.z);
            followingObject.transform.position = followingObjectPos;
        }
    }
}