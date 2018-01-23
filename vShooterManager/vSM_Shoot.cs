using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vShooterManager")]
	[Tooltip(" ")]
	public class vSM_Shoot : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vShooterManager))] 
		public FsmOwnerDefault gameObject;
		
		public FsmVector3 aimPosition;
		public FsmBool applyHipfirePrecision;
		
		public FsmBool everyFrame;

		vShooterManager theScript;
  
		public override void Reset()
		{
			gameObject = null;
			aimPosition = new Vector3(0,0,0);
			applyHipfirePrecision = false;
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
			
			theScript.Shoot(aimPosition.Value, applyHipfirePrecision.Value);            
		}

	}
}