﻿using Volo.Abp.Account;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.AuditLogging;
using Volo.Abp.LanguageManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Abp.Gdpr;
using Volo.Abp.OpenIddict;

namespace ProTecht;

[DependsOn(
    typeof(ProTechtDomainSharedModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpAccountPublicApplicationContractsModule),
    typeof(AbpAccountAdminApplicationContractsModule),
    typeof(AbpAuditLoggingApplicationContractsModule),
    typeof(AbpOpenIddictProApplicationContractsModule),
    typeof(TextTemplateManagementApplicationContractsModule),
    typeof(LanguageManagementApplicationContractsModule),
    typeof(AbpGdprApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule)
)]
public class ProTechtApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        ProTechtDtoExtensions.Configure();
    }
}
