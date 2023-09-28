using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {
    [Header("Set in Inspector")] // a
public GameObject prefabProjectile;
[Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
void Awake() {
Transform launchPointTrans = transform.Find("LaunchPoint"); // a
launchPoint = launchPointTrans.gameObject;
launchPoint.SetActive( false ); // b
launchPos = launchPointTrans.position;
}
void OnMouseEnter() {
print("Slingshot:OnMouseEnter()");
launchPoint.SetActive( true );
}
void OnMouseExit() {
print("Slingshot:OnMouseExit()");
launchPoint.SetActive( false );
}
void OnMouseDown() { // d
// The player has pressed the mouse button while over Slingshot
aimingMode = true;
// Instantiate a Projectile
projectile = Instantiate( prefabProjectile ) as GameObject;
// Start it at the launchPoint
projectile.transform.position = launchPos;
// Set it to isKinematic for now
projectile.GetComponent<Rigidbody>().isKinematic = true;
}
}

