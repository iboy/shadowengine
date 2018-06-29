//start doubleClickStart as a float so no ambiguity to the compiler
var doubleClickStart : float = -1.0;
//EDIT TO DISABLE MOUSE CLICKS FOR A TIME AFTER DOUBLE CLICK
var disableClicks = false;
var myTransform : Transform;
 
//END EDIT

function OnMouseUp()
{
    //EDIT TO DISABLE MOUSE CLICKS FOR A TIME AFTER DOUBLE CLICK
    if (disableClicks)
        return;
    //END EDIT

    //make sure doubleClickStart isn't negative, that'll break things
    if (doubleClickStart > 0 && (Time.time - doubleClickStart) < 0.4)
    {
        this.OnDoubleClick();
        doubleClickStart = -1;
            lockClicks();
    }
    else
    {
        doubleClickStart = Time.time;
    }
}

//EDIT TO DISABLE MOUSE CLICKS FOR A TIME AFTER DOUBLE CLICK
function lockClicks()
{
    disableClicks = true;
    yield WaitForSeconds(0.4);
    disableClicks = false;
}
//END EDIT

function OnDoubleClick()
{   

    // do some stuff.     
   Debug.Log("Double Clicked!");
myTransform.rigidbody.isKinematic = true;
yield WaitForSeconds(0.4);
myTransform.transform.Rotate(0,180,0);

//myTransform.transform.Rotate = Quaternion.Slerp(transform.rotation, 180,
//                                   Time.deltaTime * 2);
yield WaitForSeconds(0.4);
myTransform.rigidbody.isKinematic = false;



}