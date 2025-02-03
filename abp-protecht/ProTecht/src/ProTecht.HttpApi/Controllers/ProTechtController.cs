using ProTecht.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ProTecht.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ProTechtController : AbpControllerBase
{
    protected ProTechtController()
    {
        LocalizationResource = typeof(ProTechtResource);
    }
}
