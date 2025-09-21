﻿using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Dot_Net_Core_Web_APIs.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeatures = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeatures != null)
                    {
                        context.Response.StatusCode = contextFeatures.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.LogError($"Something went wrong: {contextFeatures.Error}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeatures.Error.Message,
                        }.ToString());
                    }
                });
            });
        }
    }
}
