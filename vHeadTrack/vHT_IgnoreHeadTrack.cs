using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vHeadTrack")]
	[Tooltip(" ")]
	public class vHT_IgnoreHeadTrack : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vHeadTrack))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool ignoreHeadTrack;
		
		public FsmBool everyFrame;

		vHeadTrack theScript;
  

		public override void Reset()
		{
			gameObject = null;
			ignoreHeadTrack = false;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vHeadTrack>();


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
			
			ignoreHeadTrack.Value = theScript.IgnoreHeadTrack();
				
		}

	}
}