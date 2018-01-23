using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vShooterMeleeInput")]
	[Tooltip(" ")]
	public class vSM_SetLockShooterInput : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vShooterMeleeInput))] 
		public FsmOwnerDefault gameObject;
		
		public FsmBool value;
		
		public FsmBool everyFrame;

		vShooterMeleeInput theScript;
  
		public override void Reset()
		{
			gameObject = null;
			value = false;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vShooterMeleeInput>();


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
			
			theScript.SetLockShooterInput(value.Value);            
		}

	}
}