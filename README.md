# SemanticKernelLMStudio

A very simple command line app (using Spectre.Console.Cli) which implements a custom Semantic Kernel `IChatCompletionService` to interact with the LM Studio [Local LLM Server API](https://lmstudio.ai/docs/api/server).

## Getting Started

- Install the latest version of LM Studio from [https://lmstudio.ai](https://lmstudio.ai).
- Download a model (demo used `mistral-7b-instruct-v0.3`)
- Start the Local LLM Server
- Run the SemanticKernelLMStudio app

## Example

- **Scenario**: Could a SLM be used to perform small editing tasks such as parsing an author string into first and last name?
- **Conjecture**: The SLM could have more encoded knowledge about the cultural first names and family names around the world than the editor of the content.

Prompt:

```
Given the following string contains a name "firstnamelastname" break into first and last name and return a json string as your only output. use `first_name` and `last_name` as keys. Capitalize the first letter of each name.
```

Response:

```json
{
  "first_name": "Firstname",
  "last_name": "Lastname"
}
```

## History

Created for Howard van Rooijen's End of Week Show & Tell Session on 2024-11-29 