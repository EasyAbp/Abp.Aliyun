# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

# List of projects
$projects = (

    "src/EasyAbp.Abp.Aliyun.Common",
    "src/EasyAbp.Abp.Aliyun.LiveVideo",
    "src/EasyAbp.Abp.Aliyun.Sms"
)