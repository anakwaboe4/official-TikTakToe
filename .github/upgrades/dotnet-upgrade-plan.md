# .NET 10.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that an .NET 10.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 10.0 upgrade.
3. Upgrade TikTakToe.Core\TikTakToe.Core.csproj
4. Upgrade TikTakToe.Repositories\TikTakToe.Repositories.csproj
5. Upgrade TikTakToe.Engines\TikTakToe.Engines.csproj
6. Upgrade TikTakToe.Services\TikTakToe.Services.csproj
7. Upgrade TikTakToe.API\TikTakToe.API.csproj

## Settings

### Excluded projects

| Project name | Description |
|:-------------------------------|:---------------------------:|

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                                 | Current Version | New Version | Description                                   |
|:---------------------------------------------|:---------------:|:-----------:|:----------------------------------------------|
| Microsoft.AspNetCore.Authentication.JwtBearer | 9.0.0           | 10.0.0      | Recommended for .NET 10.0                     |
| Microsoft.AspNetCore.OpenApi                 | 9.0.0           | 10.0.0      | Recommended for .NET 10.0                     |
| Microsoft.EntityFrameworkCore.Design         | 9.0.0           | 10.0.0      | Recommended for .NET 10.0                     |
| Microsoft.EntityFrameworkCore.Sqlite         | 9.0.0           | 10.0.0      | Recommended for .NET 10.0                     |
| Microsoft.EntityFrameworkCore.Tools          | 9.0.0           | 10.0.0      | Recommended for .NET 10.0                     |
| Microsoft.Extensions.Logging                | 9.0.0           | 10.0.0      | Recommended for .NET 10.0                     |
| Microsoft.Identity.Web                      | 2.19.1          | 4.1.0       | Deprecated, move to latest LTS                |
| System.Formats.Asn1                         | 9.0.0           | 10.0.0      | Recommended for .NET 10.0                     |

### Project upgrade details

#### TikTakToe.Core\TikTakToe.Core.csproj modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net10.0`

#### TikTakToe.Repositories\TikTakToe.Repositories.csproj modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net10.0`
NuGet packages changes:
  - Microsoft.EntityFrameworkCore.Sqlite should be updated from `9.0.0` to `10.0.0`
  - Microsoft.EntityFrameworkCore.Tools should be updated from `9.0.0` to `10.0.0`

#### TikTakToe.Engines\TikTakToe.Engines.csproj modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net10.0`

#### TikTakToe.Services\TikTakToe.Services.csproj modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net10.0`

#### TikTakToe.API\TikTakToe.API.csproj modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net10.0`
NuGet packages changes:
  - Microsoft.AspNetCore.Authentication.JwtBearer should be updated from `9.0.0` to `10.0.0`
  - Microsoft.AspNetCore.OpenApi should be updated from `9.0.0` to `10.0.0`
  - Microsoft.EntityFrameworkCore.Design should be updated from `9.0.0` to `10.0.0`
  - Microsoft.EntityFrameworkCore.Sqlite should be updated from `9.0.0` to `10.0.0`
  - Microsoft.Extensions.Logging should be updated from `9.0.0` to `10.0.0`
  - Microsoft.Identity.Web should be updated from `2.19.1` to `4.1.0` (deprecated, move to latest LTS)
  - System.Formats.Asn1 should be updated from `9.0.0` to `10.0.0`
