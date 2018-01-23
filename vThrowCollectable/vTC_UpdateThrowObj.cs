using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThrowCollectable")]
	[Tooltip(" ")]
	public class vTC_UpdateThrowObj : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThrowCollectable))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(Rigidbody))]
		public FsmObject throwObj;
		
		public FsmBool everyFrame;

		vThrowCollectable theScript;
  

		public override void Reset()
		{
			gameObject = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vThrowCollectable>();


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
			var vThrow = throwObj.Value as Rigidbody;
			if (vThrow == null)
			{
				return;
			}
			
			theScript.UpdateThrowObj(vThrow);            
		}

	}
}