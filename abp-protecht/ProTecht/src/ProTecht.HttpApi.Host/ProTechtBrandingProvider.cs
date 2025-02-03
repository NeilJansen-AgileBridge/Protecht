using Microsoft.Extensions.Localization;
using ProTecht.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ProTecht;

[Dependency(ReplaceServices = true)]
public class ProTechtBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ProTechtResource> _localizer;

    public ProTechtBrandingProvider(IStringLocalizer<ProTechtResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
