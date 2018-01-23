using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vShooterWeapon")]
	[Tooltip("Set look target point to Zoom scope camera ")]
	public class vSW_SetScopeLookTarget : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vShooterWeapon))] 
		public FsmOwnerDefault gameObject;
		
		public FsmVector3 point;
		
		public FsmBool everyFrame;

		vShooterWeapon theScript;
  
		public override void Reset()
		{
			gameObject = null;
			point = new Vector3(0,0,0);
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
			
			theScript.SetScopeLookTarget(point.Value);            
		}

	}
}