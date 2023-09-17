using System.ComponentModel.DataAnnotations.Schema;
using VenomVerseApi.DTO;
namespace VenomVerseApi.Models;

public class CommunityResearch{

    public required long CommunityResearchId { get; set; }
    public required long UserId { get; set; }       // User->UserId    +++Uploaded Expert Id - validate from backend whether user has the expert privilleges
    public required string Category { get; set; } = null!;
    public string? Description { get; set; }
    public required string Content { get; set; } = null!;
    public required DateTime DateTime { get; set; } = DateTime.Now;
    public string[]? Media { get; set;}
    public string? Author { get; set;}
    public DateOnly? PublishedDate { get; set;}    // Research should have been published before upload as a learning material in the application
    public string[]? ResearchCopyright { get; set; }

    public static CommunityResearch ResearchDtoToResearch(ResearchDto researchDto) =>
        new CommunityResearch
        {
            CommunityResearchId = researchDto.CommunityResearchId,
            UserId = researchDto.UserId,
            Category = researchDto.Category, 
            Description = researchDto.Description, 
            Content = researchDto.Content, 
            DateTime = researchDto.DateTime, 
            Media = researchDto.Media, 
            Author = researchDto.Author, 
            PublishedDate = researchDto.PublishedDate, 
            ResearchCopyright = researchDto.ResearchCopyright
        };

    public static ResearchDto ResearchToResearchDto(CommunityResearch research)
    {
        var new_research = new ResearchDto(
            research.CommunityResearchId,
            research.UserId,
            research.Category, 
            research.Description!, 
            research.Content, 
            research.DateTime, 
            research.Media, 
            research.Author!, 
            research.PublishedDate, 
            research.ResearchCopyright
        );
        return new_research;
    }

            // Foreign Key References
            [ForeignKey("UserId")] public Zoologist Zoologist { get; set; } = null!;
}