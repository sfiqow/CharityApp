using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CApp.Models;

[Table("organisations")] 

//connecting to supabase 
public class Organisation : BaseModel
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }

    [Column("title")]
    public string Title { get; set; }

    [Column("needed")]
    public string Needed { get; set; }

    [Column("detail")]
    public string Detail { get; set; }

    [Column("created_at", ignoreOnInsert: true)]
    public DateTime CreatedAt { get; set; }


}
