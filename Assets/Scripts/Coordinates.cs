using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coordinates : MonoBehaviour
{
    public TextMeshProUGUI coordinatesText;
    public GameObject interactor;

    private float xBorderMin = -1.2f;
    private float yBorderMin = 1.3f;
    private float zBorderMin = 0.8f;
    void Start()
    {
        xBorderMin = GameObject.Find("Interactor").GetComponent<PickUpMovement>().xBorderMin;
        yBorderMin = GameObject.Find("Interactor").GetComponent<PickUpMovement>().yBorderMin;
        zBorderMin = GameObject.Find("Interactor").GetComponent<PickUpMovement>().zBorderMin;
        Debug.Log(transform.position);
    }

    void Update()
    {
        float x = interactor.transform.position.x - xBorderMin;
        float y = interactor.transform.position.y - yBorderMin;
        float z = interactor.transform.position.z - zBorderMin;
        coordinatesText.text = string.Format("x:{0:0.0} y:{1:0.0} z:{2:0.0}", x, y, z);
    }
}
