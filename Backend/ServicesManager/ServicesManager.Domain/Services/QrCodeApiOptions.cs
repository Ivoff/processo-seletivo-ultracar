namespace ServicesManager.Domain.QrCodeService;

public class QrCodeApiOptions
{
    public const string Position = "QrCodeAPI";

    public string Address { get; set; } = String.Empty;
    public string Path { get; set; } = String.Empty;
}