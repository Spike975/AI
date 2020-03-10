using UnityEngine;
using UnityEngine.UI;

public class ShowStorage : MonoBehaviour
{
    public GameObject storage;
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = storage.GetComponent<Storage>().mine.ToString();
    }
}
