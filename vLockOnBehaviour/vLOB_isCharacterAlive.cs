using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vLockOnBehaviour")]
	[Tooltip("Check if Current target(vCharacter) is Alive. Check if target is a vCharacter Alive ")]
	public class vLOB_isCharacterAlive : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vLockOnBehaviour))] 
		public FsmOwnerDefault gameObject;
		
		public enum isCharacterAlive
		{
			no_parameters,
			other
		}
		
		public isCharacterAlive methods;
		
		[ObjectType(typeof(Transform))]
		public FsmObject other;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool characterAlive;
		
		public FsmBool everyFrame;

		vLockOnBehaviour theScript;
  

		public override void Reset()
		{
			gameObject = null;
			methods = isCharacterAlive.no_parameters;
			other = null;
			characterAlive = false;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vLockOnBehaviour>();


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
			case isCharacterAlive.no_parameters:
				characterAlive.Value = theScript.isCharacterAlive();
				break;
			case isCharacterAlive.other:
				var vtrans = other.Value as Transform;
				if (vtrans == null)
				{
					return;
				}
				characterAlive.Value = theScript.isCharacterAlive(vtrans);
				break;
			}
			            
		}

	}
}