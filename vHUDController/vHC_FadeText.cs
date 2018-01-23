using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vHUDController")]
	[Tooltip(" ")]
	public class vHC_FadeText : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vHUDController))] 
		public FsmOwnerDefault gameObject;
		
		public FsmString textToFade;
		
		public FsmFloat textTime;
		
		public FsmFloat fadeTime;
		
		public FsmBool everyFrame;

		vHUDController theScript;
  

		public override void Reset()
		{
			gameObject = null;
			textToFade = "";
			textTime = null;
			fadeTime = null;
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
			
			theScript.FadeText(textToFade.Value, textTime.Value, fadeTime.Value);            
		}

	}
}