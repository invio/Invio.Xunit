<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Table of Contents**  *generated with [DocToc](https://github.com/thlorenz/doctoc)*

- [Invio.Xunit](#invioxunit)
- [Installation](#installation)
- [Noteworthy Features](#noteworthy-features)
  - [Category Attributes](#category-attributes)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

# Invio.Xunit

[![Appveyor](https://ci.appveyor.com/api/projects/status/avua5cncyctrhfn7/branch/master?svg=true)](https://ci.appveyor.com/project/invio/invio-xunit/branch/master)
[![Travis CI](https://img.shields.io/travis/invio/Invio.Xunit.svg?maxAge=3600&label=travis)](https://travis-ci.org/invio/Invio.Xunit)
[![NuGet](https://img.shields.io/nuget/v/Invio.Xunit.svg)](https://www.nuget.packages/org/Invio.Xunit/)
[![Coverage](https://coveralls.io/repos/github/invio/Invio.Xunit/badge.svg?branch=master)](https://coveralls.io/github/invio/Invio.Xunit?branch=master)

Invio's extensions to xunit that is based on our coding practices and standards.

# Installation
The latest version of this package is available on MyGet. To install include the myget feed in your NuGet.Config at the root of your project, and add the dependency to your project.json.

```shell
PM> Install-Package Invio.Xunit
```

# Noteworthy Features
Features included here are what makes this library useful

## Category Attributes

Category attributes allow you to specifc strongly typed classes which add the category as traits to the test method or class. This will allow for filtering execution runs based on these categories.

```csharp
using Invio.Xunit;

...

[UnitTest]
public class UnitTestFixture {
}

[IntegrationTest]
public class IntegrationTestFixture {
}

public class TestFixture {
    [UnitTest]
    [Fact]
    pulic void UnitTestMethod() {
    }

    [IntegrationTest]
    [Fact]
    pulic void IntegrationTestMethod() {
    }
}
```

Filtering which tests run via the command line is based on using either `-trait` or `-notrait`.

```shell
# This will just run tests that are marked as Unit Tests
$> dotnet test -trait "Category=Unit"

# This will just run tests that are not marked as Integration or Benchmark Tests
$> dotnet test -notrait "Category=Integration" -notrait "Category=Benchmark"
```
