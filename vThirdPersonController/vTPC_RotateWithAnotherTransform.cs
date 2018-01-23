using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThirdPersonController")]
	[Tooltip("Use another transform as  reference to rotate ")]
	public class vTPC_RotateWithAnotherTransform : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThirdPersonController))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject referenceTransform;
		
		public FsmBool everyFrame;

		vThirdPersonController theScript;
  

		public override void Reset()
		{
			gameObject = null;
			referenceTransform = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vThirdPersonController>();


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
			
			theScript.RotateWithAnotherTransform(referenceTransform.Value.transform);            
		}

	}
}