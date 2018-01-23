using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThirdPersonCamera")]
	[Tooltip("Convert a point in the screen in a Ray for the world ")]
	public class vTPC_ScreenPointToRay : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThirdPersonCamera))] 
		public FsmOwnerDefault gameObject;
		
		public FsmVector3 point;
		
		[ActionSection("Return Ray")]
		[UIHint(UIHint.FsmVector3)]
		public FsmVector3 origin;
		[UIHint(UIHint.FsmVector3)]
		public FsmVector3 direction;
		
		public FsmBool everyFrame;

		vThirdPersonCamera theScript;
		

		public override void Reset()
		{
			gameObject = null;
			point = new Vector3(0,0,0);
			origin = new Vector3(0,0,0);
			direction = new Vector3(0,0,0);
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vThirdPersonCamera>();


			if (!everyFrame.Value)
			{
				DoTheMagic();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				DoTheMagic();
			}
		}

		void DoTheMagic()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}
			
			
			origin.Value = theScript.ScreenPointToRay(point.Value).origin; 
			direction.Value = theScript.ScreenPointToRay(point.Value).direction;
		}

	}
}