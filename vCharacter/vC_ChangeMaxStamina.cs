using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/Character")]
	[Tooltip("Change the MaxStamina of Character ")]
	public class vC_ChangeMaxStamina : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vCharacter))] 
		public FsmOwnerDefault gameObject;

		public FsmInt value;
		
		public FsmBool everyFrame;

		vCharacter theScript;
  

		public override void Reset()
		{
			gameObject = null;
			value = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vCharacter>();


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

			theScript.ChangeMaxStamina(value.Value);            
		}

	}
}