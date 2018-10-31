using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TestScript : MonoBehaviour {
    public GameObject explosion;
    private GameObject mainCamera;
    public Text infoText;
    private GameObject player;
    public Slider slider;
    public Vector3 rotation;
    public Vector3 translation;
    public Vector3 newLocation;
    private Transform playerTransform;
    private Ray ray;
    private RaycastHit hitInfo;
    // Use this for initialization
    void Start () {
        mainCamera = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        playerTransform = player.transform;
        ray = new Ray();
        
    }
	
	// Update is called once per frame
	void Update () {
        ray.origin = transform.position;
        ray.direction = transform.forward;
        Physics.Raycast(ray, out hitInfo);
        infoText.text = hitInfo.transform.name;
    }

    public void LookSomewhere(GameObject someObject)
    {
        mainCamera.transform.LookAt(someObject.transform);
    }

    public void MoveObject(float speedX)
    {
        translation.x = speedX;
        player.transform.Translate(translation);
    }

    public void RotateObject()
    {
        Quaternion newRotation = new Quaternion();
        float yValue = slider.value;
        newRotation.Set(player.transform.rotation.x, yValue, player.transform.rotation.z, player.transform.rotation.w);
        player.transform.rotation = newRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        infoText.text = "Collision detected. We got hit by gameobject named: ";
        string nameInfo = collision.gameObject.name;
        infoText.text += nameInfo;
        int numberOfPoints = collision.contacts.Length;
        infoText.text += "Collisions happened in " + numberOfPoints.ToString() + "points.";
        infoText.text += "Collision happened in transform points:";
        string placeInfo;
        for (int i = 0; i < numberOfPoints; i++)
        {
            placeInfo = collision.contacts[i].point.ToString();
            infoText.text += placeInfo;
        }
        Vector3 explosionPoint = new Vector3();
        explosionPoint.Set(collision.contacts[0].point.x, collision.contacts[0].point.y, collision.contacts[0].point.z);
        Instantiate(explosion, explosionPoint, collision.gameObject.transform.rotation);
        Destroy(collision.gameObject);

    }

    private void OnMouseOver()
    {
        infoText.text = "Mouse on Player";
    }
}





