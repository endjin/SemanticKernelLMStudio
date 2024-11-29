// <copyright file="ServiceCollectionExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel.ChatCompletion;
using SkLmStudio.Commands;

namespace SkLmStudio.Infrastructure;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures the service collection with the required dependencies for the command line application.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    public static void ConfigureDependencies(this ServiceCollection services)
    {
        services.AddTransient<ChatCommand>();
        services.AddTransient<IChatCompletionService, LmStudioChatCompletionService>();
    }
}