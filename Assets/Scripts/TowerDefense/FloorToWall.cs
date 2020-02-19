using UnityEngine;

public class FloorToWall : MonoBehaviour
{
    public GameObject other;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    GameObject spawns = Instantiate(other, gameObject.transform.position, Quaternion.LookRotation(new Vector3()));
                    spawns.name = other.name;
                    Destroy(gameObject);
                }
            }
        }
    }
}
