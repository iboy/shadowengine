var target1: Transform;
var target2: Transform;


function Update () {
	if (Input.GetMouseButton(0)) {
		var ray: Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		var hit: RaycastHit;
		
		if (Physics.Raycast(ray, hit)) {
			if (hit.transform == target1) {
				print("Hit target 1");
			} else if (hit.transform == target2) {
				print("Hit target 2");
			}
		} else {
			print("Hit nothing");
		}
	}
}