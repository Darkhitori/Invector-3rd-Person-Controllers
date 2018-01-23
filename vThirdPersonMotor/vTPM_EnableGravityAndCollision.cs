using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThirdPersonMotor")]
	[Tooltip("Turn rigidbody gravity on the uncheck the capsulle collider as Trigger when the animation has finish playing ")]
	public class vTPM_EnableGravityAndCollision : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThirdPersonMotor))] 
		public FsmOwnerDefault gameObject;
		
		public FsmFloat normalizedTime;
		
		public FsmBool everyFrame;

		vThirdPersonMotor theScript;
  

		public override void Reset()
		{
			gameObject = null;
			normalizedTime = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vThirdPersonMotor>();


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
			
			theScript.EnableGravityAndCollision(normalizedTime.Value);            
		}

	}
}