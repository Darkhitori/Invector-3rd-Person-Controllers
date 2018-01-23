using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vInput")]
	[Tooltip("GAMEPAD VIBRATION - call this method to use vibration on the gamepad ")]
	public class vI_GamepadVibration : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vInput))] 
		public FsmOwnerDefault gameObject;

		public FsmFloat vibTime;
		
		public FsmBool everyFrame;

		vInput theScript;
  

		public override void Reset()
		{
			gameObject = null;
			vibTime = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vInput>();


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

			theScript.GamepadVibration(vibTime.Value);            
		}

	}
}