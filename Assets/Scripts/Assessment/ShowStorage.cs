using UnityEngine;
using UnityEngine.UI;

public class ShowStorage : MonoBehaviour
{
    public GameObject storage;
    // Shows the current storage of the town
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Mine: " + storage.GetComponent<Storage>().mine.ToString() + "\nLumber: " + storage.GetComponent<Storage>().building + "\nFood: " + storage.GetComponent<Storage>().food + "\nCoins: " + storage.GetComponent<Storage>().coin;
    }
}
