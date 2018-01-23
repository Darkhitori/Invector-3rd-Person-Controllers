using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vFindSpawnPoint")]
	[Tooltip(" ")]
	public class vFSP_AlighObjetToSpawnPoint : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vFindSpawnPoint))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject target;
		
		public FsmString spawnPointName;
		
		public FsmBool everyFrame;

		vFindSpawnPoint theScript;
  

		public override void Reset()
		{
			gameObject = null;
			target = null;
			spawnPointName = "";
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vFindSpawnPoint>();


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
			
			theScript.AlighObjetToSpawnPoint(target.Value, spawnPointName.Value);            
		}

	}
}