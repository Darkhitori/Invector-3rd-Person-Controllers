using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vControlAimCanvas")]
	[Tooltip("Set WorldPosition of TargetAim ")]
	public class vCAC_SetWordPosition : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vControlAimCanvas))] 
		public FsmOwnerDefault gameObject;
		
		public FsmVector3 worldPosition;
		public FsmBool validPoint;
		
		public FsmBool everyFrame;

		vControlAimCanvas theScript;
  

		public override void Reset()
		{
			gameObject = null;
			worldPosition = new Vector3(0,0,0);
			validPoint = true;
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
			
			theScript.SetWordPosition(worldPosition.Value, validPoint.Value);            
		}

	}
}