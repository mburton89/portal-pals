using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Portal : MonoBehaviour
{
	// the other portal that this will teleport to/render
	public GameObject linkedPortal;

	// used to help prevent us from infinitely teleporting back and forth
	private bool portalActive = true;

	void OnTriggerEnter(Collider other)
    {
		if (portalActive && !other.GetComponent<ObjectGrabber>())
        {
			// disable portals to prevent infinite portal loop
			linkedPortal.GetComponent<Portal>().Activate(false);
			Activate(false);
			TeleportObject(other.transform);
		}
	}

	void OnTriggerExit(Collider other)
    {
		// re-enable portal for teleportation after we've exited
		Activate(true);
	}

	void TeleportObject(Transform objectTransform)
	{
		// cache player rotation to revert after teleport
		float xRot = objectTransform.rotation.x;
		float zRot = objectTransform.rotation.z;

		// set the player's position and rotation to the other portal's
		//TODO Actually teleport the player...
		//objectTransform.position = linkedPortal.transform.position;
		objectTransform.SetPositionAndRotation(linkedPortal.transform.position, linkedPortal.transform.parent.transform.rotation);

		// Y rotation from portal
		float yRot = objectTransform.eulerAngles.y;

		// combine previously cached axes with new Y to get new rotation. Prevents flipping upside-down
		objectTransform.eulerAngles = new Vector3(xRot, yRot, zRot);

		// override FPSController's mouse look caching
		if (objectTransform.GetComponent<RigidbodyFirstPersonController>())
		{
			objectTransform.GetComponent<RigidbodyFirstPersonController>().MouseReset();
		}
	}

	public void Activate(bool isActive)
    {
		// determines if we can actually use this portal to teleport
		portalActive = isActive;
	}
}
