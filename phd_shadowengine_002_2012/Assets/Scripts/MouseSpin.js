var myObject: Transform; 
function OnMouseDown ()
{
   //this.transform.Translate (0,1,0); //moves the card 1 meter up in +y direction 
   //this.transform.Rotate (0,0,180); //rotate 180 degrees around z axis
   myObject.rigidbody.AddRelativeTorque (0, 1000, 0);
}