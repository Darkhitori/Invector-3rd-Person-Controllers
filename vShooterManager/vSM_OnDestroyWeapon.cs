using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vShooterManager")]
	[Tooltip(" ")]
	public class vSM_OnDestroyWeapon : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vShooterManager))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject otherGameObject;
		
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		vShooterManager theScript;
  
		public override void Reset()
		{
			gameObject = null;
			otherGameObject = null;
			sendEvent = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vShooterManager>();


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
			
			theScript.OnDestroyWeapon(otherGameObject.Value);   
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