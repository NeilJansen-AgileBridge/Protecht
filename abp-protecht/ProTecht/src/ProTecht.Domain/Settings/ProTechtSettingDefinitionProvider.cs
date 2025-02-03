using Volo.Abp.Settings;

namespace ProTecht.Settings;

public class ProTechtSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ProTechtSettings.MySetting1));
    }
}
