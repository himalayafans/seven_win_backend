namespace SevenWinBackend.OcrSpace.Ocr;

internal class ParsedResult
{
    public TextOverlay TextOverlay { get; set; } = new TextOverlay();
    public string TextOrientation { get; set; } = string.Empty;
    public int FileParseExitCode { get; set; }
    public string ParsedText { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    public string ErrorDetails { get; set; } = string.Empty;
}