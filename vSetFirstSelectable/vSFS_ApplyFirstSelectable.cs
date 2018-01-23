using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vSetFirstSelectable")]
	[Tooltip(" ")]
	public class vSFS_ApplyFirstSelectable : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vSetFirstSelectable))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject firstSelectable;
		
		public FsmBool everyFrame;

		vSetFirstSelectable theScript;
  

		public override void Reset()
		{
			gameObject = null;
			firstSelectable = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vSetFirstSelectable>();


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
			
			theScript.ApplyFirstSelectable(firstSelectable.Value);            
		}

	}
}