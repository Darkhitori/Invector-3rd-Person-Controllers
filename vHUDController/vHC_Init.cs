using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vHUDController")]
	[Tooltip(" ")]
	public class vHC_Init : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vHUDController))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(vThirdPersonController))]
		public FsmObject cc;
		
		public FsmBool everyFrame;

		vHUDController theScript;
  

		public override void Reset()
		{
			gameObject = null;
			cc = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vHUDController>();


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
			var vCon = cc.Value as vThirdPersonController;
			if (vCon == null)
			{
				return;
			}
			
			theScript.Init(vCon);            
		}

	}
}