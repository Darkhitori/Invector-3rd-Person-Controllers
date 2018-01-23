using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vMeleeManager")]
	[Tooltip("Get ideal distance for the attack ")]
	public class vMM_GetAttackDistance : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vMeleeManager))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmFloat)]
		public FsmFloat attackDistance;
		
		public FsmBool everyFrame;

		vMeleeManager theScript;
  
		public override void Reset()
		{
			gameObject = null;
			attackDistance = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vMeleeManager>();


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
			
			attackDistance.Value = theScript.GetAttackDistance();            
		}

	}
}