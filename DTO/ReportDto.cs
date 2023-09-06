namespace VenomVerseApi.DTO;

public class ReportDto
{
    public ReportDto(long communityPostReportId, long communityPostId, long userId, string description, long? comAdminId, string? response)
    {
        CommunityPostReportId = communityPostReportId;
        CommunityPostId = communityPostId;
        UserId = userId;
        Description = description;
        ComAdminId = comAdminId;
        Response = response;
    }

    public long CommunityPostReportId { get; set; }
    public long CommunityPostId { get; set; }
    public long UserId { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public string Description { get; set; }
    public long? ComAdminId {get; set; }
    public string? Response {get; set; }   
}