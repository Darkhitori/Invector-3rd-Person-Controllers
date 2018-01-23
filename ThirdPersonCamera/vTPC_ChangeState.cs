using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThirdPersonCamera")]
	[Tooltip("Change CameraState. Change State using look at point if the cameraMode is FixedPoint ")]
	public class vTPC_ChangeState : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThirdPersonCamera))] 
		public FsmOwnerDefault gameObject;
		
		public enum ChangeState
		{
			stateName_hasSmooth,
			stateName_pointName_hasSmooth
		}
		
		public ChangeState methods;
		
		public FsmString stateName;
		
		public FsmString pointName;
		
		public FsmBool hasSmooth;
		
		public FsmBool everyFrame;

		vThirdPersonCamera theScript;
  

		public override void Reset()
		{
			gameObject = null;
			methods =  ChangeState.stateName_hasSmooth;
			stateName = "";
			pointName = "";
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vThirdPersonCamera>();


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
			
			switch(methods)
			{
			case ChangeState.stateName_hasSmooth:
				theScript.ChangeState(stateName.Value, hasSmooth.Value);
				break;
			case ChangeState.stateName_pointName_hasSmooth:
				theScript.ChangeState(stateName.Value, pointName.Value, hasSmooth.Value);
				break;
			}
			            
		}

	}
}