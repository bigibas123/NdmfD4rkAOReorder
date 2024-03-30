using System.Reflection;
using VRC.SDKBase.Editor.BuildPipeline;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDKBase.Editor;

namespace cc.dingemans.bigibas123.Ndmfd4rkAOReorder
{
	public class D4rkAOHookRemover
	{
		private static readonly string TAG = "[D4rkAOReordered]";

		[InitializeOnLoadMethod]
		static void go()
		{
			VRCSdkControlPanel.OnSdkPanelEnable += (sender, e) =>
			{
				FixList();

				if (VRCSdkControlPanel.TryGetBuilder<IVRCSdkBuilderApi>(out var builder))
				{
					builder.OnSdkBuildStart += (sender2, target) => { FixList(); };
				}
			};
		}

		private static List<IVRCSDKPreprocessAvatarCallback> GetAllPreprocessAvatarCallbacks()
		{
			var callbackField = typeof(VRCBuildPipelineCallbacks).GetField("_preprocessAvatarCallbacks",
				BindingFlags.DeclaredOnly | BindingFlags.GetField | BindingFlags.IgnoreCase | BindingFlags.NonPublic |
				BindingFlags.Static);
			List<IVRCSDKPreprocessAvatarCallback> list =
				(List<IVRCSDKPreprocessAvatarCallback>)callbackField?.GetValue(null);
			return list;
		}

		private static void FixList()
		{
			var cbs = GetAllPreprocessAvatarCallbacks();
			if (cbs is null)
			{
				Debug.LogError(
					$"{TAG} Could not find PreprocessAvatarCallbacks list, this probably means that VRCSDK has updated but this plugin hasn't");
				return;
			}

			bool found = false;
			cbs.RemoveAll(callback =>
			{
				switch (callback.GetType().FullName)
				{
					
					case "d4rkpl4y3r.AvatarOptimizer.AvatarBuildHook":
						Debug.Log($"{TAG} Found d4rkpl4y3r.AvatarOptimizer.AvatarBuildHook PreuploadHook");
						found = true;
						return true;
					default:
						return false;
				}
			});
			if (!found)
			{
				Debug.LogError("Did not find D4rkAvatarOptimizer in upload hooks, this will probably mean the build will fail or behave weird");
			}
		}
	}
}
