namespace VenomVerseApi.Models;

public enum PostStatus
{
    PendingApproval = 0,
    Posted = 1,
    Reported = -1,
    Hidden = -2
}

public enum ArticleStatus
{
    PendingApproval = 0,
    Approved = 1,
    Rejected = -1,
    Hidden = -2,
    Reported = -3
}