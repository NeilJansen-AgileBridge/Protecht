using ProTecht.Localization;
using Volo.Abp.Application.Services;

namespace ProTecht;

/* Inherit your application services from this class.
 */
public abstract class ProTechtAppService : ApplicationService
{
    protected ProTechtAppService()
    {
        LocalizationResource = typeof(ProTechtResource);
    }
}
