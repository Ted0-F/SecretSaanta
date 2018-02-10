using Autofac;
using Autofac.Integration.WebApi;
using SecretSantaa.DataAccess;
using SecretSantaa.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace SecretSaanta
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // IoC
            var builder = new ContainerBuilder();


            builder.RegisterType<UsersRepoImpl>().As<UsersRepo>().SingleInstance();
            builder.RegisterType<GroupsRepoImpl>().As<GroupsRepo>().SingleInstance();
            builder.RegisterType<SessionsRepoImpl>().As<SessionsRepo>().SingleInstance();
            builder.RegisterType<InvitationsRepoImpl>().As<InvitationsRepo>().SingleInstance();

            builder.RegisterType<GlobalErrorHandler>().AsWebApiExceptionFilterFor<ApiController>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            config.Routes.MapHttpRoute(
                name: "GetLinks",
                routeTemplate: "users/{username}/groups/{groupName}/links",
                defaults: new { controller = "Links" }
            );

            config.Routes.MapHttpRoute(
                name: "GetGroups",
                routeTemplate: "users/{username}/groups",
                defaults: new { controller = "Groups" }
            );

            config.Routes.MapHttpRoute(
                name: "Links",
                routeTemplate: "groups/{groupName}/links",
                defaults: new { controller = "Links" }
            );

            config.Routes.MapHttpRoute(
                name: "DeleteParticipants",
                routeTemplate: "groups/{groupName}/participants/{username}",
                defaults: new { controller = "Participants" }
            );

            config.Routes.MapHttpRoute(
                name: "Participants",
                routeTemplate: "groups/{groupName}/participants",
                defaults: new { controller = "Participants" }
            );

            config.Routes.MapHttpRoute(
                name: "DeleteInvitation",
                routeTemplate: "users/{username}/invitations/{id}",
                defaults: new { controller = "Invitations" }
            );

            config.Routes.MapHttpRoute(
                name: "Invitations",
                routeTemplate: "users/{username}/invitations",
                defaults: new { controller = "Invitations" }
            );

            config.Routes.MapHttpRoute(
                name: "GetUser",
                routeTemplate: "users/{username}",
                defaults: new { controller = "Users" }
            );

            config.Routes.MapHttpRoute(
                name: "DeleteSession",
                routeTemplate: "logins/{username}",
                defaults: new { controller = "Logins" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}",
                defaults: new { }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
