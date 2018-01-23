using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vMeleeManager")]
	[Tooltip("Set active Single Part to attack ")]
	public class vMM_SetActiveAttack : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vMeleeManager))] 
		public FsmOwnerDefault gameObject;
		
		public FsmString bodyPart;
		public vAttackType type;
		public FsmBool active;
		public FsmInt damageMultiplier;
		public FsmInt recoilID;
		public FsmInt reactionID;
		public FsmBool ignoreDefense;
		public FsmBool activeRagdoll;
		public FsmString attackName;
		public FsmBool everyFrame;

		vMeleeManager theScript;
  
		public override void Reset()
		{
			gameObject = null;
			bodyPart = "";
			type = vAttackType.Unarmed;
			active = true;
			damageMultiplier = null;
			recoilID = null;
			reactionID = null;
			ignoreDefense = false;
			activeRagdoll = false;
			attackName = "";
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
			
			theScript.SetActiveAttack(bodyPart.Value, type, active.Value, damageMultiplier.Value, recoilID.Value, reactionID.Value, ignoreDefense.Value, activeRagdoll.Value, attackName.Value);            
		}

	}
}