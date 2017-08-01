using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerContoller : MonoBehaviour {
    private Vector3 _velocity;
    private Rigidbody _myRigidBody;

	// Use this for initialization
	private void Start () {
        _myRigidBody = GetComponent<Rigidbody>();
	}

    public void Move(Vector3 velocity)
    {
        _velocity = velocity;
    }

    public void LookAt(Vector3 lookPoint)
    {
        var correctHeightPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(correctHeightPoint);
    }

	private void FixedUpdate () {
        _myRigidBody.MovePosition(_myRigidBody.position + _velocity * Time.fixedDeltaTime);
	}
}
