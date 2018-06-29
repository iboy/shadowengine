
// store a single place to reference prefabs and other project info
static var instance:Prefabs;

// spawned when our fingers touch something
var cube:Transform;

// colors for each finger id
var colors:Color[];

function Awake()
{
	instance = this;
}
