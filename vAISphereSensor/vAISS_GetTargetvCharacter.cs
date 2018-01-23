using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/v_AISphereSensor")]
	[Tooltip(" ")]
	public class vAISS_GetTargetvCharacter : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(v_AISphereSensor))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		[UIHint(UIHint.Variable)]
		[ObjectType(typeof(vCharacter))]
		public FsmObject vChar;
		
		public FsmBool everyFrame;

		v_AISphereSensor theScript;
  

		public override void Reset()
		{
			gameObject = null;
			vChar = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<v_AISphereSensor>();


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
			
			vChar.Value = theScript.GetTargetvCharacter();            
		}

	}
}