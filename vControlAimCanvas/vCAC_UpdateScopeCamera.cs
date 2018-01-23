using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vControlAimCanvas")]
	[Tooltip("Update World properties and zoom (FieldOfView) of the Scope Camera ")]
	public class vCAC_UpdateScopeCamera : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vControlAimCanvas))] 
		public FsmOwnerDefault gameObject;
		
		public FsmVector3 position;
		public FsmVector3 lookPosition;
		public FsmFloat zoom;
		
		public FsmBool everyFrame;

		vControlAimCanvas theScript;
  

		public override void Reset()
		{
			gameObject = null;
			position = new Vector3(0,0,0);
			lookPosition = new Vector3(0,0,0);
			zoom = 60;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vControlAimCanvas>();


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
			
			theScript.UpdateScopeCamera(position.Value, lookPosition.Value, zoom.Value);            
		}

	}
}