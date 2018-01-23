using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vCollectMeleeControl")]
	[Tooltip(" ")]
	public class vCMC_HandleCollectableInput : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vCollectMeleeControl))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(vCollectableStandalone))]
		public FsmObject collectableStandAlone;
		
		public FsmBool everyFrame;

		vCollectMeleeControl theScript;
  

		public override void Reset()
		{
			gameObject = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vCollectMeleeControl>();


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
			var cInput = collectableStandAlone.Value as vCollectableStandalone;
			if (cInput == null)
			{
				return;
			}
			
			theScript.HandleCollectableInput(cInput);            
		}

	}
}