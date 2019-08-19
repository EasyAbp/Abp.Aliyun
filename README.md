# Zony.Abp.Aliyun

## 一、简要介绍

**Zony.Abp.Aliyun** 库是针对于阿里云 API 进行了二次封装模块，与 ABP vNext 框架深度集成。

## 二、使用方式

开发人员根据自身项目情况，选择需要使用的模块。例如我需要使用阿里云的短信服务，首先需要添加 **Zony.Abp.Aliyun** 库的引用。添加完成之后，在任意 `AbpModule` 上面注明 `DependsOn` 依赖，并在任意生命周期通过 `Configure<TOptions>()` 方法配置对应的 Options。

```csharp
[DependsOn(typeof(AbpAliyunSmsModule))]
public class TestWebModule : AbpModule
{
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAliyunOptions>(op =>
            {
                op.AccessKeyId = "Key";
                op.AccessKeySecret = "Secret";
            });
        }
}
```

例如我需要发送短信，可以直接注入 `IAliyunApiRequester` 对象，传入需要的 `ICommonRequest` ，即可完成 API 调用。

```csharp
public class SendSmsRequest_Tests : AbpAliyunTestBase<AbpAliyunSmsTestsModule>
{
    private readonly IAliyunApiRequester _aliyunApiRequester;
    
    private readonly AbpAliyunSmsOptions _abpAliyunSmsOptions;
    private readonly AbpAliyunOptions _aliyunOptions;

    public SendSmsRequest_Tests()
    {
        _aliyunApiRequester = GetRequiredService<IAliyunApiRequester>();
        _abpAliyunSmsOptions = GetRequiredService<IOptions<AbpAliyunSmsOptions>>().Value;
        _aliyunOptions = GetRequiredService<IOptions<AbpAliyunOptions>>().Value;

        _aliyunOptions.AccessKeyId = AbpAliyunSmsTestsConsts.AccessKeyId;
        _aliyunOptions.AccessKeySecret = AbpAliyunSmsTestsConsts.AccessKeySecret;
    }

    [Fact]
    public async Task Should_Return_Code_OK()
    {
        // Arrange
        var request = new SendSmsRequest(AbpAliyunSmsTestsConsts.TargetPhoneNumber, 
            AbpAliyunSmsTestsConsts.CompanyName,
            AbpAliyunSmsTestsConsts.TemplateCode, 
            AbpAliyunSmsTestsConsts.TemplateParamJson);
        
        // Act
        var result = await _aliyunApiRequester.SendRequestAsync<SendSmsResponse>(request,
            _abpAliyunSmsOptions.EndPoint);
        
        // Assert
        result.ShouldNotBeNull();
        result.Code.ShouldBe("OK");
    }
}
```

## 三、API 支持情况

### 2.1 短信服务(Short Message Service)

#### 2.1.1 发送短信

| API          | 功能         | 是否支持 |
| ------------ | ------------ | -------- |
| SendBatchSms | 批量发送短信 | 否       |
| SendSms      | 发送短信     | 是       |

#### 2.1.2 查询发送记录

| API              | 功能             | 是否支持 |
| ---------------- | ---------------- | -------- |
| QuerySendDetails | 查询短信发送状态 | 否       |

#### 2.1.3 短信签名

| API           | 功能                   | 是否支持 |
| ------------- | ---------------------- | -------- |
| AddSmsSign    | 申请短信签名           | 否       |
| DeleteSmsSign | 删除短信签名           | 否       |
| ModifySmsSign | 修改未审核的短信签名   | 否       |
| QuerySmsSign  | 查询短信签名的审核状态 | 否       |

#### 2.1.4 短信模板

| API               | 功能                   | 是否支持 |
| ----------------- | ---------------------- | -------- |
| AddSmsTemplate    | 申请短信模板           | 否       |
| DeleteSmsTemplate | 删除短信模板           | 否       |
| ModifySmsTemplate | 修改未审核的短信模板   | 否       |
| QuerySmsTemplate  | 查询短信模板的审核状态 | 否       |

#### 2.1.5 回执消息

> 关于阿里云的回执消息，本模块统一使用的是 HTTP API 的方式进行处理。当阿里云完成某项业务事件时，会调用模块提供的 API 接口通知开发人员业务结果。

| API               | 功能             | 是否支持 |
| ----------------- | ---------------- | -------- |
| SmsUp             | 上行短信消息回执 | 否       |
| SmsReport         | 短信发送状态回执 | 否       |
| SignSmsReport     | 短信签名审核回执 | 否       |
| TemplateSmsReport | 短信模板审核回执 | 否       |

### 2.2 云解析 DNS(Alibaba Cloud DNS)

**已规划**