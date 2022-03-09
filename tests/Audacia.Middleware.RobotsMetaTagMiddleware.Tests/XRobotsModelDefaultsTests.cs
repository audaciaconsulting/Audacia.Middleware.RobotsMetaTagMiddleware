using System;
using Audacia.Middleware.RobotsMetaTagMiddleware.Helpers;
using FluentAssertions;
using Xunit;

namespace Audacia.Middleware.RobotsMetaTagMiddleware.Tests
{
    public class XRobotsModelDefaultsTests
    {
        [Fact]
        public void Private_app_default_has_none_directive()
        {
            var model = XRobotsModelBuilder.CreatePrivateAppDefault().Build();

            var output = model.Render();

            output.Should().Contain("none");
        }

        [Fact]
        public void Private_app_default_has_noarchive_directive()
        {
            var model = XRobotsModelBuilder.CreatePrivateAppDefault().Build();

            var output = model.Render();

            output.Should().Contain("noarchive");
        }

        [Fact]
        public void Private_app_default_has_nosnippet_directive()
        {
            var model = XRobotsModelBuilder.CreatePrivateAppDefault().Build();

            var output = model.Render();

            output.Should().Contain("nosnippet");
        }

        [Fact]
        public void Private_app_default_has_notranslate_directive()
        {
            var model = XRobotsModelBuilder.CreatePrivateAppDefault().Build();

            var output = model.Render();

            output.Should().Contain("notranslate");
        }

        [Fact]
        public void Private_app_default_has_noimageindex_directive()
        {
            var model = XRobotsModelBuilder.CreatePrivateAppDefault().Build();

            var output = model.Render();

            output.Should().Contain("noimageindex");
        }

        [Fact]
        public void Private_app_default_with_unavailable_after_has_unavailable_after_directive()
        {
            var unavailableAfter = new DateTime(2022, 3, 4, 15, 56, 52);
            var model = XRobotsModelBuilder.CreatePrivateAppDefault().AddUnavailableAfter(unavailableAfter).Build();

            var output = model.Render();

            output.Should().Contain("unavailable_after: 04 Mar 2022 15:56:52 GMT");
        }

        [Fact]
        public void Private_app_default_with_bot_name_has_bot_name()
        {
            var model = XRobotsModelBuilder.CreatePrivateAppDefault().AddBotName("googlebot").Build();

            var output = model.Render();

            output.Should().Contain("googlebot:");
        }

        [Fact]
        public void Private_app_default_with_bot_name_has_directives()
        {
            var model = XRobotsModelBuilder.CreatePrivateAppDefault().AddBotName("googlebot").Build();

            var output = model.Render();

            output.Should().Contain("none");
        }

        [Fact]
        public void Private_app_default_terminates_with_the_final_directive()
        {
            var model = XRobotsModelBuilder.CreatePrivateAppDefault().Build();

            var output = model.Render();

            output.Should().EndWith("noimageindex");
        }

        [Fact]
        public void Private_app_default_with_unavailable_after_directive_terminates_with_the_final_directive()
        {
            var unavailableAfter = new DateTime(2022, 3, 4, 15, 56, 52);
            var model = XRobotsModelBuilder.CreatePrivateAppDefault().AddUnavailableAfter(unavailableAfter).Build();

            var output = model.Render();

            output.Should().EndWith("unavailable_after: 04 Mar 2022 15:56:52 GMT");
        }
    }
}