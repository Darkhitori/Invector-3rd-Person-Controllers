using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vMeleeAttackObject")]
	[Tooltip("Call Back of hitboxes ")]
	public class vMAO_OnHit : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vMeleeAttackObject))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(vHitBox))]
		public FsmObject hitBox;
		
		[ObjectType(typeof(Collider))]
		public FsmObject other;
		
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		vMeleeAttackObject theScript;
  

		public override void Reset()
		{
			gameObject = null;
			hitBox = null;
			other = null;
			sendEvent = null;
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
			var vHit = hitBox.Value as vHitBox;
			if (vHit == null)
			{
				return;
			}
			var vOther = other.Value as Collider;
			if (vOther == null)
			{
				return;
			}
			
			theScript.OnHit(vHit, vOther); 
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