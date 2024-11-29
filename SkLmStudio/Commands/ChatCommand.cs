// <copyright file="ChatCommand.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using Microsoft.SemanticKernel.ChatCompletion;
using Spectre.Console.Cli;

namespace SkLmStudio.Commands;

public class ChatCommand : AsyncCommand
{
    private readonly IChatCompletionService chatCompletionService;

    public ChatCommand(IChatCompletionService chatCompletionService)
    {
        this.chatCompletionService = chatCompletionService;
    }

    /// <inheritdoc/>
    public override async Task<int> ExecuteAsync([NotNull] CommandContext context)
    {
        ChatHistory history = [];
       
        //history.AddSystemMessage("You are a useful assistant that replies with short messages.");
        
        Console.WriteLine("📢: type your question or type 'exit' to leave the conversation");

        // chat loop
        while (true)
        {
            Console.Write("💬: ");
            string? input = Console.ReadLine();
            
            if (string.IsNullOrEmpty(input) || input?.ToLower() == "exit")
            {
                break;
            }
            
            history.AddUserMessage(input!);

            history = (ChatHistory)await this.chatCompletionService.GetChatMessageContentsAsync(history);
            
            Console.WriteLine(history[^1].Content);
            Console.WriteLine("---");
        }

        Console.WriteLine("Goodbye!");

        return 0;
    }
}