using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vShooterWeapon")]
	[Tooltip(" ")]
	public class vSW_SetActiveAim : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vShooterWeapon))] 
		public FsmOwnerDefault gameObject;
		
		public FsmBool value;
		
		public FsmBool everyFrame;

		vShooterWeapon theScript;
  
		public override void Reset()
		{
			gameObject = null;
			value = false;
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
			
			theScript.SetActiveAim(value.Value);            
		}

	}
}