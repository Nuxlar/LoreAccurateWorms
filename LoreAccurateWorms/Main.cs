using BepInEx;
using RoR2;
using RoR2.ContentManagement;
using R2API;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LoreAccurateWorms
{
  [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
  public class Main : BaseUnityPlugin
  {
    public const string PluginGUID = PluginAuthor + "." + PluginName;
    public const string PluginAuthor = "Nuxlar";
    public const string PluginName = "LoreAccurateWorms";
    public const string PluginVersion = "1.0.1";

    internal static Main Instance { get; private set; }
    public static string PluginDirectory { get; private set; }

    public ItemDef itemDef;
    private string lore =
    """
    Providence stood motionless, staring at the locked gate.

    Where, just a moment ago, his brother had once stood.

    And now, his brother was gone.

    Providence felt sick. He collapsed to his knees, retching as the gravity of what he had just done washed over him like a tidal wave.

    For a while, Providence sat at the footsteps of the gate. By now, his brother would have realized what had happened.

    Now, there was no going back. He had made his choice.

    Providence's gaze drifted to the remains of the meal he and his brother had shared prior to the activation of the gate. The last time the two had enjoyed a civil, even jovial, discussion. Providence's heart ached.

    After a while, the ache subsided. Only an emptiness remained.

    With a sigh, Providence took one of the cups his brother had delicately carved from stone. And one last time, he raised the cup to the sky- a toast to the beginning of a new age for Petrichor V.
    """;

    public void Awake()
    {
      Instance = this;

      Log.Init(Logger);
      TweakAssets();
      LanguageAPI.Add("LORE_ACCURATE_WORM_LOG", lore);
    }

    private void TweakAssets()
    {
      AssetReferenceT<ItemDef> itemRef = new AssetReferenceT<ItemDef>(RoR2BepInExPack.GameAssetPaths.Version_1_39_0.RoR2_DLC3_Items_WyrmOnHit.WyrmOnHit_asset);
      AssetAsyncReferenceManager<ItemDef>.LoadAsset(itemRef).Completed += (x) =>
      {
        this.itemDef = x.Result;

        itemDef.loreToken = "LORE_ACCURATE_WORM_LOG";
      };
    }
  }
}