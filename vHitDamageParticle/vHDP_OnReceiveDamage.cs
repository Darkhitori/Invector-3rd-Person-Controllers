using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vHitDamageParticle")]
	[Tooltip(" ")]
	public class vHDP_OnReceiveDamage : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vHitDamageParticle))] 
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
		public FsmGameObject sender;
		public FsmGameObject receiver;
		public FsmVector3 hitPosition;
		public FsmInt recoil_id;
		public FsmInt reaction_id;
		public FsmString attackName;
		
		[ActionSection("-----------------")]
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		vHitDamageParticle theScript;
		vDamage dam;
  

		public override void Reset()
		{
			gameObject = null;
			damageValue = 15;
			staminaBlockCost = 5;
			staminaRecoveryDelay = 1;
			ignoreDefense = false;
			activeRagdoll = false;
			sender = null;
			receiver = null;
			hitPosition = null;
			recoil_id = null;
			reaction_id = null;
			attackName = "";
			sendEvent = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vHitDamageParticle>();


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
			dam.sender = sender.Value.transform;
			dam.receiver = receiver.Value.transform;
			dam.hitPosition = hitPosition.Value;
			dam.recoil_id = recoil_id.Value;
			dam.reaction_id = reaction_id.Value;
			dam.attackName = attackName.Value;
			var vDam = new vDamage(dam);
			
			theScript.OnReceiveDamage(vDam); 
			if(sendEvent == null)
			{
				return;
			}
			else
			{
				Fsm.Event(sendEvent);
			}
		}

	}
}
