#***************************************
#Arguments
#%1: Build Configuration (Release/Debug)
#%2: Target (cpu/cuda)
#%3: Architecture (32/64)
#%4: Platform (desktop)
#%5: Optional Argument
#   if build on Windows, Visual Studio Version [2015/2017/2019]
#   if Target is cuda, CUDA version if Target is cuda [90/91/92/100/101]
#***************************************
Param
(
   [Parameter(
   Mandatory=$True,
   Position = 1
   )][string]
   $Configuration,

   [Parameter(
   Mandatory=$True,
   Position = 2
   )][string]
   $Target,

   [Parameter(
   Mandatory=$True,
   Position = 3
   )][int]
   $Architecture,

   [Parameter(
   Mandatory=$False,
   Position = 4
   )][string]
   $Platform,

   [Parameter(
   Mandatory=$False,
   Position = 5
   )][string]
   $Option1,

   [Parameter(
   Mandatory=$False,
   Position = 8
   )][string]
   $Option2
)

# import class and function
$ScriptPath = $PSScriptRoot
Write-Host "Build"(Split-Path $ScriptPath -Leaf) -ForegroundColor Green

$SrcPath = Split-Path $ScriptPath -Parent
$OpenPoseDotNetRoot = Split-Path $SrcPath -Parent
$NugetPath = Join-Path $OpenPoseDotNetRoot "nuget" | `
             Join-Path -ChildPath "BuildUtils.ps1"
import-module $NugetPath -function *

$Config = [Config]::new($OpenPoseDotNetRoot, $Configuration, $Target, $Architecture, $Platform, $Option1, $Option2)
Build -Config $Config