using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/v_SpriteHealth")]
	[Tooltip(" ")]
	public class vSH_Damage : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(v_SpriteHealth))] 
		public FsmOwnerDefault gameObject;
		
		public FsmFloat value;
		
		public FsmBool everyFrame;

		v_SpriteHealth theScript;
  

		public override void Reset()
		{
			gameObject = null;
			value = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<v_SpriteHealth>();


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
			
			theScript.Damage(value.Value);            
		}

	}
}