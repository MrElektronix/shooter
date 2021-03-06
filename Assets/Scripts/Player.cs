﻿using UnityEngine;

[RequireComponent(typeof(PlayerContoller))]
public class Player : MonoBehaviour {
    private const float MoveSpeed = 3;

    private Camera _viewCamera;
    private GunController _gunController;
    private PlayerContoller _controller;

	// Use this for initialization
	private void Start () {
        _controller = GetComponent<PlayerContoller>();
	    _gunController = GetComponent<GunController>();
        _viewCamera = Camera.main;
	}

	// Update is called once per frame
	private void Update () {
	    // Move input
        var moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        var moveVelocity = moveInput.normalized * MoveSpeed;
        _controller.Move(moveVelocity);

	    // Look inout
        var ray = _viewCamera.ScreenPointToRay(Input.mousePosition);
        var groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

	    if (!groundPlane.Raycast(ray, out rayDistance)) return;
	    var point = ray.GetPoint(rayDistance);
	    Debug.DrawLine(ray.origin, point, Color.red);
	    _controller.LookAt(point);

	    // Weapon Input
	    if (Input.GetMouseButton(0))
	    {
	        _gunController.Shoot();
	    }
	}
}
   