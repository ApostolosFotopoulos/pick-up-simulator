using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PickUpController : MonoBehaviour{
	[Header("Pickup Settings")]
	[SerializeField] GameObject removeItemCheck;
	[SerializeField] float removeItemRange = 0.22f;
	private GameObject heldObj;
	private Rigidbody heldObjRB;
	private Collider heldObjCOL;

	[Header("Pickup Objects")]
	[SerializeField] GameObject[] objectsToPickUp;
	
	[Header("Physics Parameters")]
	[SerializeField] float pickUpRange = 0.3f;
	[SerializeField] float pickUpForce = 150.0f;

    private int removedObjectsCount = 0;
    private int numberOfClicks = 0;


    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
		if (removedObjectsCount < objectsToPickUp.Length) {
			GameObject objectToPickUp = FindClosestObject();
			Debug.Log(objectToPickUp.name);
			float dist = Vector3.Distance(objectToPickUp.transform.position,transform.position);
			for (int i = 0; i < objectsToPickUp.Length; i++) {
				if (objectsToPickUp[i] != null) {
					if (objectsToPickUp[i] != objectToPickUp) {
						Outline outline = objectsToPickUp[i].GetComponent<Outline>();
						outline.outlineColor = Color.red;
						outline.UpdateMaterialProperties();
					}
					else {
						Outline outline = objectToPickUp.GetComponent<Outline>();
						if (dist<ChangeDistanceFromDifficulty()) {
							outline.outlineColor = Color.blue;
						}
						else {
							outline.outlineColor = Color.red;
						}
						outline.UpdateMaterialProperties();
					}
				}
				
			}

			if (Input.GetMouseButtonDown(0)) {
				if (heldObj == null) {
					if (dist<ChangeDistanceFromDifficulty()) {
						numberOfClicks++;
						if (numberOfClicks == Globals.catchClickDifficulty+1)
						{
                            PickUpObject(objectToPickUp);
                            numberOfClicks=0;
                        }
					}
				}
				else {
					//DropObject();
				}
			}
			
			if (heldObj != null) {
				if (RemovePickedObjectCheck()) {
					removedObjectsCount++;
					Destroy(heldObj);
					Globals.score = removedObjectsCount + "/" + objectsToPickUp.Length;
				}
				else {
					MoveObject();
				}
				
			}
		}
		else {
			//next scene?
		}
		
    }

	bool RemovePickedObjectCheck() {
		//float dist = Vector3.Distance(heldObj.transform.position,removeItemCheck.transform.position);
		float dist = heldObj.transform.position.z - removeItemCheck.transform.position.z;
        Debug.Log(dist);
        if (dist<removeItemRange) {
			return true;
		}
		else {
			return false;
		}
	}

    void MoveObject() {
		if (Vector3.Distance(heldObj.transform.position, transform.position) > 0.1f) {
			Vector3 moveDirection = transform.position - heldObj.transform.position;
			heldObjRB.AddForce(moveDirection*pickUpForce);
		}
	}
	
	void PickUpObject(GameObject pickObj) {
		if (pickObj.GetComponent<Rigidbody>()) {
			heldObjRB = pickObj.GetComponent<Rigidbody>();
			heldObjCOL = pickObj.GetComponent<Collider>();
			heldObjRB.isKinematic = true;
			heldObjCOL.enabled = false;
			
			heldObjRB.transform.parent = transform;
			heldObj = pickObj;
			heldObj.transform.localPosition = new Vector3(-0.053f,-0.059f,-0.01f);
		}
	}
	
	void DropObject() {
		heldObjRB.isKinematic = false;
		heldObjCOL.enabled = true;
		
		heldObjRB.transform.parent = null;
		heldObj = null;
	}

	float ChangeDistanceFromDifficulty() {
		float extraDistance;
		if (Globals.catchDistanceDifficulty == 0) {
			extraDistance = 0.20f;
		}
		else if (Globals.catchDistanceDifficulty == 1) {
			extraDistance = 0.15f;
		}
		else if (Globals.catchDistanceDifficulty == 2) {
			extraDistance = 0.10f;
		}
		else {
			extraDistance = 0.05f;
		}
		//Debug.Log(extraDistance);
		return pickUpRange + extraDistance;
	}

	GameObject FindClosestObject() {
		float[] distances = new float[objectsToPickUp.Length];

		for (int i = 0; i < objectsToPickUp.Length; i++) {
			if (objectsToPickUp[i] != null) {
				distances[i] = Vector3.Distance(objectsToPickUp[i].transform.position,transform.position);
			}
			else {
				distances[i] = 10000f;
			}
		}

		float min = distances[0];
		int pos = 0;
		for (int i = 0; i < distances.Length; i++) {
			if (distances[i] < min) {
				min = distances[i];
				pos = i;
			}
		}

		return objectsToPickUp[pos];
	}
}
