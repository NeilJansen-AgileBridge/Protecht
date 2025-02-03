using ProTecht.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace ProTecht.Permissions;

public class ProTechtPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ProTechtPermissions.GroupName);

        myGroup.AddPermission(ProTechtPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(ProTechtPermissions.MyPermission1, L("Permission:MyPermission1"));

        var personPermission = myGroup.AddPermission(ProTechtPermissions.People.Default, L("Permission:People"));
        personPermission.AddChild(ProTechtPermissions.People.Create, L("Permission:Create"));
        personPermission.AddChild(ProTechtPermissions.People.Edit, L("Permission:Edit"));
        personPermission.AddChild(ProTechtPermissions.People.Delete, L("Permission:Delete"));

        var quotePermission = myGroup.AddPermission(ProTechtPermissions.Quotes.Default, L("Permission:Quotes"));
        quotePermission.AddChild(ProTechtPermissions.Quotes.Create, L("Permission:Create"));
        quotePermission.AddChild(ProTechtPermissions.Quotes.Edit, L("Permission:Edit"));
        quotePermission.AddChild(ProTechtPermissions.Quotes.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProTechtResource>(name);
    }
}