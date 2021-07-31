# Abp.Aliyun.Sms

## 一、基本配置

### 1.1 模块的引用

### 1.2 模块的配置

### 二、功能支持情况

#### 2.1.1 发送短信

| API          | 功能         | 是否支持                                                     |
| ------------ | ------------ | ------------------------------------------------------------ |
| SendBatchSms | 批量发送短信 | ![Support](https://img.shields.io/badge/-支持-brightgreen.svg) |
| SendSms      | 发送短信     | ![Support](https://img.shields.io/badge/-支持-brightgreen.svg) |

#### 2.1.2 查询发送记录

| API              | 功能             | 是否支持                                                     |
| ---------------- | ---------------- | ------------------------------------------------------------ |
| QuerySendDetails | 查询短信发送状态 | ![Support](https://img.shields.io/badge/-支持-brightgreen.svg) |

#### 2.1.3 短信签名

| API           | 功能                   | 是否支持                                                     |
| ------------- | ---------------------- | ------------------------------------------------------------ |
| AddSmsSign    | 申请短信签名           | ![NotSupport](https://img.shields.io/badge/-%E4%B8%8D%E6%94%AF%E6%8C%81-red.svg) |
| DeleteSmsSign | 删除短信签名           | ![NotSupport](https://img.shields.io/badge/-%E4%B8%8D%E6%94%AF%E6%8C%81-red.svg) |
| ModifySmsSign | 修改未审核的短信签名   | ![NotSupport](https://img.shields.io/badge/-%E4%B8%8D%E6%94%AF%E6%8C%81-red.svg) |
| QuerySmsSign  | 查询短信签名的审核状态 | ![NotSupport](https://img.shields.io/badge/-%E4%B8%8D%E6%94%AF%E6%8C%81-red.svg) |

#### 2.1.4 短信模板

| API               | 功能                   | 是否支持                                                     |
| ----------------- | ---------------------- | ------------------------------------------------------------ |
| AddSmsTemplate    | 申请短信模板           | ![NotSupport](https://img.shields.io/badge/-%E4%B8%8D%E6%94%AF%E6%8C%81-red.svg) |
| DeleteSmsTemplate | 删除短信模板           | ![NotSupport](https://img.shields.io/badge/-%E4%B8%8D%E6%94%AF%E6%8C%81-red.svg) |
| ModifySmsTemplate | 修改未审核的短信模板   | ![NotSupport](https://img.shields.io/badge/-%E4%B8%8D%E6%94%AF%E6%8C%81-red.svg) |
| QuerySmsTemplate  | 查询短信模板的审核状态 | ![NotSupport](https://img.shields.io/badge/-%E4%B8%8D%E6%94%AF%E6%8C%81-red.svg) |

#### 2.1.5 回执消息

> 关于阿里云的回执消息，本模块统一使用的是 HTTP API 的方式进行处理。当阿里云完成某项业务事件时，会调用模块提供的 API 接口通知开发人员业务结果。

| API               | 功能             | 是否支持                                                     |
| ----------------- | ---------------- | ------------------------------------------------------------ |
| SmsUp             | 上行短信消息回执 | ![NotSupport](https://img.shields.io/badge/-%E4%B8%8D%E6%94%AF%E6%8C%81-red.svg) |
| SmsReport         | 短信发送状态回执 | ![NotSupport](https://img.shields.io/badge/-%E4%B8%8D%E6%94%AF%E6%8C%81-red.svg) |
| SignSmsReport     | 短信签名审核回执 | ![NotSupport](https://img.shields.io/badge/-%E4%B8%8D%E6%94%AF%E6%8C%81-red.svg) |
| TemplateSmsReport | 短信模板审核回执 | ![NotSupport](https://img.shields.io/badge/-%E4%B8%8D%E6%94%AF%E6%8C%81-red.svg) |

### 三、功能的用法

TODO
