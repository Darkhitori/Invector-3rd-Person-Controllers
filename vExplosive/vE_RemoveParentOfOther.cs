using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vExplosive")]
	[Tooltip(" ")]
	public class vE_RemoveParentOfOther : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vExplosive))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(Transform))]
		public FsmObject other;
		
		public FsmBool everyFrame;

		vExplosive theScript;
  

		public override void Reset()
		{
			gameObject = null;
			other = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vExplosive>();


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
			var vOther = other.Value as Transform;
			if(vOther == null)
			{
				return;
			}
			
			theScript.RemoveParentOfOther(vOther);            
		}

	}
}