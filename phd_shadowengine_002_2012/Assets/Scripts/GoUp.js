// Adds a force upwards in the global coordinate system
function FixedUpdate () {
    this.rigidbody.AddTorque (Vector3.up * 8);
}