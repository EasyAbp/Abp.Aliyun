# Abp.Aliyun

[![ABP version](https://img.shields.io/badge/dynamic/xml?style=flat-square&color=yellow&label=abp&query=%2F%2FProject%2FPropertyGroup%2FAbpVersion&url=https%3A%2F%2Fraw.githubusercontent.com%2FEasyAbp%2FAbp.Aliyun%2Fmaster%2FDirectory.Build.props)](https://abp.io)
[![NuGet](https://img.shields.io/nuget/v/EasyAbp.Abp.Aliyun.Common.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.Abp.Aliyun.Common)
[![NuGet Download](https://img.shields.io/nuget/dt/EasyAbp.Abp.Aliyun.Common.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.Abp.Aliyun.Common)
[![Discord online](https://badgen.net/discord/online-members/S6QaezrCRq?label=Discord)](https://discord.gg/S6QaezrCRq)
[![GitHub stars](https://img.shields.io/github/stars/EasyAbp/Abp.Aliyun?style=social)](https://www.github.com/EasyAbp/Abp.Aliyun)

专门为 ABP vNext 框架开发的阿里云 SDK 模块。

## 一、简要介绍

**EasyAbp.Abp.Aliyun** 库是针对于阿里云 API 进行了二次封装模块，与 ABP vNext 框架深度集成。

## 二、基本配置

开发人员根据自身项目情况，选择需要使用的模块。例如我需要使用阿里云的短信服务，首先需要添加 **EasyAbp.Abp.Aliyun.Sms** 库的引用。添加完成之后，在任意 `AbpModule` 上面注明 `DependsOn` 依赖，并在任意生命周期通过 `Configure<TOptions>()` 方法配置对应的 Options。

```csharp
[DependsOn(typeof(AbpAliyunSmsModule))]
public class TestWebModule : AbpModule
{
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAliyunOptions>(op =>
            {
                // 阿里云 API 的访问 Id。
                op.AccessKeyId = "Key";
                // 阿里云 API 的访问密钥。
                op.AccessKeySecret = "Secret";
            });
        }
}
```

## 三、API 使用说明

- **[短信服务(Short Message Service)](/docs/Sms.md)**
- **[云解析 DNS(Alibaba Cloud DNS)]()**

