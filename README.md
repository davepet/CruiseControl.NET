# CruiseControl.NET

**CruiseControl.NET** is an automated continuous integration server for the .NET platform. It is a C# port of CruiseControl for Java.

## Releases
Releases up to 1.8.5 can be downloaded from [sourceforge.net](https://sourceforge.net/projects/ccnet/)


## How to build
We provide the following build scripts with CruiseControl.NET:

### Windows
1. ```ps build.ps1 --target=default```

It will display the existing targets in the cake build script.

2. ```ps build.ps1 --target=build```

Use this if you want to build the project.

3. ```ps build.ps1 --target=build-all```

Full build, including running tests, doing some code analysis and packaging artifacts.
Cleanup -> Init -> Build -> Unit Tests -> code Analysis -> Packaging

4. ```ps build.ps1 --target=run-tests```

This will call only the runUnitTests target in ccnet.build script.
Cleanup -> Init -> Build -> Unit Tests

5. ```ps build.ps1 --target=package```

This only build and package the CruiseControl.NET distribution.
Cleanup -> Init -> Build -> Packaging

The packaged distribution can be found in the "Publish" folder.

6. ```ps build.ps1 --target=web-packages```

This builds and packages the project WebDashboards.

### Linux
If you just cloned the CruiseControl.NET repository, run ```chmod u+x build.sh``` so you have execute permission on the build script.

1. ```./build.sh --target=default```

It will display the existing targets in the cake build script.

2. ```./build.sh --target=build```

Use this if you want to build the project.

3. ```./build.sh --target=build-all```

Full build, including running tests, doing some code analysis and packaging artifacts.
Cleanup -> Init -> Build -> Unit Tests -> code Analysis -> Packaging

4. ```./build.sh --target=run-tests```

This will call only the runUnitTests target in ccnet.build script.
Cleanup -> Init -> Build -> Unit Tests

5. ```./build.sh --target=package```

This only build and package the CruiseControl.NET distribution.
Cleanup -> Init -> Build -> Packaging

The packaged distribution can be found in the "Publish" folder.

6. ```./build.sh --target=web-packages```

This builds and packages the project WebDashboards.
