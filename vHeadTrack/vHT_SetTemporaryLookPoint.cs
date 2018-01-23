using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vHeadTrack")]
	[Tooltip("Set a temporary look point to headtrack ")]
	public class vHT_SetTemporaryLookPoint : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vHeadTrack))] 
		public FsmOwnerDefault gameObject;
		
		public FsmVector3 point;
		
		public FsmFloat time;
		
		public FsmBool everyFrame;

		vHeadTrack theScript;

		public override void Reset()
		{
			gameObject = null;
			point = new Vector3(0,0,0);
			time = 1;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vHeadTrack>();


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
			theScript.SetTemporaryLookPoint(point.Value, time.Value);
				
			
		}

	}
}