using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Ability
{
	#region Editor Variables
	[SerializeField]
	[Tooltip("The speed that the fireball travels at")]
	private float m_Speed;
	#endregion

	#region Initialization
	public override void Use(Vector3 spawnPos)
	{

		Rigidbody RB = GetComponent<Rigidbody>();
		RB.velocity = transform.forward * m_Speed;
	}
	#endregion

	#region Collision
	private void OnTriggerEnter(Collider other) {
		Debug.Log("HIT!");
		if (other.gameObject.CompareTag("Enemy")) {
			Debug.Log("HIT Enemy!");
			other.gameObject.GetComponent<EnemyController>().DecreaseHealth(m_Info.Power);
		}
	}
	#endregion
}
