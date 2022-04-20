using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
	
	public void OnFire()
	{
		Debug.Log("(OnFire)");
		Shoot();
	}

	
	// Update is called once per frame
	void Update () {
	}

	void Shoot ()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
