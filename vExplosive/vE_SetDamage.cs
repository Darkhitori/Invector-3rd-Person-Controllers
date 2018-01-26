using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vExplosive")]
	[Tooltip(" ")]
	public class vE_SetDamage : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vExplosive))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("vDamage")]
		[Tooltip("Apply damage to the Character Health")]
		public FsmInt damageValue;
		[Tooltip("How much stamina the target will lost when blocking this attack")]
		public FsmFloat staminaBlockCost;
		[Tooltip("How much time the stamina of the target will wait to recovery")]
		public FsmFloat staminaRecoveryDelay;
		[Tooltip("Apply damage even if the Character is blocking")]
		public FsmBool ignoreDefense;
		[Tooltip("Activated Ragdoll when hit the Character")]
		public FsmBool activeRagdoll;
		public FsmInt reaction_id;
		public FsmString attackName;
		
		public FsmBool everyFrame;

		vExplosive theScript;
		vDamage dam;
  

		public override void Reset()
		{
			gameObject = null;
			damageValue = null;
			staminaBlockCost = null;
			staminaRecoveryDelay = null;
			ignoreDefense = false;
			activeRagdoll = false;
			reaction_id = null;
			attackName = "";
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vExplosive>();


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
			dam = new vDamage(damageValue.Value);
			dam.staminaBlockCost = staminaBlockCost.Value;
			dam.staminaRecoveryDelay = staminaRecoveryDelay.Value;
			dam.ignoreDefense = ignoreDefense.Value;
			dam.activeRagdoll = activeRagdoll.Value;
			dam.reaction_id = reaction_id.Value;
			dam.attackName = attackName.Value;
			var vDam = new vDamage(dam);
			
			theScript.SetDamage(vDam);            
		}

	}
}
