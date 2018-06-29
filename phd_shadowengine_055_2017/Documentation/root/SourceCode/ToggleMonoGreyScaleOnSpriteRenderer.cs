/*
* UniOSC
* Copyright © 2014 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;


namespace UniOSC{
	
	/// <summary>
	/// With this class you can toggle most of the Unity Components on/off
	/// The data of the OSC message should be only 0(off) or 1(on)
	/// </summary>
	[AddComponentMenu("UniOSC/ToggleMonoGreyScale")]
	public class ToggleMonoGreyScaleOnSpriteRenderer :  UniOSCEventTarget {
		
	
		//public Component componentToToggle;
		[HideInInspector]
		public bool toggleState;
		//public bool makeMono;
		//public bool makeGreyScale;
		public GameObject objectToToggle1;
		public GameObject objectToToggle2;
		public GameObject objectToToggle3;
		public GameObject objectToToggle4;
		public GameObject objectToToggle5;
		public GameObject objectToToggle6;
		public GameObject objectToToggle7;
		public GameObject objectToToggle8;
		public GameObject objectToToggle9;
		public GameObject objectToToggle10;
		public GameObject objectToToggle11;
		public GameObject objectToToggle12;
		private Color black;
		private Color tintColor1;
		private Color tintColor2;
		private Color tintColor3;
		private Color tintColor4;
		private Color tintColor5;
		private Color tintColor6;
		private Color tintColor7;
		private Color tintColor8;
		private Color tintColor9;
		private Color tintColor10;
		private Color tintColor11;
		private Color tintColor12;

		private SpriteRenderer objectToToggleRenderer1;
		private SpriteRenderer objectToToggleRenderer2;
		private SpriteRenderer objectToToggleRenderer3;
		private SpriteRenderer objectToToggleRenderer4;
		private SpriteRenderer objectToToggleRenderer5;
		private SpriteRenderer objectToToggleRenderer6;
		private SpriteRenderer objectToToggleRenderer7;
		private SpriteRenderer objectToToggleRenderer8;
		private SpriteRenderer objectToToggleRenderer9;
		private SpriteRenderer objectToToggleRenderer10;
		private SpriteRenderer objectToToggleRenderer11;
		private SpriteRenderer objectToToggleRenderer12;


		//private Type _compType1;
		
		
		void Awake(){
		}
		
		
		private void _Init(){



			black = new Color(0f,0f,0f,1f); //black

		//	if (objectToToggle1 !=null) {


				// new note: I've tried to make this a switch for each material type I've used
				// MEMO easier to be consistent with the mesh generation / shading models
				// MEMO e.g sprite renderer, transparent/diffuse shaders,  etc.

			// if renderer / material has tintcolor (not spriterenderer)

				// try setting the object - it may be null if no spriterenderer is presnet
		//		objectToToggleRenderer1 = objectToToggle1.GetComponent<SpriteRenderer>(); 
		//		objectToToggleRendererRenderer1 = objectToToggle1.GetComponent<Renderer>(); 

		//		if (objectToToggleRenderer1 != null) {
				// tintColor1 = objectToToggle1.renderer.sharedMaterial.GetColor ("_TintColor");

		//		}

			 


		//		if (objectToToggleRendererRenderer1 != null) {

				//	tintColor1 = objectToToggle1.renderer.sharedMaterial.GetColor ("_Color");


	//			}

				//Debug.Log("Hello from MonoToggle");



					
					//tintColor1 = objectToToggle1.renderer.sharedMaterial.GetColor ("_TintColor");
				
				
					//Renderer rend = objectToToggle1.GetComponent<Renderer>();
						// this works but is in the wrong place.

					// if not a sprite renderer
				//		objectToToggleRendererRenderer1.material.shader = Shader.Find("Transparent/Diffuse");
				//		objectToToggleRendererRenderer1.material.SetColor("_Color", tintColor1);

			
				// if spriterenderer

					//objectToToggleRenderer1 = objectToToggle1.GetComponent<SpriteRenderer>();

					//tintColor1 = objectToToggleRenderer1.color;
				//objectToToggleRenderer1.color = black; // Set to opaque black
		//		}
		//	}






			if (objectToToggle1 !=null) {
				// if renderer / material has tintcolor (not spriterenderer)
				//tintColor2 = objectToToggle2.renderer.sharedMaterial.GetColor ("_TintColor");
				
				objectToToggleRenderer1 = objectToToggle1.GetComponent<SpriteRenderer>();

				//objectToToggle1.renderer.material.color;
				//Color color = objectToToggle1.renderer.material.color;
				//color.a -= 0.1f;
				//renderer.material.color = color;

				tintColor1 = objectToToggleRenderer1.color;

			}



			if (objectToToggle2 !=null) {
				// if renderer / material has tintcolor (not spriterenderer)
				//tintColor2 = objectToToggle2.renderer.sharedMaterial.GetColor ("_TintColor");

				objectToToggleRenderer2 = objectToToggle2.GetComponent<SpriteRenderer>();
				
				tintColor2 = objectToToggleRenderer2.color;
				
			}

			if (objectToToggle3 !=null) {

				// if renderer / material has tintcolor (not spriterenderer)
				//tintColor3 = objectToToggle3.renderer.sharedMaterial.GetColor ("_TintColor");

				objectToToggleRenderer3 = objectToToggle3.GetComponent<SpriteRenderer>();
				
				tintColor3 = objectToToggleRenderer3.color;
				
			}

			if (objectToToggle4 !=null) {
				// if renderer / material has tintcolor (not spriterenderer)
				//tintColor4 = objectToToggle4.renderer.sharedMaterial.GetColor ("_TintColor");

				objectToToggleRenderer4 = objectToToggle4.GetComponent<SpriteRenderer>();
				
				tintColor4 = objectToToggleRenderer4.color;
				
			}

			if (objectToToggle5 !=null) {
				// if renderer / material has tintcolor (not spriterenderer)
				//tintColor5 = objectToToggle5.renderer.sharedMaterial.GetColor ("_TintColor");

				objectToToggleRenderer5 = objectToToggle5.GetComponent<SpriteRenderer>();
				
				tintColor5 = objectToToggleRenderer5.color;

			}

			if (objectToToggle6 !=null) {
				// if renderer / material has tintcolor (not spriterenderer)
				//tintColor6 = objectToToggle6.renderer.sharedMaterial.GetColor ("_TintColor");
				objectToToggleRenderer6 = objectToToggle6.GetComponent<SpriteRenderer>();
				
				tintColor6 = objectToToggleRenderer6.color;

			}

			if (objectToToggle7 !=null) {
				// if renderer / material has tintcolor (not spriterenderer)
				//tintColor5 = objectToToggle5.renderer.sharedMaterial.GetColor ("_TintColor");
				
				objectToToggleRenderer7 = objectToToggle7.GetComponent<SpriteRenderer>();
				
				tintColor7 = objectToToggleRenderer7.color;
				
			}
			
			if (objectToToggle8 !=null) {
				// if renderer / material has tintcolor (not spriterenderer)
				//tintColor6 = objectToToggle6.renderer.sharedMaterial.GetColor ("_TintColor");
				objectToToggleRenderer8 = objectToToggle8.GetComponent<SpriteRenderer>();
				
				tintColor8 = objectToToggleRenderer8.color;
				
			}

			if (objectToToggle9 !=null) {
				// if renderer / material has tintcolor (not spriterenderer)
				//tintColor5 = objectToToggle5.renderer.sharedMaterial.GetColor ("_TintColor");
				
				objectToToggleRenderer9 = objectToToggle9.GetComponent<SpriteRenderer>();
				
				tintColor9 = objectToToggleRenderer9.color;
				
			}
			
			if (objectToToggle10 !=null) {
				// if renderer / material has tintcolor (not spriterenderer)
				//tintColor6 = objectToToggle6.renderer.sharedMaterial.GetColor ("_TintColor");
				objectToToggleRenderer10 = objectToToggle10.GetComponent<SpriteRenderer>();
				
				tintColor10 = objectToToggleRenderer10.color;
				
			}

			if (objectToToggle11 !=null) {

				objectToToggleRenderer11 = objectToToggle11.GetComponent<SpriteRenderer>();
				
				tintColor11 = objectToToggleRenderer11.color;
				
			}

			if (objectToToggle12 !=null) {
				
				objectToToggleRenderer12 = objectToToggle12.GetComponent<SpriteRenderer>();
				
				tintColor12 = objectToToggleRenderer12.color;
				
			}


			//if(componentToToggle == null){
			//	componentToToggle = gameObject.transform;
			//}

			//if(objectToToggle1 != null) _compType1 =objectToToggle1.GetType();

			UpdateComponentState();



			}

		public void ToggleGreyFromUI (Toggle toggle) {

			//Debug.Log("You've Toggled the "+toggle.name+" toggle");
			bool state = toggle.isOn;
			if (state == true) {

				Debug.Log("You've selected the grey toggle");
				toggleState = true;
				UpdateComponentState();
			}


		}
		/// <summary>
		/// Sets monochrome from UI.
		/// </summary>
		/// <param name="toggle">Toggle: reference to the UI toggle value.</param>
		/// <summary>
		/// The GetZero method.
		/// </summary>
		/// <example> 
		/// This sample shows how to call the <see cref="ToggleMonoFromUI"/> method.
		/// <code>
		/// class TestClass 
		/// {
		///     static int Main() 
		///     {
		///         return GetZero();
		///     }
		/// }
		/// </code>
		/// </example>
		/// <example>This is the example.</example>
		/// <term>This is a 'term'</term>
		/// <list type="table">  
		/// <listheader>  
		/// 	<term>term</term>  
		/// 		<description>description</description>  
		/// 		</listheader>  
		/// 		<item>  
		/// 		<term>term</term>  
		/// 		<description>description</description>  
		/// 		</item>  
		///  		<item>  
		/// 		<term>term2</term>  
		/// 		<description>description2</description>  
		/// 		</item>  
		/// 		</list> 
		public void ToggleMonoFromUI (Toggle toggle) {
			
			//Debug.Log("You've Toggled the "+toggle.name+" toggle");
			//bool state = toggle.isOn;
			bool invoking = toggle.IsInvoking();
			//if (invoking == true) {
				bool state = toggle.isOn;
				if (state == true) {
					
					Debug.Log("You've selected the mono toggle");
					//if (toggle.isOn
					toggleState = true;
					UpdateComponentState();
				} else {
				
					toggleState = false;
					UpdateComponentState();
				}
			
			
			//}
		}

		/// <summary>
		/// Updates the state of the component.(enabled)
		/// </summary>
		public void UpdateComponentState(){
			
			//if(_compType == null) return;
			if (objectToToggle1 !=null) {
			if (toggleState == true && objectToToggle1 !=null) {
					// CHANGE TO BLACK

					// TODO if the shader / material type varies the way to access and change the color varies
					// catch those differences here and have a toggle? or detect the renderer type.
					//objectToToggle1.renderer.sharedMaterial.SetColor ("_TintColor", black);
					if (objectToToggleRenderer1 != null) {
					objectToToggleRenderer1.color = black;
					} 

				} else { 			
					// RESTORE TO TINT

					//objectToToggle1.renderer.sharedMaterial.SetColor ("_TintColor", tintColor1);
					//if (objectToToggleRenderer1) {

					if (objectToToggleRenderer1 != null) {
					objectToToggleRenderer1.color = tintColor1;

					}
					//} else 

				//	{ Debug.Log("Im in the final check"); }
				} // end of object 1

			}
			if (objectToToggle2 !=null) {
			if (toggleState == true && objectToToggle2 !=null) {
						
					//objectToToggle2.renderer.sharedMaterial.SetColor ("_TintColor", black);
					if (objectToToggleRenderer2 != null) {
						objectToToggleRenderer2.color = black;
					}
				} else { 
										
					//objectToToggle2.renderer.sharedMaterial.SetColor ("_TintColor", tintColor2);
					if (objectToToggleRenderer2 != null) {
						objectToToggleRenderer2.color = tintColor2;
					}

			} // end of object 2
			}
			if (objectToToggle3 !=null) {
			if (toggleState == true && objectToToggle3 !=null) {
					
					//objectToToggle3.renderer.sharedMaterial.SetColor ("_TintColor", black);
					if (objectToToggleRenderer3 != null) {
						objectToToggleRenderer3.color = black;
					}
				} else { 
					
					//objectToToggle3.renderer.sharedMaterial.SetColor ("_TintColor", tintColor3);
					if (objectToToggleRenderer3 != null) {
						objectToToggleRenderer3.color = tintColor3;
					}

			} // end of object 3


			}

			if (objectToToggle4 !=null) {
				if (toggleState == true && objectToToggle4 !=null) {
					
					//objectToToggle4.renderer.sharedMaterial.SetColor ("_TintColor", black);
					if (objectToToggleRenderer4 != null) {
						objectToToggleRenderer4.color = black;
					}
				} else { 
					
					//objectToToggle4.renderer.sharedMaterial.SetColor ("_TintColor", tintColor4);
					if (objectToToggleRenderer4 != null) {
						objectToToggleRenderer4.color = tintColor4;
					}
				} // end of object 4
				
				
			}

			if (objectToToggle5 !=null) {
				if (toggleState == true && objectToToggle5 !=null) {
					
					//objectToToggle5.renderer.sharedMaterial.SetColor ("_TintColor", black);

					if (objectToToggleRenderer5 != null) {
					objectToToggleRenderer5.color = black;
					}
				} else { 
					
					//objectToToggle5.renderer.sharedMaterial.SetColor ("_TintColor", tintColor5);
					if (objectToToggleRenderer5 != null) {
						objectToToggleRenderer5.color = tintColor5;
					}
				} // end of object 5
				
				
			}

			if (objectToToggle6 !=null) {
				if (toggleState == true && objectToToggle6 !=null) {
					
					//objectToToggle6.renderer.sharedMaterial.SetColor ("_TintColor", black);
					if (objectToToggleRenderer6 != null) {
						objectToToggleRenderer6.color = black;
					}
				} else { 
					
					//objectToToggle6.renderer.sharedMaterial.SetColor ("_TintColor", tintColor6);
					if (objectToToggleRenderer6 != null) {
						objectToToggleRenderer6.color = tintColor6;
					}
				} // end of object 6
				
				
			}

			if (objectToToggle7 !=null) {
				if (toggleState == true && objectToToggle7 !=null) {
					
					//objectToToggle7.renderer.sharedMaterial.SetColor ("_TintColor", black);
					if (objectToToggleRenderer7 != null) {
						objectToToggleRenderer7.color = black;
					}
				} else { 
					
					//objectToToggle7.renderer.sharedMaterial.SetColor ("_TintColor", tintColor7);
					if (objectToToggleRenderer7 != null) {
						objectToToggleRenderer7.color = tintColor7;
					}
				} // end of object 7
				
				
			}


			if (objectToToggle8 !=null) {
				if (toggleState == true && objectToToggle8 !=null) {
					
					//objectToToggle8.renderer.sharedMaterial.SetColor ("_TintColor", black);
					if (objectToToggleRenderer8 != null) {
						objectToToggleRenderer8.color = black;
					}
				} else { 
					
					//objectToToggle8.renderer.sharedMaterial.SetColor ("_TintColor", tintColor8);
					if (objectToToggleRenderer8 != null) {
					objectToToggleRenderer8.color = tintColor8;
					}
				} // end of object 8
				
				
			}


			if (objectToToggle9 !=null) {
				if (toggleState == true && objectToToggle9 !=null) {
					
					//objectToToggle9.renderer.sharedMaterial.SetColor ("_TintColor", black);
					if (objectToToggleRenderer9 != null) {
						objectToToggleRenderer9.color = black;
					}

				} else { 
					
					//objectToToggle9.renderer.sharedMaterial.SetColor ("_TintColor", tintColor9);
					if (objectToToggleRenderer9 != null) {
						objectToToggleRenderer9.color = tintColor9;
					}
				} // end of object 9
				
				
			}
			
			
			if (objectToToggle10 !=null) {
				if (toggleState == true && objectToToggle10 !=null) {
					
					//objectToToggle10.renderer.sharedMaterial.SetColor ("_TintColor", black);
					if (objectToToggleRenderer10 != null) {
						objectToToggleRenderer10.color = black;
					}
				} else { 
					
					//objectToToggle10.renderer.sharedMaterial.SetColor ("_TintColor", tintColor10);
					if (objectToToggleRenderer10 != null) {
						objectToToggleRenderer10.color = tintColor10;
					}
				} // end of object 10
				
				
			}

			if (objectToToggle11 !=null) {
				if (toggleState == true && objectToToggle11 !=null) {
					if (objectToToggleRenderer11 != null) {
						objectToToggleRenderer11.color = black;
					}

				} else { 
					if (objectToToggleRenderer11 != null) {
						objectToToggleRenderer11.color = tintColor11;
					}
				} // end of object 11

			}

			if (objectToToggle12 !=null) {
				if (toggleState == true && objectToToggle12 !=null) {
					if (objectToToggleRenderer12 != null) {
						objectToToggleRenderer12.color = black;
					}

				} else { 
					if (objectToToggleRenderer12 != null) {
						objectToToggleRenderer12.color = tintColor12;
					}

				} // end of object 12

				
				
			}
		}


	
	
		
		public override void OnEnable(){
			_Init();
			base.OnEnable();
		}
		
		
		public override void OnOSCMessageReceived(UniOSCEventArgs args){
			
			if(args.Message.Data.Count <1)return;
			if(!( args.Message.Data[0]  is  System.Single))return;
			//Debug.Log("Monochrome message received");
			toggleState = Convert.ToBoolean(args.Message.Data[0]) ;
			UpdateComponentState();
		}
		
	}
	
}