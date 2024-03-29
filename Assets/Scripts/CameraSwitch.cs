using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isIn = false;
    private GameObject Camera;
    [SerializeField] private Vector3 Position;
    [SerializeField] private float Size;
    [SerializeField] private bool isInDream = false;
    [SerializeField] private float dimensionJump = -100;
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (isIn && Camera.transform.position != Position)
        {
            Camera.transform.position = Vector3.Lerp(Camera.transform.position, Position, 1);
            Camera.GetComponent<Camera>().orthographicSize = Size;
            Camera.GetComponent<CameraFollow>().isActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (isIn == false)
            {
                isIn = true;
                Camera.GetComponent<CameraFollow>().isActive = false;
                Camera.transform.position = Vector3.Lerp(Camera.transform.position, Position, 1);
                Camera.GetComponent<Camera>().orthographicSize = Size;
            }
            else
            {
                isIn = false;
                Camera.GetComponent<CameraFollow>().isActive = true;
                Camera.GetComponent<Camera>().orthographicSize = 6;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (isIn == true)
            {
                isIn = false;
                Camera.GetComponent<CameraFollow>().isActive = true;
                Camera.GetComponent<Camera>().orthographicSize = 6;
            }
        }
    }
}
