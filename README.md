# Introduction

This repo contains an ASP.NET Core Middleware for adding the [X-Robots-Tag HTTP header](https://developers.google.com/search/reference/robots_meta_tag).

The header tells all web crawler bots whether they are allowed to index the page that it finds (along with any hyperlinks it finds on the page). This is vital as the robots.txt file can be, and often is, ignored by web crawlers.

# Getting Started

## Running the Example

Included in this repo, there is an `example` directory which contains an example ASP.NET Core app which responds to all requests for `/`. The response includes a string array of all HTTP headers added into the generated response.

## Consuming the Middleware

The `IApplicationBuilder` extension method `UseXRobotsMetaTagMiddleware` adds the middleware to the pipeline. It takes a single parameter of type `XRobotsModel`, an instance of which can be created using `XRobotsModelBuilder`. There are two main use cases:
- If you are writing a private app or API (i.e. one that web crawlers should not index) you can use the `XRobotsModelBuilder.CreatePrivateAppDefault()` method
- If you are writing a public-facing app then you should use `XRobotsModelBuilder` to create your own custom set of directives

For example, using the private app default directives looks like this:
``` csharp
app.UseXRobotsMetaTagMiddleware(XRobotsModelBuilder.CreatePrivateAppDefault().Build());
```

# Change History
The `Audacia.Middleware.RobotsMetaTagMiddleware` repository change history can be found in this [changelog](./CHANGELOG.md):


# Contributing
We welcome contributions! Please feel free to check our [Contribution Guidlines](https://github.com/audaciaconsulting/.github/blob/main/CONTRIBUTING.md) for feature requests, issue reporting and guidelines.
