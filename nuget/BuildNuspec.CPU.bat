dotnet restore ..\src\OpenPoseDotNet
dotnet build -c Release ..\src\OpenPoseDotNet
nuget pack OpenPose.nuspec