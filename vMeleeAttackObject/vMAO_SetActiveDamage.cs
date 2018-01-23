using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vMeleeAttackObject")]
	[Tooltip("Set Active all hitBoxes of the MeleeAttackObject ")]
	public class vMAO_SetActiveDamage : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vMeleeAttackObject))] 
		public FsmOwnerDefault gameObject;
		
		public FsmBool value;
		
		public FsmBool everyFrame;

		vMeleeAttackObject theScript;
  

		public override void Reset()
		{
			gameObject = null;
			value = false;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vMeleeAttackObject>();


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
			
			theScript.SetActiveDamage(value.Value);            
		}

	}
}