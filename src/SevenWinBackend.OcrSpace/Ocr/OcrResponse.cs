namespace SevenWinBackend.OcrSpace.Ocr;

internal class OcrResponse
{
    public List<ParsedResult> ParsedResults { get; set; } = new List<ParsedResult>();
    public bool IsErroredOnProcessing { get; set; }
    /// <summary>
    /// 错误详情(即便IsErroredOnProcessing=true时，有时也为空)
    /// </summary>
    public string? ErrorDetails { get; set; }
}