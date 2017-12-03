# Utilities
This project contains nuget packages for common utilities used across all projects.

## To push
1. Get key from myGet
2. Update package version to something higher
3. Use this command
```
dotnet nuget push SamplePackage.1.0.0.nupkg <your access token> --source https://www.myget.org/F/bluenebula-utilities/api/v3/index.json
```