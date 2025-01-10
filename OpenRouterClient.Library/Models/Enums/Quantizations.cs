using System.ComponentModel;

namespace OpenRouterClient.Library.Models.Enums;

public enum Quantizations
{
    [Description("int4")] Int4,
    [Description("int8")] Int8,
    [Description("fp6")] Fp6,
    [Description("fp8")] Fp8,
    [Description("fp16")] Fp16,
    [Description("bf16")] Bf16,
    [Description("unknown")] Unknown
}