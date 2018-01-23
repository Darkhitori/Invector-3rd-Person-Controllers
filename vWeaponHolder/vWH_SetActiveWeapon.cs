using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vWeaponHolder")]
	[Tooltip(" ")]
	public class vWH_SetActiveWeapon : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vWeaponHolder))] 
		public FsmOwnerDefault gameObject;
		
		public FsmBool active;
		
		public FsmBool everyFrame;

		vWeaponHolder theScript;
  

		public override void Reset()
		{
			gameObject = null;
			active = false;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vWeaponHolder>();


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
			
			theScript.SetActiveWeapon(active.Value);
			
		}

	}
}