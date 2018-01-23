using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vShooterManager")]
	[Tooltip(" ")]
	public class vSM_SetRightWeapon : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vShooterManager))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject weapon;
		
		public FsmBool everyFrame;

		vShooterManager theScript;
  
		public override void Reset()
		{
			gameObject = null;
			weapon = null;
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
			
			theScript.SetRightWeapon(weapon.Value);            
		}

	}
}