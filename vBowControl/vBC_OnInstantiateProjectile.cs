using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vBowControl")]
	[Tooltip(" ")]
	public class vBC_OnInstantiateProjectile : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vBowControl))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(vProjectileControl))]
		public FsmObject pCtrl;
		
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		vBowControl theScript;
  

		public override void Reset()
		{
			gameObject = null;
			pCtrl = null;
			sendEvent = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vBowControl>();


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
			var vCtrl = pCtrl.Value as vProjectileControl;
			if (vCtrl == null)
			{
				return;
			}
			
			theScript.OnInstantiateProjectile(vCtrl);
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