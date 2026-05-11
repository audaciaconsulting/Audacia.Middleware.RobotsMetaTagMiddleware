using System;
using Audacia.Middleware.RobotsMetaTagMiddleware.Helpers;
using Shouldly;
using Xunit;

namespace Audacia.Middleware.RobotsMetaTagMiddleware.Tests;

public class XRobotsModelDefaultsTests
{
    [Fact]
    public void Private_app_default_has_none_directive()
    {
        var model = XRobotsModelBuilder.CreatePrivateAppDefault().Build();

        var output = model.Render();

        output.ShouldContain("none");
    }

    [Fact]
    public void Private_app_default_has_noarchive_directive()
    {
        var model = XRobotsModelBuilder.CreatePrivateAppDefault().Build();

        var output = model.Render();

        output.ShouldContain("noarchive");
    }

    [Fact]
    public void Private_app_default_has_nosnippet_directive()
    {
        var model = XRobotsModelBuilder.CreatePrivateAppDefault().Build();

        var output = model.Render();

        output.ShouldContain("nosnippet");
    }

    [Fact]
    public void Private_app_default_has_notranslate_directive()
    {
        var model = XRobotsModelBuilder.CreatePrivateAppDefault().Build();

        var output = model.Render();

        output.ShouldContain("notranslate");
    }

    [Fact]
    public void Private_app_default_has_noimageindex_directive()
    {
        var model = XRobotsModelBuilder.CreatePrivateAppDefault().Build();

        var output = model.Render();

        output.ShouldContain("noimageindex");
    }

    [Fact]
    public void Private_app_default_with_unavailable_after_has_unavailable_after_directive()
    {
        var unavailableAfter = new DateTime(2022, 3, 4, 15, 56, 52);
        var model = XRobotsModelBuilder.CreatePrivateAppDefault().AddUnavailableAfter(unavailableAfter).Build();

        var output = model.Render();

        output.ShouldContain("unavailable_after: 04 Mar 2022 15:56:52 GMT");
    }

    [Fact]
    public void Private_app_default_with_bot_name_has_bot_name()
    {
        var model = XRobotsModelBuilder.CreatePrivateAppDefault().AddBotName("googlebot").Build();

        var output = model.Render();

        output.ShouldContain("googlebot:");
    }

    [Fact]
    public void Private_app_default_with_bot_name_has_directives()
    {
        var model = XRobotsModelBuilder.CreatePrivateAppDefault().AddBotName("googlebot").Build();

        var output = model.Render();

        output.ShouldContain("none");
    }

    [Fact]
    public void Private_app_default_terminates_with_the_final_directive()
    {
        var model = XRobotsModelBuilder.CreatePrivateAppDefault().Build();

        var output = model.Render();

        output.ShouldEndWith("noimageindex");
    }

    [Fact]
    public void Private_app_default_with_unavailable_after_directive_terminates_with_the_final_directive()
    {
        var unavailableAfter = new DateTime(2022, 3, 4, 15, 56, 52);
        var model = XRobotsModelBuilder.CreatePrivateAppDefault().AddUnavailableAfter(unavailableAfter).Build();

        var output = model.Render();

        output.ShouldEndWith("unavailable_after: 04 Mar 2022 15:56:52 GMT");
    }
}