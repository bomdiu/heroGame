using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonPivot : MonoBehaviour
{
 
	public GameObject pivot;
	public GameObject Target;
	public float lookSpeed = 50;

	void Update ()
	{
		Vector3 direction = Target.transform.position - transform.position;
		float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, rotation, Time.deltaTime * lookSpeed);
	}
}
