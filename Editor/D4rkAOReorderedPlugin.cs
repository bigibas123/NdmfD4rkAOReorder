using System.IO;
using System.Runtime.CompilerServices;
using d4rkpl4y3r.AvatarOptimizer;
using nadena.dev.ndmf;
using tk.dingemans.bigibas123.Ndmfd4rkAOReorder;
using UnityEngine;

[assembly: ExportsPlugin(typeof(D4rkAOReorderedPlugin))]

namespace tk.dingemans.bigibas123.Ndmfd4rkAOReorder
{
	public class D4rkAOReorderedPlugin : Plugin<D4rkAOReorderedPlugin>
	{
		public override string QualifiedName => "tk.dingemans.bigibas123.Ndmfd4rkAOReorder.D4rkAOReorderedPlugin";
		public override string DisplayName => "D4rkAO Reordered";

		protected override void Configure()
		{
			InPhase(BuildPhase.Optimizing)
				.AfterPlugin("com.anatawa12.avatar-optimizer")
				.AfterPlugin("nadena.dev.modular-avatar")
				.AfterPlugin("tk.dingemans.bigibas123.NdmfVrcfReorder.VrcfReorderedPlugin")
				.Run("D4rkAO but at a non-default time", ctx =>
				{
					//d4rkpl4y3r.AvatarOptimizer.
					AvatarBuildHook hook = new AvatarBuildHook();
					if (!hook.OnPreprocessAvatar(ctx.AvatarRootObject))
					{
						throw new InvalidDataException("D4rke returned false, look at the logs for more details");
					}
					Debug.LogError("Doing nothing now!");
				});
		}
		
	}
}