using UnityEngine;
using UnityEngine.UI;

public class ShowStorage : MonoBehaviour
{
    public GameObject storage;
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Mine: " + storage.GetComponent<Storage>().mine.ToString() + "\nLumber: " + storage.GetComponent<Storage>().building + "\nFood: " + storage.GetComponent<Storage>().food + "\nCoins: " + storage.GetComponent<Storage>().coin;
    }
}
