using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vMeleeCombatInput")]
	[Tooltip(" ")]
	public class vMCI_BreakAttack : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vMeleeCombatInput))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt breakAtkID;
		
		public FsmBool everyFrame;

		vMeleeCombatInput theScript;
  

		public override void Reset()
		{
			gameObject = null;
			breakAtkID = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vMeleeCombatInput>();


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
			
			theScript.BreakAttack(breakAtkID.Value);            
		}

	}
}