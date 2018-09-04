# Introduction 

This repo contains an ASP NET Core Middleware item for adding the [X-Robots-Tag HTTP header](https://developers.google.com/search/reference/robots_meta_tag).

The header tells all web crawler bots whether they are allowed to index the page that it finds (along with any hyperlinks it finds on the page). This is vital as the robots.txt file can, and often is, ignored by web crawlers.

# Getting Started

## Running the Example

Included in this repo, there is an `example` directory which contains an example ASP NET Core MVC app which responds to all requests for `/`. The response includes a string array of all HTTP headers added into the generated response.

## Consuming the Middleware

Take a look through the `example` project to see how it is consumed. The following is a TL;DR:

- Add a reference to the NuGet package for this middleware in your ASP NET Core project
   - (link incoming)
- Add the following two using statements to your `Startup.cs`:
``` charp
using Audacia.Extensions;
using Audacia.Middleware.Helpers;
```
- Add the following to your `Configure` method:
``` csharp
app.UseXRobotsMetaTagMiddleware();
```

## Note

By default, the middleware will add the X-Robots-Tag with the following value:

``` shell
X-Robots-Tag: none, noarchive, nosnippet, notranslate, noimageindex
```

A future version of this middelware will expose a builder which will allow you to create a custom value.

---

# Build

Building this repo can be done in two different ways; depending on the tools that you have installed, you can choose between the following

## Building with an IDE

Simply open the `Audacia.Middleware.XRobotsMetaTagMiddleware.sln` with Visual Studio/Visual Studio Code/Rider/etc. and build the solution.

## Building with docker

Open a terminal at the root of the repo and issue the following command:

``` shell
docker build .
```

This build process does not require an IDE or a version of the .NET Core SDK to be installed on your machine in order to build the middleware.