using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vShooterWeapon")]
	[Tooltip(" ")]
	public class vSW_ShootEffect : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vShooterWeapon))] 
		public FsmOwnerDefault gameObject;
		
		public enum ShootEffect
		{
			sender,
			aimPosition_sender
		}
		
		public ShootEffect methods;
		
		public FsmVector3 aimPosition;
		
		[ObjectType(typeof(Transform))]
		public FsmObject sender;
		
		public FsmBool everyFrame;

		vShooterWeapon theScript;
  
		public override void Reset()
		{
			gameObject = null;
			aimPosition = new Vector3(0,0,0);
			sender = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vShooterWeapon>();


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
			var vSend = sender.Value as Transform;
			if (vSend == null)
			{
				return;
			}
			
			switch(methods)
			{
			case ShootEffect.sender:
				theScript.ShootEffect(vSend);
				break;
			case ShootEffect.aimPosition_sender:
				theScript.ShootEffect(aimPosition.Value, vSend);
				break;
			}
			 
			
		}

	}
}