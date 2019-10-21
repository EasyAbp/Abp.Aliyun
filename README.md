# Zony.Abp.Aliyun

## 一、简要介绍

**Zony.Abp.Aliyun** 库是针对于阿里云 API 进行了二次封装模块，与 ABP vNext 框架深度集成。

## 二、基本配置

开发人员根据自身项目情况，选择需要使用的模块。例如我需要使用阿里云的短信服务，首先需要添加 **Zony.Abp.Aliyun.Sms** 库的引用。添加完成之后，在任意 `AbpModule` 上面注明 `DependsOn` 依赖，并在任意生命周期通过 `Configure<TOptions>()` 方法配置对应的 Options。

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

- **[短信服务(Short Message Service)](./doc/Sms.md)**
- **[云解析 DNS(Alibaba Cloud DNS)]()**

