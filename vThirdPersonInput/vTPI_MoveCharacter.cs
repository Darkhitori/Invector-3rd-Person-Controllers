using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThirdPersonInput")]
	[Tooltip(" ")]
	public class vTPI_MoveCharacter : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThirdPersonInput))] 
		public FsmOwnerDefault gameObject;
		
		public enum MoveCharacter
		{
			position_rotateToDirection,
			transform_rotateToDirection
		}
		
		public MoveCharacter methods;
		
		public FsmVector3 position;
		
		public FsmGameObject transform;
		
		public FsmBool rotateToDirection;
		
		public FsmBool everyFrame;

		vThirdPersonInput theScript;
  

		public override void Reset()
		{
			gameObject = null;
			methods = MoveCharacter.position_rotateToDirection;
			position = new Vector3(0,0,0);
			transform = null;
			rotateToDirection = true;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vThirdPersonInput>();


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
			
			switch (methods)
			{
			case MoveCharacter.position_rotateToDirection:
				theScript.MoveCharacter(position.Value, rotateToDirection.Value);
				break;
			case MoveCharacter.transform_rotateToDirection:
				theScript.MoveCharacter(transform.Value.transform, rotateToDirection.Value);
				break;
			}
			            
		}

	}
}